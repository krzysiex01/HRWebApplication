using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using HRWebApplication.EntityFramework;
using System.Diagnostics;
using HRWebApplication.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using System.Collections.Generic;

namespace Web.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;
        }

        [Route("login")]
        public IActionResult LogIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "auth/loginsuccess" }, "AzureADB2C");
        }

        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            await HttpContext.SignOutAsync("AzureADB2C");
            return Redirect("/");
        }

        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return AccessDenied();
        }

        [Authorize]
        [Route("loginsuccess")]
        public ActionResult LogInSuccessAsync()
        {
            //Redirect user to area matching user role
            switch (User.FindFirst(ClaimTypes.Role).Value)
            {
                case "User":
                    return RedirectToAction("Index", "Home", new { Area = "User" });
                case "Admin":
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                case "HRUser":
                    return RedirectToAction("Index","Home", new { Area = "HRUser" });
                default:
                    return RedirectToAction("Index", "Home", new { Area = "" });

            }
        }
    }
}