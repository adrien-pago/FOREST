using EVF.Admin.Models;
using EVF.Admin.Areas.Account.Models;
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



namespace EVF.Admin.Areas.Account.Controllers
{
    public class ManageAccountController : Controller
    {
        private readonly ILogger<ManageAccountController> _logger;
        private readonly EVFContext _context;
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;

        private readonly UserInfo _user;


        public ManageAccountController(ILogger<ManageAccountController> logger, EVFContext context, UserManager<UserInfo> userManager, RoleManager<IdentityRole> rolesManager, SignInManager<UserInfo> signInManager, IHttpContextAccessor contextAccessor, IOptions<RequestLocalizationOptions> locOptions)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _rolesManager = rolesManager;
            _logger = logger;
        }

        public IActionResult CreateUserAdmin()
        {
            AdminAccountModel adminModel = new AdminAccountModel();

            adminModel.Password = PasswordGenerator.GenerateRandomPassword(_userManager);
  
            return View(adminModel);
        }



        [HttpPost]
        public async Task<IActionResult> CreateUserAdmin(AdminAccountModel newUser)
        {

            string newUserGUID = Guid.NewGuid().ToString();

         

                UserInfo user = new UserInfo()
                {
                    Id = newUserGUID,
                    UserName = newUser.Username,
                    NormalizedUserName = newUser.Username.ToUpper(),
                    PasswordHash = new PasswordHasher<UserInfo>().HashPassword(null, newUser.Password),
                };

                var result = await _userManager.CreateAsync(user, newUser.Password);
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(user, newUser.Role);
                }




            return RedirectToAction("CreateUserAdmin");
        }

        public IActionResult CreateUserPersonnel()
        {
            PersonnelAccountModel personnelModel = new PersonnelAccountModel();

            PasswordGenerator generatePassword = new PasswordGenerator();
            personnelModel.Password = PasswordGenerator.GenerateRandomPassword(_userManager);
            personnelModel.getPersonnelList(_context, _rolesManager);
            return View(personnelModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserPersonnel(PersonnelAccountModel newUser)
        {
            string newUserGUID = Guid.NewGuid().ToString();

            string? email = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == newUser.IdPersonnelSel).Email;

            UserInfo user = new UserInfo()
            {
                Id = newUserGUID,
                UserName = newUser.Username,
                NormalizedUserName = newUser.Username.ToUpper(),
                Email = email,
                NormalizedEmail = email?.ToUpper(),
                PasswordHash = new PasswordHasher<UserInfo>().HashPassword(null, newUser.Password),
                IdPersonnel = newUser.IdPersonnelSel,

            };

            var result = await _userManager.CreateAsync(user, newUser.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, newUser.Role);
            }

            return RedirectToAction("CreateUserPersonnel");
        }



        public IActionResult UsersList()
        {

            return View();
        }

        public IActionResult GenerateUsers()
        {

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