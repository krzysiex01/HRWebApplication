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
    public class CompanyController : Controller
    {
        private readonly DataContext _context;
        public CompanyController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }
    }
}