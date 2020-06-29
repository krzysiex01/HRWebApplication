using HRWebApplication.EntityFramework;
using HRWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRWebApplication.IntegrationTests
{
    public static class SeedDatabase
    {
        /// <summary>
        /// Seeds database with test data.
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(DataContext context)
        {
                context.JobApplications.Add(new JobApplication() { Id = 1, FirstName = "Jan", LastName = "Kowalski", CreatedOn = DateTime.Now, ContactAgreement = true, EmailAddress = "jan@wp.pl", PhoneNumber = "266389183", UserId = 1, JobOfferId = 1 });
                context.JobApplications.Add(new JobApplication() { Id = 2, FirstName = "Andrzej", LastName = "Kowalski", CreatedOn = DateTime.Now.AddDays(-3), ContactAgreement = true, EmailAddress = "jan@wp.pl", PhoneNumber = "266389183", UserId = 1, JobOfferId = 2 });
                context.JobApplications.Add(new JobApplication() { Id = 3, FirstName = "Jan", LastName = "Duda", CreatedOn = DateTime.Now.AddDays(-5), ContactAgreement = true, EmailAddress = "jan@wp.pl", PhoneNumber = "266389183", UserId = 2, JobOfferId = 1 });
                context.JobApplications.Add(new JobApplication() { Id = 4, FirstName = "Pawel", LastName = "Kowalski", CreatedOn = DateTime.Now.AddDays(-12), ContactAgreement = true, EmailAddress = "jan@wp.pl", PhoneNumber = "266389183", UserId = 2, JobOfferId = 2 });
                context.JobApplications.Add(new JobApplication() { Id = 5, FirstName = "James", LastName = "Last", CreatedOn = DateTime.Now.AddDays(-100), ContactAgreement = true, EmailAddress = "jan@wp.pl", PhoneNumber = "266389183", UserId = 1, JobOfferId = 1 });

                context.JobOffers.Add(new JobOffer() { Id = 1, Title = "Plumber", CompanyId = 1, Currency = Currency.JPY, SalaryTo = 100, SalaryFrom = 50, Location = "Warsaw", ValidUntil = DateTime.Now.AddDays(30), Specialization = "Unknown", AddedOn = DateTime.Now.AddDays(-2) });
                context.JobOffers.Add(new JobOffer() { Id = 2, Title = "Senior Plumber", CompanyId = 1, Currency = Currency.JPY, SalaryTo = 100, SalaryFrom = 50, Location = "Warsaw", ValidUntil = DateTime.Now.AddDays(3), Specialization = "Unknown", AddedOn = DateTime.Now.AddDays(-4) });

                context.Companies.Add(new Company() { Id = 1, Name = "Samsung", Location = "Warsaw", Description = "Some description" });

                context.Users.Add(new Models.User() { Id = 1, FirstName = "Jan", LastName = "Kowalski", CompanyId = 1, EmailAddress = "jan@wp.pl", ProviderName = "SomeName", ProviderUserId = "SomeID1" });
                context.Users.Add(new Models.User() { Id = 2, FirstName = "Andrzej", LastName = "Kowalski", CompanyId = null, EmailAddress = "jan@wp.pl", ProviderName = "SomeName", ProviderUserId = "SomeID2" });

                context.SaveChanges();
        }
    }
}
