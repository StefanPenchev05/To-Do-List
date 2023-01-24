using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class AccountController : Controller
    {
        // Handle login form submission
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Validate the form data
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                // Return an error message if the form is incomplete
                ViewBag.ErrorMessage = "Please enter your email and password.";
                return View("Login");
            }

            // Check if the user exists in the database
            // (replace with actual database code)
            var user = Database.GetUser(email, password);
            if(user == null)
            {
                // Return an error message if the login fails
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("Login");
            }

            // Log the user in and redirect to the home page
            // (replace with actual authentication code)
            Authentication.LogIn(user);
            return RedirectToAction("Index", "Home");
        }
    }
}