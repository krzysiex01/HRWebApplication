using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRWebApplication.EntityFramework;
using HRWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRWebApplication.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class JobApplicationController : Controller
    {
        private int pageSize = 3;
        private PaginationHelper paginationHelper = new PaginationHelper();

        private readonly DataContext _context;
        public JobApplicationController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            JobApplicationViewModel jobApplicationViewModel = new JobApplicationViewModel
            {
                JobApplicationsCount = await _context.JobApplications.CountAsync()
            };
            return View(jobApplicationViewModel);
        }

        public async Task<ActionResult> Create(int? jobOfferId)
        {
            if (jobOfferId == null)
            {
                return BadRequest($"jobOfferId cannot be null");
            }
            var model = new CreateJobApplicationViewModel();
            var title = await _context.JobOffers.Where(x => x.Id == jobOfferId).Select(x => x.Title).FirstOrDefaultAsync();
            if (title == null)
            {
                return NotFound($"offer not found in DB");
            }
            model.JobTitle = title;

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

            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == jobApplication.JobOfferId);
            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }
            offer.JobApplications.Add(jobApplication);
            await _context.JobApplications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "JobOffer", new { id = model.JobOfferId, Area = "User" });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id.Value);

            if (application == null)
            {
                return NotFound($"application not found in DB");
            }

            return View(application);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (application == null)
            {
                return NotFound($"application not found in DB");
            }

            application.FirstName = model.FirstName;
            application.LastName = model.LastName;
            application.PhoneNumber = model.PhoneNumber;
            application.EmailAddress = model.EmailAddress;
            application.CvUrl = model.CvUrl;
            application.ContactAgreement = model.ContactAgreement;
            _context.Update(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
            ViewBag.PagesCount = paginationHelper.GetPagesCount(pageSize, await jobApplications.CountAsync());
            return PartialView("_JobApplicationList.cshtml", await jobApplications
                .Skip(paginationHelper.GetFirstIndexOnPage(pageSize, pageNumber))
                .Take(pageSize)
                .ToListAsync());
        }
    }
}