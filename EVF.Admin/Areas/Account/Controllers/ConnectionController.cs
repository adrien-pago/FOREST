using Azure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EVF.Admin.Areas.Account.Models;
using EVF.DAL.Entity.Identity;
using EVF.DAL.DataConnection.EVF;

using Microsoft.EntityFrameworkCore;

using EVF.DAL.Entity.EVF;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using EVF.Admin.Controllers;
using System.Text.RegularExpressions;


namespace EVF.Admin.Areas.Account.Controllers
{
    public class ConnectionController : Controller
    {
        private readonly EVFContext _context;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;



        public ConnectionController(SignInManager<UserInfo> signInManager, UserManager<UserInfo> userManager, EVFContext context, IStringLocalizer<ConnectionController> stringLocalizer)
        {

            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        // GET: ConnectionController
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            // Clear the existing external cookie to ensure a clean login process
            await _signInManager.SignOutAsync();

            ModelState.Clear();
            return View();
        }



        // POST: ConnectionController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(login.Username);


                if (user != null)
                {

                    var checkPassResult = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (checkPassResult.Succeeded)
                    {

                        return Redirect("/");
                    }
                }
            }

            ModelState.AddModelError("", "Identifiant ou mot de passe incorrect");
            return View(login);


        }

    }
}
