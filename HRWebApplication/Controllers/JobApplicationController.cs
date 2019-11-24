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
    [Route("[controller]/[action]")]
    public class JobApplicationController : Controller
    {
        private int pageSize = 3;

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
            var title = await _context.JobOffers.Where(x => x.Id == id.Value).Select(x => x.Title).FirstOrDefaultAsync();
            if (title == null)
            {
                return NotFound($"offer not found in DB");
            }

            model.JobTitle = title;
            model.JobOfferId = id.Value;
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
                JobOfferId = model.JobOfferId,
                ContactAgreement = model.ContactAgreement,
                CreatedOn = DateTime.Now
                //TODO: UserId = ();
            };
            //TODO: better? .Select(x=> x.JobApplications)
            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == jobApplication.JobOfferId);
            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }
            offer.JobApplications.Add(jobApplication);
            await _context.JobApplications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details","JobOffer", new { id = model.JobOfferId });
        }
        public async Task<IActionResult> Index()
        {
            JobApplicationViewModel jobApplicationViewModel = new JobApplicationViewModel
            {
                JobApplicationsCount = await _context.JobApplications.CountAsync()
            };
            return View(jobApplicationViewModel);
        }

        public async Task<PartialViewResult> GetJobApplications(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = (page ?? 1);

            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var jobApplications = from s in _context.JobApplications select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobApplications = jobApplications.Where(s => s.LastName.Contains(searchString));
            }

            jobApplications = sortOrder switch
            {
                "name" => jobApplications.OrderBy(s => s.LastName),
                "name_desc" => jobApplications.OrderByDescending(s => s.LastName),
                "date" => jobApplications.OrderBy(s => s.CreatedOn), 
                "date_desc" => jobApplications.OrderByDescending(s => s.CreatedOn),
                _ => jobApplications.OrderBy(s => s.LastName),
            };

            ViewBag.CurrentPage = pageNumber;
            ViewBag.PagesCount = Math.Ceiling((double)await jobApplications.CountAsync() / pageSize);
            return PartialView("_JobApplicationList", await jobApplications.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync());
        }
    }
}