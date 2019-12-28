using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRWebApplication.EntityFramework;
using HRWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRWebApplication.Areas.Admin.Controllers
{
    /// <summary>
    /// Company controller for Admin user. 
    /// </summary>
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        private readonly DataContext _context;

        /// <summary>
        /// CompanyController constructor.
        /// </summary>
        /// <param name="context"></param>
        public CompanyController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Display custom page for creating new company.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View(new Company());
        }

        /// <summary>
        /// Validate and add to database newly created company.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Company model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _context.Companies.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Company",new { Area = "Admin"});
        }

        /// <summary>
        /// Removes compnay with specified id.
        /// </summary>
        /// <param name="id">ID of company to remove.</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id should not be null");
            }

            _context.Companies.Remove(new Company() { Id = id.Value });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Company", new { Area = "Admin" });

        }

        /// <summary>
        /// Displays custom page for editing company.
        /// </summary>
        /// <param name="id">ID of company to edit.</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var offer = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id.Value);

            if (offer == null)
            {
                return NotFound($"company not found in DB");
            }

            return View(offer);
        }

        /// <summary>
        /// Updates data for given company.
        /// </summary>
        /// <param name="model">New company data.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Company model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == model.Id);
            company.Name = model.Name;
            company.Location = model.Location;
            company.Description = model.Description;
            _context.Update(company);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Company", new { Area = "Admin" });
        }

        /// <summary>
        /// Displays view with list of comapnies.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }
    }
}