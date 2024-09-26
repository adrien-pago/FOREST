using evf.Areas.Account.Models;
using EVF.DAL.DataConnection.EVF;
using EVF.DAL.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EVF.Admin.Areas.Utils;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Collections.Generic;
using System.Collections;
using System.Net.Sockets;
using System.Web;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Metadata;
using evf.Models;
using Microsoft.AspNetCore.Authorization;

namespace evf.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrateur")]
    public class AdminController : Controller
    {
        private readonly EVFContext _context;
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly IStringLocalizer<AdminController> _stringLocalizer;


        public AdminController(EVFContext context, UserManager<UserInfo> userManager, IStringLocalizer<AdminController> stringLocalizer, RoleManager<IdentityRole> rolesManager, SignInManager<UserInfo> signInManager, IHttpContextAccessor contextAccessor, IOptions<RequestLocalizationOptions> locOptions)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _rolesManager = rolesManager;
            _stringLocalizer = stringLocalizer;
        }


        public IActionResult IndexAdmin()
        {
            ViewData["sideBar.createUser"] = _stringLocalizer["sideBar.createUser"].Value;
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}