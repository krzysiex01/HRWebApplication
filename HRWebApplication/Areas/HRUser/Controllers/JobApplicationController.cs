using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using HRWebApplication.EntityFramework;
using HRWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HRWebApplication.Areas.HRUser.Controllers
{
    [Area("HRUser")]
    [Authorize(Roles = "HRUser")]
    public class JobApplicationController : Controller
    {
        private int pageSize = 10;
        private PaginationHelper paginationHelper = new PaginationHelper();


        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public JobApplicationController(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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
            ViewBag.PagesCount = paginationHelper.GetPagesCount(pageSize, await jobApplications.CountAsync());
            //TODO: show only application for certain Company
            return PartialView("_JobApplicationList", await jobApplications
                .Skip(paginationHelper.GetFirstIndexOnPage(pageSize, pageNumber))
                .Take(pageSize)
                .ToListAsync());
        }

        public async Task<IActionResult> AcceptApplication(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("id cannot be null");
            }

            var jobApplication = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);
            jobApplication.ApplicationState = ApplicationState.Accepted;
            _context.Update(jobApplication);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "JobApplication", new { Area = "HRUser" });
        }

        public async Task<IActionResult> RejectApplication(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("id cannot be null");
            }

            var jobApplication = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);
            jobApplication.ApplicationState = ApplicationState.Rejected;
            _context.Update(jobApplication);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "JobApplication", new { Area = "HRUser" });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("id cannot be null");
            }

            var jobApplication = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);
            string connectionString = _config.GetValue<string>("AzureBlob:ConnectionString");

            // Get a reference to a container
            BlobContainerClient container = new BlobContainerClient(connectionString, "applications");

            // Get a reference to a blob
            BlobClient blob = container.GetBlobClient(jobApplication.CvUrl);
            // Remove from AzureBlob
            _ = blob.DeleteIfExistsAsync();

            // Remove from database
            _context.Remove(jobApplication);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "JobApplication", new { Area = "HRUser" });
        }

        public async Task<ActionResult> DownloadCVFile(int? id)
        {
            if (!id.HasValue)
            {
                return NoContent();
            }
            var jobApplication = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);
            string connectionString = _config.GetValue<string>("AzureBlob:ConnectionString");

            // Get a reference to a container
            BlobContainerClient container = new BlobContainerClient(connectionString, "applications");

            // Get a reference to a blob
            BlobClient blob = container.GetBlobClient(jobApplication.CvUrl);

            var fileName = "CV.pdf";
            Stream stream = new MemoryStream();
            var file = await blob.DownloadAsync();
            return File(file.Value.Content, file.Value.ContentType, fileName);
        }
    }
}