using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRWebApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class CompanyController : Controller
    {
        private List<Company> companies = new List<Company>() { new Company() { Name = "Szajsung", Id = 22 } };

        public IActionResult Index()
        {
            return View(companies);
        }
    }
}