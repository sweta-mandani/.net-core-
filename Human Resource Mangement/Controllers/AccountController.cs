using HRM.DATA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Human_Resource_Mangement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<HomeController> _logger;

       
        public AccountController(
                   UserManager<AppUser> userManager,
                   SignInManager<AppUser> signInManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger =logger;
        }

   
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait(false);


            if (user == null)
            {
                RedirectToAction("Login");
            }
            //login functionality  

            return View(user);
        }
        // Login 
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUser appUser)
        {

            //login functionality  
            var user = await _userManager.FindByEmailAsync(appUser.Email);

            if (user != null)
            {
                //sign in  
                var signInResult = await _signInManager.PasswordSignInAsync(user, appUser.Password, false, false);

                if (signInResult.Succeeded)
                {
                    _logger.LogInformation("Login Successfully");
                    return RedirectToAction("Display","Home");
                }
            }

            return RedirectToAction("Register");
        }
         // registration 
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUser appUser)
        {
            //register functionality  

            var user = new AppUser
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Name = appUser.Name,
                DateOfBirth = appUser.DateOfBirth,
                Password = appUser.Password
            };

            var result = await _userManager.CreateAsync(user, user.Password);


            if (result.Succeeded)
            {
                // User sign  
                // sign in   
                var signInResult = await _signInManager.PasswordSignInAsync(user, user.Password, false, false);

                if (signInResult.Succeeded)
                {
                    _logger.LogInformation("register Successfully");
                    return RedirectToAction("Login","Account");
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut(string username, string password)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(" logout Successfully");
            return RedirectToAction("Login","Account");
        }
    }
}
