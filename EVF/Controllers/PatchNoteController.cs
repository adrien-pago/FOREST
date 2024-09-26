using EVF.DAL.Entity.EVF;
using EVF.DAL.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EVF.DAL.DataConnection.EVF;
using EVF.DAL.DataConnection.Identity;
using System.Linq;
using evf.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using evf.Models.PatchNote;

namespace evf.Controllers
{
    public class PatchNoteController : Controller
    {
        private readonly EVFContext _context;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly IStringLocalizer<SettingsController> _stringLocalizer;
        private readonly RequestLocalizationOptions _locOptions;
        private readonly IdentityContext _identityC;

        public PatchNoteController(SignInManager<UserInfo> signInManager, UserManager<UserInfo> userManager, EVFContext context, IdentityContext identityC, IStringLocalizer<SettingsController> stringLocalizer, IOptions<RequestLocalizationOptions> locOptions)
        {
            _context = context;
            _identityC = identityC;
            _signInManager = signInManager;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
            _locOptions = locOptions.Value;
        }

        [HttpGet]
        // GET: PatchNoteController
        public async Task<IActionResult> PatchNoteList()
        {
            UserInfo loggedInUser = await _userManager.GetUserAsync(User);

            Parametrage parametrage = loggedInUser.ParametrageNav;

            if (parametrage != null)
            {
                parametrage.VuMAJ = true;
                _identityC.SaveChanges();
            }

            Lookup<string, PatchNote> patchNoteList = (Lookup<string, PatchNote>)_context.PatchNotes.OrderByDescending(p => p.IdPatchNote).ToLookup(p => p.VersionMajeur, p => p);


            return View(patchNoteList);
        }

        [HttpGet]
        public async Task<bool> HidePatchBox(string dontShowAgain)
        {

            UserInfo loggedInUser = await _userManager.GetUserAsync(User);


            if (loggedInUser != null)
            {
                Parametrage parametrage = loggedInUser.ParametrageNav;

                if (parametrage != null)
                {
                    parametrage.VuMAJ = bool.Parse(dontShowAgain);
                    _identityC.SaveChanges();
                    return true;
                }
            }
            return false;
        }

    }
}
