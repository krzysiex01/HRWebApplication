using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HRWebApplication.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Authorization;
using HRWebApplication.IntegrationTest;
using Microsoft.AspNetCore.Builder;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using HRWebApplication.Models;

namespace HRWebApplication.IntegrationTests
{
    public class CustomHRApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<DataContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("InMemoryDbForTesting"));
            
                services.AddControllersWithViews();
                services.AddRazorPages();
                services.AddScoped<IClaimsTransformation, UserInfoClaims>();

                // Add filter allowing anonymus access and FakeUser instance with necessary claims added.
                services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add(new AllowAnonymousFilter());
                    options.Filters.Add(new FakeUserFilter());
                })
                .AddApplicationPart(typeof(Startup).Assembly);

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DataContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomHRApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        SeedDatabase.Seed(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }
    }
}

