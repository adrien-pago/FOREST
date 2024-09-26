using Azure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using evf.Areas.Account.Models;
using EVF.DAL.Entity.Identity;
using EVF.DAL.DataConnection.EVF;
using evf.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using EVF.DAL.Entity.EVF;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using evf.Controllers;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using NuGet.Protocol;

namespace evf.Areas.Account.Controllers
{
   
    public class ConnectionController : Controller
    {
        private readonly EVFContext _context;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly IStringLocalizer<ConnectionController> _stringLocalizer;
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly IHttpContextAccessor _contextAccessor;


        public ConnectionController(SignInManager<UserInfo> signInManager, UserManager<UserInfo> userManager, EVFContext context, IStringLocalizer<ConnectionController> stringLocalizer, IHttpContextAccessor contextAccessor, RoleManager<IdentityRole> rolesManager, IOptions<RequestLocalizationOptions> locOptions)
        {

            _stringLocalizer = stringLocalizer;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _rolesManager = rolesManager;
            _contextAccessor = contextAccessor;
          
        }


        // GET: AccountController
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                // Clear the existing external cookie to ensure a clean login process
                await _signInManager.SignOutAsync();

                Response.Cookies.Delete(".AspNetCore.Identity.Application");

                #region ViewDataLocalizer
                ViewData["loginpage.title"] = _stringLocalizer["loginpage.title"].Value;
                ViewData["loginpage.welcome"] = _stringLocalizer["loginpage.welcome"].Value;
                ViewData["input.username"] = _stringLocalizer["input.username"].Value;
                ViewData["input.password"] = _stringLocalizer["input.password"].Value;
                ViewData["loginpage.submitbtn"] = _stringLocalizer["loginpage.submitbtn"].Value;
                ViewData["loginpage.errormsg"] = _stringLocalizer["loginpage.errormsg"].Value;
                ViewData["loginpage.forgotPassword"] = _stringLocalizer["loginpage.forgotPassword"].Value;
                #endregion

                ModelState.Clear();

                return View();
            }
        
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login, string returnUrl = "", string culture = "")
        {
         

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(login.Username);
            

                if (user != null)
                {
           

                    var checkPassResult = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (checkPassResult.Succeeded)
                    {
                        if (await _userManager.IsInRoleAsync(user, "ADM"))
                        {
                            return Redirect("/Admin/Admin/IndexAdmin");
                        }
                        else
                        {
                            var rqf = _contextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
                            var currentCulture = string.IsNullOrEmpty(culture) ? rqf.RequestCulture.Culture.Name : culture;

                            Parametrage paramUser = user.ParametrageNav;
                          
                         string userCulture = (paramUser?.LangueBD == "" || paramUser == null) ? currentCulture : paramUser?.LangueBD;
                     
                            Response.Cookies.Append(
                               CookieRequestCultureProvider.DefaultCookieName,
                               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(userCulture)),
                                   new CookieOptions
                                   {
                                       Expires = DateTimeOffset.UtcNow.AddDays(7)
                                   }
                           );
                 

                            return Redirect("/");
                        }
               
                    }
                }
            }

            #region ViewDataLocalizer
            ViewData["loginpage.title"] = _stringLocalizer["loginpage.title"].Value;
            ViewData["loginpage.welcome"] = _stringLocalizer["loginpage.welcome"].Value;
            ViewData["input.username"] = _stringLocalizer["input.username"].Value;
            ViewData["input.password"] = _stringLocalizer["input.password"].Value;
            ViewData["loginpage.submitbtn"] = _stringLocalizer["loginpage.submitbtn"].Value;
            ViewData["loginpage.forgotPassword"] = _stringLocalizer["loginpage.forgotPassword"].Value;
            #endregion

            ModelState.AddModelError("", _stringLocalizer["loginpage.errormsg"].Value);
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None, Duration = -1)]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);

            Response.Cookies.Delete(".AspNetCore.Identity.Application");
            Response.Headers["Cache-Control"] = "no-cache, no-store";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "-1";

            return Redirect(returnUrl ?? "/");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(7)
                    }
            );

            return LocalRedirect(returnUrl);
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            EmailModel confirmEmail = new EmailModel();
            ViewData["forgotPassword.title"] = _stringLocalizer["forgotPassword.title"].Value;
            ViewData["forgotPassword.sendBtn"] = _stringLocalizer["forgotPassword.sendBtn"].Value;
            return View(confirmEmail);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SendEmail(string email)
        {
            TempData["resetPasswordMsg"] = _stringLocalizer["forgotPassword.resetPasswordMsg"].Value;
            return RedirectToAction("ForgotPassword");
        }

        [AllowAnonymous]
        public IActionResult ResetPasswordForm()
        {
            ViewData["resetPForm.resetPassTitle"] = _stringLocalizer["resetPForm.resetPassTitle"].Value;
            ViewData["resetPForm.email"] = _stringLocalizer["resetPForm.email"].Value;
            ViewData["resetPForm.newPassword"] = _stringLocalizer["resetPForm.newPassword"].Value;
            ViewData["resetPForm.confirmPassword"] = _stringLocalizer["resetPForm.confirmPassword"].Value;
            ViewData["resetPForm.resetButton"] = _stringLocalizer["resetPForm.resetButton"].Value;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResetPassword(string email, string password, string confirmPassword)
        {

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AccessDenied(string returnUrl)
        {
            // Récupérer l'utilisateur connecté
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);

            // Initialisation des rôles avec des valeurs par défaut (false)
            ViewBag.IsAdmin = false;
            ViewBag.IsCommercial = false;
            ViewBag.IsAssistantCommercial = false;

            // Si l'utilisateur est récupéré
            if (user != null)
            {
                // Vérifier les rôles de l'utilisateur
                ViewBag.IsAdmin = await _userManager.IsInRoleAsync(user, "ADM");
                ViewBag.IsCommercial = await _userManager.IsInRoleAsync(user, "Commercial");
                ViewBag.IsAssistantCommercial = await _userManager.IsInRoleAsync(user, "AssistantCommercial");

                // Rediriger selon le rôle de l'utilisateur
                //if (ViewBag.IsAdmin)
                //{
                //    return Redirect("/Admin/Admin/IndexAdmin");
                //}
                //if (ViewBag.IsCommercial)
                //{
                //    return Redirect("/ForecastEntry/Customer");
                //}
                //if (ViewBag.IsAssistantCommercial)
                //{
                //    return Redirect("/ForecastEntry/Customer");
                //}
            }
            // Si l'utilisateur n'a pas de rôle particulier ou n'est pas trouvé
            return View("AccessDenied"); // Vue spéciale pour "Accès refusé"
        }

    }
}
