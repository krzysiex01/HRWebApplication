using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRWebApplication.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authentication;
using HRWebApplication.Models;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using System.Diagnostics;

namespace HRWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Use mvc insted of endpoint routing
            services.AddMvc(o => o.EnableEndpointRouting = false);

            // Add Azure ADB2C with default AuthenticationScheme
            services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
                 .AddAzureADB2C(options =>
                 {
                     Configuration.Bind("AzureAdB2C", options);
                 });

            // Gets connection string and adds DbContext
            ConfigureDatabaseServices(services);
            
            services.AddControllersWithViews();
            services.AddRazorPages();

            // Adds additional Claims to User identity
            // Check: UserInfoClaims class in Model folder
            services.AddScoped<IClaimsTransformation, UserInfoClaims>();

            // Adds swagger documentation for API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                // Get VS comments and include them in documentation
                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "HRWebApplication.xml"));
                // Resoves issue caused by uncorrectly described Actions - actions without assigned attribute
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            // Adds ApplicationInsight
            services.AddApplicationInsightsTelemetry();
        }

        /// <summary>
        /// Configure database services.
        /// </summary>
        /// <param name="services"></param>
        protected virtual void ConfigureDatabaseServices(IServiceCollection services)
        {
            // Gets correct connection string either from appsettings.json for local debbuging or
            // from Azure App Serivce env variable overriding DefaultConnection value 
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            // Auto deploy EFCore migrations
            try
            {
                dataContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "MyArea",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
