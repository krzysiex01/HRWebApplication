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
    /// <summary>
    /// Controller responsible for user authentication.
    /// </summary>
    [Route("auth")]
    public class AuthController : Controller
    {
        /// <summary>
        /// Action called after log-in request - challange user using AzureADB2C.
        /// </summary>
        /// <returns></returns>
        [Route("login")]
        [HttpGet]
        public IActionResult LogIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "auth/loginsuccess" }, "AzureADB2C");
        }

        /// <summary>
        /// Logout action.
        /// </summary>
        /// <returns></returns>
        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            await HttpContext.SignOutAsync("AzureADB2C");
            return Redirect("/");
        }

        /// <summary>
        /// Action called after user wasn't successfully authenticated.
        /// </summary>
        /// <returns></returns>
        [Route("accessdenied")]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return AccessDenied();
        }

        /// <summary>
        /// Action called after succssful login.
        /// </summary>
        /// <returns>Redirect user to area matching user role.</returns>
        [Authorize]
        [Route("loginsuccess")]
        [HttpGet]
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