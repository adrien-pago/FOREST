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

namespace EVF.Admin.Areas.Account.Controllers
{

    [Authorize(Roles = "Administrateur")]
    public class ManageAccountController : Controller
    {
        private readonly ILogger<ManageAccountController> _logger;
        private readonly EVFContext _context;
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly IStringLocalizer<ManageAccountController> _stringLocalizer;


        public ManageAccountController(ILogger<ManageAccountController> logger, EVFContext context, UserManager<UserInfo> userManager, IStringLocalizer<ManageAccountController> stringLocalizer, RoleManager<IdentityRole> rolesManager, SignInManager<UserInfo> signInManager, IHttpContextAccessor contextAccessor, IOptions<RequestLocalizationOptions> locOptions)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _rolesManager = rolesManager;
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }


        public IActionResult CreateUserAdmin()
        {
            AdminAccountModel adminModel = new AdminAccountModel();

            adminModel.Password = PasswordGenerator.GenerateRandomPassword(_userManager);


            #region ViewDataLocalizer
            ViewData["createUser.username"] = _stringLocalizer["createUser.username"].Value;
            ViewData["createUserA.header"] = _stringLocalizer["createUserA.header"].Value;
            ViewData["CreateUser.createBtn"] = _stringLocalizer["CreateUser.createBtn"].Value;
            ViewData["sideBar.createUser"] = _stringLocalizer["sideBar.createUser"].Value;
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;
            #endregion

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
                    result = await _userManager.AddToRoleAsync(user, "ADM");
                }


            TempData["msgAdmin"] = _stringLocalizer["msgSuccess"].Value;

            return RedirectToAction("CreateUserAdmin");
        }

        public IActionResult CreateUserPersonnel()
        {
            PersonnelAccountModel personnelModel = new PersonnelAccountModel();

            PasswordGenerator generatePassword = new PasswordGenerator();
            personnelModel.Password = PasswordGenerator.GenerateRandomPassword(_userManager);
            personnelModel.getPersonnelList(_context, _rolesManager);

            #region ViewDataLocalizer
            ViewData["createUserP.header"] = _stringLocalizer["createUserP.header"].Value;
            ViewData["createUser.username"] = _stringLocalizer["createUser.username"].Value;
            ViewData["createUserP.selectList"] = _stringLocalizer["createUserP.selectList"].Value;
            ViewData["CreateUser.createBtn"] = _stringLocalizer["CreateUser.createBtn"].Value;
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;
            ViewData["sideBar.createUser"] = _stringLocalizer["sideBar.createUser"].Value;
            #endregion

            return View(personnelModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserPersonnel(PersonnelAccountModel newUser)
        {
            string newUserGUID = Guid.NewGuid().ToString();

            int idPerso = Int32.Parse(newUser.IdPersonnelSel.Split("-")[0]);

            int idRole = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idPerso).IdRole;

            string userRole = _rolesManager.Roles.FirstOrDefault(r => r.Id == idRole.ToString()).NormalizedName;

            string? email = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idPerso).Email;
            string nomPrenom = _context.Personnel.FirstOrDefault(p => p.IdPersonnel == idPerso).Nom;

            UserInfo user = new UserInfo()
            {
                Id = newUserGUID,
                UserName = newUser.Username,
                NormalizedUserName = newUser.Username.ToUpper(),
                Email = email,
                NormalizedEmail = email?.ToUpper(),
                PasswordHash = new PasswordHasher<UserInfo>().HashPassword(null, newUser.Password),
                IdPersonnel = idPerso,
                Nom = nomPrenom,

            };

            var result = await _userManager.CreateAsync(user, newUser.Password);
            if (result.Succeeded)
            {

                result = await _userManager.AddToRoleAsync(user, userRole);
            }

            TempData["msgPersonnel"] = _stringLocalizer["msgSuccess"].Value;

            #region ViewDataLocalizer
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;
            #endregion

            return RedirectToAction("CreateUserPersonnel");
        }


        public async Task<IActionResult> RegisteredUsersList()
        {
          

            ListsViewModel listsModel = new ListsViewModel();

            List<UserModel> usersList = new List<UserModel>();
            
            foreach (var user in _userManager.Users)
            {
                if(user.IdPersonnel != null)
                {

                    UserModel registeredUser = new UserModel()
                    {
                        Username = user.UserName,
                        Name = user.Nom,
                        Email = user.Email,
                        IdPersonnel = user.IdPersonnel,
                        IsLockout = await _userManager.IsLockedOutAsync(user) ? true : false

                    };

                    usersList.Add(registeredUser);
                }
                
            }
          //  usersList.UsersList = _userManager.Users.ToList();

            listsModel.UsersList = usersList;


            #region ViewDataLocalizer
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;
            ViewData["sideBar.createUser"] = _stringLocalizer["sideBar.createUser"].Value;
            #endregion

            return View(listsModel);
        }

        [HttpPost]
        public async Task<IActionResult> UnlockUser(string usernameToPost)
        {
            string username =usernameToPost;

            UserInfo updatedUserInfo = _userManager.Users.FirstOrDefault(u => u.UserName == username);
           

            //Lock user
            if (!await _userManager.IsLockedOutAsync(updatedUserInfo))
            {
                var lockUser = _userManager.SetLockoutEndDateAsync(updatedUserInfo, DateTime.Now.AddYears(1000));

                lockUser.Wait();
            }

            //Unlock user
            else
            {
                var unlockUser = _userManager.SetLockoutEndDateAsync(updatedUserInfo, DateTime.Now);
                unlockUser.Wait();
            }

     
            return RedirectToAction("RegisteredUsersList");
        }



        [HttpPost]
        public async Task<IActionResult> ResetUserPassword(string usernameToPost)
        {
           string newUserPass = PasswordGenerator.GenerateRandomPassword(_userManager);
           var user = await _userManager.FindByNameAsync(usernameToPost);

         if (user != null)
          {
               string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
               var passwordChangeResult = await _userManager.ResetPasswordAsync(user, resetToken,newUserPass);
          }
            TempData["userName"] = user.Nom;
            TempData["newPass"] = newUserPass;
            return RedirectToAction("RegisteredUsersList");
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