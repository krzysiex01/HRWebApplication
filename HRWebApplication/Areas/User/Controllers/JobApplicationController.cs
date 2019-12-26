using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using HRWebApplication.EntityFramework;
using HRWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HRWebApplication.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
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
                JobApplicationsCount = await _context.JobApplications.Where(s => s.User.ProviderUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).CountAsync()
            };
            return View(jobApplicationViewModel);
        }
        public async Task<ActionResult> Create(int? jobOfferId)
        {
            if (!jobOfferId.HasValue)
            {
                return BadRequest($"jobOfferId cannot be null");
            }
            var model = new CreateJobApplicationViewModel();
            var title = await _context.JobOffers.Where(x => x.Id == jobOfferId).Select(x => x.Title).FirstOrDefaultAsync();
            if (title == null)
            {
                return NotFound($"offer not found in DB");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.ProviderUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

            model.JobTitle = title;
            model.JobOfferId = jobOfferId.Value;
            //Pre-fill the form with data from users Database
            model.FirstName = user.FirstName;
            model.EmailAddress = user.EmailAddress;
            model.LastName = user.LastName;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateJobApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var title = await _context.JobOffers.Where(x => x.Id == model.JobOfferId).Select(x => x.Title).FirstOrDefaultAsync();
                if (title == null)
                {
                    return NotFound($"offer not found in DB");
                }
                model.JobTitle = title;
                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.ProviderUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (user == null)
            {
                return NotFound($"user not found");
            }

            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == model.JobOfferId);
            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }

            string trustedName = user.ProviderUserId + DateTime.Now.ToFileTime() + ".pdf";
            // Upload CV to AzureBlob
            UploadCV(model.UploadedCVFile, trustedName);
            JobApplication jobApplication = new JobApplication
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                JobOfferId = model.JobOfferId,
                ContactAgreement = model.ContactAgreement,
                CreatedOn = DateTime.Now,
                ApplicationState = ApplicationState.Waiting,
                UserId = user.Id,
                User = user,
                CvUrl = trustedName
            };
            offer.JobApplications.Add(jobApplication);
            await _context.JobApplications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
            // Send notification emails using SendGrid
            SendNotifications(offer.CompanyId);

            return RedirectToAction("Details", "JobOffer", new { id = model.JobOfferId, Area = "User" });
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id.Value);

            if (application.ApplicationState != ApplicationState.Waiting)
            {
                return BadRequest("can edit only waiting applications");
            }

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
            return RedirectToAction("Index", "JobApplication", new { Area = "User" });
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

            return RedirectToAction("Index", "JobApplication", new { Area = "User" });
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

            var jobApplications = _context.JobApplications.Where(s => s.User.ProviderUserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

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
            return PartialView("_JobApplicationList", await jobApplications
                .Skip(paginationHelper.GetFirstIndexOnPage(pageSize, pageNumber))
                .Take(pageSize)
                .Include(s => s.JobOffer)
                .ThenInclude(s => s.Company)
                .ToListAsync());
        }
        private async void SendNotifications(int companyId)
        {
            // Get API key
            var apiKey = _config.GetSection("SendGridAPIKey").Value;
            // Create SendGrid client
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("noreplymessage@hrwebapplication.com", "HR Web Application");
            // Get users assigned to given compnay
            var users = await _context.Users.Where(m => m.CompanyId.HasValue && m.CompanyId == companyId).ToListAsync();
            // Craete email list
            List<EmailAddress> tos = new List<EmailAddress>();
            // Populate with data
            foreach (var user in users)
            {
                tos.Add(new EmailAddress(user.EmailAddress, user.FirstName + user.LastName));
            }

            var subject = "You received new application";
            var htmlContent = "<strong>Hello you have new application waiting for you!</strong>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, false);
            _ = client.SendEmailAsync(msg);
        }
        private async void UploadCV(IFormFile formFile, string trustedName)
        {
            string fileName = trustedName;
            string connectionString = _config.GetValue<string>("AzureBlob:ConnectionString");

            // Get a reference to a container
            BlobContainerClient container = new BlobContainerClient(connectionString, "applications");

            // Get a reference to a blob
            BlobClient blob = container.GetBlobClient(fileName);

            if (formFile.Length > 0)
            {
                // Open the stream and upload its data
                await blob.UploadAsync(formFile.OpenReadStream());
            }
        }
    }
}