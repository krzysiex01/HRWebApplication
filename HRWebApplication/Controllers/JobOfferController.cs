using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRWebApplication.Models;

namespace HRWebApplication.Controllers
{
    [Route("[controller]")]
    public class JobOfferController : Controller
    {
        private static List<JobOffer> jobOffer = new List<JobOffer>
            {
                new Models.JobOffer() { Id = 1, Title= "Plumber", Overview="Looking for experienced plumber.", Specialization = "Plumber", Location = "Paris",
                    SalaryFrom = 1000, SalaryTo = 3000, Currency = Currency.EUR, AddedOn = DateTime.Now},
                new Models.JobOffer() { Id = 2, Title= "Advanced Plumber",Overview = "Looking for Mario.", Specialization = "Plumber", Location = "Warsaw",
                    SalaryFrom = 1000, SalaryTo = 3000, Currency = Currency.PLN, AddedOn = DateTime.Now},
                new Models.JobOffer() { Id = 3, Title= "Senior Plumber",Overview = "Looking for senior plumber.", Specialization = "Plumber", Location = "London",
                    SalaryFrom = 1000, SalaryTo = 3000, Currency = Currency.GBP, AddedOn = DateTime.Now},
                new Models.JobOffer() { Id = 3, Title= "Senior Plumber",Overview = "Looking for senior plumber.", Specialization = "Plumber", Location = "London",
                    SalaryFrom = 1000, SalaryTo = 3000, Currency = Currency.GBP, AddedOn = DateTime.Now},
                new Models.JobOffer() { Id = 3, Title= "Senior Plumber",Overview = "Looking for senior plumber.", Specialization = "Plumber", Location = "London",
                    SalaryFrom = 1000, SalaryTo = 3000, Currency = Currency.GBP, AddedOn = DateTime.Now},
                new Models.JobOffer() { Id = 3, Title= "Senior Plumber",Overview = "Looking for senior plumber.", Specialization = "Plumber", Location = "London",
                    SalaryFrom = 1000, SalaryTo = 3000, Currency = Currency.GBP, AddedOn = DateTime.Now},
                new Models.JobOffer() { Id = 3, Title= "Senior Plumber",Overview = "Looking for senior plumber.", Specialization = "Plumber", Location = "London",
                    SalaryFrom = 1000, SalaryTo = 3000, Currency = Currency.GBP, AddedOn = DateTime.Now},
            };

        [Route("Index")]
        public IActionResult Index()
        {
            return View(jobOffer);
        }

        public IActionResult Details(int id)
        {
            var offer = jobOffer.FirstOrDefault(o => o.Id == id);
            return View(offer);
        }
    }
}