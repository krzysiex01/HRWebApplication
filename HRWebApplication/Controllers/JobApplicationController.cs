using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRWebApplication.EntityFramework;
using HRWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRWebApplication.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly DataContext _context;
        public JobApplicationController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Create(int? id)
        {
            var model = new CreateJobApplicationViewModel();
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            //TODO: dont download whole offer only title - DONE better??
            var title = await _context.JobOffers.Where(x => x.Id == id.Value).Select(x => x.Title).FirstOrDefaultAsync();
            if (title == null)
            {
                return NotFound($"offer not found in DB");
            }

            model.JobTitle = title;
            model.OfferId = id.Value;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateJobApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            JobApplication jobApplication = new JobApplication
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                OfferId = model.OfferId,
                ContactAgreement = model.ContactAgreement
            };
            //TODO: better? .Select(x=> x.JobApplications)
            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == jobApplication.OfferId);
            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }
            offer.JobApplications.Add(jobApplication);
            await _context.JobApplications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details","JobOffer", new { id = model.OfferId });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}