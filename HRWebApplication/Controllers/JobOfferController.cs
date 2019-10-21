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
        private static List<JobOfferViewModel> jobOfferViewModels = new List<JobOfferViewModel>
            {
                new Models.JobOfferViewModel() { Id = 1, Title= "Plumber", Description="Looking for experienced plumber."},
                new Models.JobOfferViewModel() { Id = 2, Title= "Advanced Plumber",Description = "Looking for Mario."},
                new Models.JobOfferViewModel() { Id = 3, Title= "Senior Plumber",Description = "Looking for senior plumber."},
            };

        [Route("Index")]
        public IActionResult Index()
        {
            return View(jobOfferViewModels);
        }

        public IActionResult Details(int id)
        {
            var offer = jobOfferViewModels.FirstOrDefault(o => o.Id == id);
            return View(offer);
        }
    }
}