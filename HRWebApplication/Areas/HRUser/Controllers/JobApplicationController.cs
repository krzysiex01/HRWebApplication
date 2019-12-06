using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRWebApplication.EntityFramework;
using HRWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRWebApplication.Areas.HRUser.Controllers
{
    [Area("HRUser")]
    [Authorize(Roles = "HRUser")]
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
            return PartialView("_JobApplicationList", await jobApplications
                .Skip(paginationHelper.GetFirstIndexOnPage(pageSize, pageNumber))
                .Take(pageSize)
                .ToListAsync());
        }
    }
}