using HRWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company() { Id = 1, Name = "Apple", Description = "Some desctiption", Location = "Warsaw" }
                );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, FirstName = "Krzysztof", LastName = "Oniszczuk", EmailAddress = "krzysiex01@wp.pl", ProviderName = "AZURE_AD_B2C", ProviderUserId = "f484c79c-dd70-4dab-82bb-fdf4d5687a64", Role = "Admin", City = "Warsaw", Country = "Poland" },
                new User() { Id = 2, FirstName = "Andrzej", LastName = "Powała", EmailAddress = "hrwebapplication.user@wp.pl", ProviderName = "AZURE_AD_B2C", ProviderUserId = "d9fa8c96-873b-481d-8194-78ff752f32d6", Role = "User", City = "Warsaw", Country = "Poland" },
                new User() { Id = 3, FirstName = "Jan", LastName = "Kowalski", EmailAddress = "hrwebapplication.hruser@wp.pl", ProviderName = "AZURE_AD_B2C", ProviderUserId = "0c198acb-ac45-47ac-9b49-46dc37c373b4", Role = "HRUser", City = "Warsaw", Country = "Poland", CompanyId = 1 });
        }
    }
}
