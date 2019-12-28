using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc.Filters;
using HRWebApplication.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using HRWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace HRWebApplication.Areas.Admin.Controllers
{
    /// <summary>
    /// Controller for admins to manage registered users.
    /// </summary>
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly DataContext _context;

        /// <summary>
        /// UserController constructor.
        /// </summary>
        /// <param name="context"></param>
        public UserController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets view with list of all users 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Users = await _context.Users.Include(x => x.Company).ToListAsync();
            userViewModel.Companies = await _context.Companies.ToListAsync();

            return View(userViewModel);
        }

        /// <summary>
        /// Update the role of specified user by company assigment.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IActionResult> Update(int? userId, int? companyId)
        {
            if (userId.HasValue)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId.Value);
                
                if (companyId.HasValue)
                {
                    user.Company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == companyId.Value);
                    user.Role = "HRUser";
                }
                else
                {
                    user.CompanyId = null;
                    user.Company = null;
                    user.Role = "User";
                }
                
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }
     }
}