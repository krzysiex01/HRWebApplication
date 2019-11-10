using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRWebApplication.Models;
using HRWebApplication.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HRWebApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class JobOfferController : Controller
    {
        private readonly DataContext _context;
        public JobOfferController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return View(await _context.JobOffers.ToListAsync());
            //TODO: Why include - ok fixed
            //TODO: maybe only one/two column needed
            List<JobOffer> searchResult = await _context.JobOffers.Where(o => o.Title.Contains(searchString)).ToListAsync();
            return View(searchResult);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == id.Value);

            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }

            return View(offer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(JobOffer model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == model.Id);
            offer.Title = model.Title;
            offer.Overview = model.Overview;
            offer.Location = model.Location;
            offer.SalaryFrom = model.SalaryFrom;
            offer.SalaryTo = model.SalaryTo;
            offer.Specialization = model.Specialization;
            offer.ValidUntil = model.ValidUntil;
            offer.Description = model.Description;
            offer.Currency = model.Currency;
            //TODO: Enable changing other fileds
            _context.Update(offer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id should not be null");
            }

            _context.JobOffers.Remove(new JobOffer() { Id = id.Value });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Create()
        {
            var model = new CreateJobOfferViewModel
            {
                Companies = await _context.Companies.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateJobOfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = await _context.Companies.ToListAsync();
                return View(model);
            }

            JobOffer jobOffer = new JobOffer
            {
                CompanyId = model.CompanyId,
                Overview = model.Overview,
                Description = model.Description,
                Title = model.Title,
                Location = model.Location,
                SalaryFrom = model.SalaryFrom,
                SalaryTo = model.SalaryTo,
                ValidUntil = model.ValidUntil,
                AddedOn = DateTime.Now,
                Specialization = model.Specialization
            };

            await _context.JobOffers.AddAsync(jobOffer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            //Get all data at once
            // var offer = await _context.JobOffers.Include(x => x.JobApplications).FirstOrDefaultAsync(x => x.Id == id);

            //Get JobApplications using AJAX
            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == id);
            if (offer is null)
            {
                return NotFound($"offer not found in DB");
            }
            return View(offer);
        }
    }
}