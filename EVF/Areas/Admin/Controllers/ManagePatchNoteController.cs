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
using evf.Areas.Admin.Models.PatchNote;
using EVF.DAL.Entity.EVF;
using System.Security.Principal;
using EVF.DAL.DataConnection.Identity;
using Microsoft.AspNetCore.Authorization;

namespace evf.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrateur")]
    public class ManagePatchNoteController : Controller
    {
        private readonly EVFContext _context;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly IStringLocalizer<ManagePatchNoteController> _stringLocalizer;
        private readonly IdentityContext _identityC;


        public ManagePatchNoteController(EVFContext context, UserManager<UserInfo> userManager, IdentityContext identityC, IStringLocalizer<ManagePatchNoteController> stringLocalizer, SignInManager<UserInfo> signInManager, IOptions<RequestLocalizationOptions> locOptions)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _stringLocalizer = stringLocalizer;
            _identityC = identityC;
        }


        public IActionResult PatchNoteForm()
        {
            PatchNoteModel patchNote = new PatchNoteModel();

            ViewData["sideBar.createUser"] = _stringLocalizer["sideBar.createUser"].Value;
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;

            return View(patchNote);
        }

        [HttpPost]
        public IActionResult PatchNoteForm(string version, string titre, string explication, int numeroCorrectif)
        {
            foreach (var user in _userManager.Users)
            {
                Parametrage parametrage = user.ParametrageNav;

                if (parametrage != null)
                {
                    parametrage.VuMAJ = false;
                    _identityC.SaveChanges();
                }

            }

            PatchNote newPatch = new PatchNote
            {
                Titre = titre,
                Explication = explication,
                Date = DateTime.Today,
                VersionMajeur = version,
                NumeroCorrectif = numeroCorrectif.ToString()
            };
            _context.PatchNotes.Add(newPatch);

            _context.SaveChanges();

            TempData["msgPatchSuccess"] = _stringLocalizer["msgPatchSuccess"].Value;

            return RedirectToAction("PatchNoteForm");
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