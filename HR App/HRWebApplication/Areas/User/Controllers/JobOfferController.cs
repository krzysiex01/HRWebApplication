﻿using System;
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
    /// <summary>
    /// Job offer controller for standard user.
    /// </summary>
    [Area("User")]
    [Authorize(Roles = "User")]
    public class JobOfferController : Controller
    {
        private int pageSize = 3;
        private PaginationHelper paginationHelper = new PaginationHelper();

        private readonly DataContext _context;

        /// <summary>
        /// JobOfferController constructor.
        /// </summary>
        /// <param name="context"></param>
        public JobOfferController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Action gets the view containing list of job offers matching filters defined as parametrs.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<PartialViewResult> GetJobOffers(string sortOrder, string currentFilter, string searchString, int? page)
        {
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

            var jobOffers = from s in _context.JobOffers
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobOffers = jobOffers.Where(s => s.Title.Contains(searchString));
            }

            jobOffers = sortOrder switch
            {
                "name" => jobOffers.OrderBy(s => s.Title),
                "name_desc" => jobOffers.OrderByDescending(s => s.Title),
                "date" => jobOffers.OrderBy(s => s.AddedOn),
                "date_desc" => jobOffers.OrderByDescending(s => s.AddedOn),
                _ => jobOffers.OrderBy(s => s.Title),
            };

            int pageNumber = (page ?? 1);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.PagesCount = paginationHelper.GetPagesCount(pageSize, await jobOffers.CountAsync());
            List<JobOffer> jobOffersList = await jobOffers
                .Skip(paginationHelper.GetFirstIndexOnPage(pageSize,pageNumber))
                .Take(pageSize)
                .ToListAsync();

            JobOfferListViewModel jobOfferListViewModel = new JobOfferListViewModel()
            {
                JobOffers = jobOffersList,
                PendingOffers = new List<int>()
            };

            return PartialView("_JobOfferList", jobOfferListViewModel);
        }

        /// <summary>
        /// Displays main view for paging jobs offers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            JobOfferViewModel jobOfferViewModel = new JobOfferViewModel();
            jobOfferViewModel.JobOffersCount = await _context.JobOffers.CountAsync();

            ViewBag.CurrentPage = 1;
            ViewBag.PagesCount = Math.Ceiling((double)jobOfferViewModel.JobOffersCount / pageSize);
            return View(jobOfferViewModel);
        }

        /// <summary>
        /// Gets page with detailed information about job offer with specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return BadRequest("id cannot be null");
            }
            var offer = await _context.JobOffers.FirstOrDefaultAsync(x => x.Id == id);
            if (offer is null)
            {
                return NotFound($"offer not found in DB");
            }
            return View(offer);
        }
    }
}