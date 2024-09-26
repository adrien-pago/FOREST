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
using X.PagedList;
using System.Globalization;
using System.Reflection.Metadata;

namespace evf.Controllers
{
    public class SettingsController : Controller
    {
        private readonly EVFContext _context;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly IStringLocalizer<SettingsController> _stringLocalizer;
        private readonly RequestLocalizationOptions _locOptions;
        private readonly IdentityContext _identityC;
        private readonly IHttpContextAccessor _contextAccessor;

        public SettingsController(SignInManager<UserInfo> signInManager, IHttpContextAccessor contextAccessor, UserManager<UserInfo> userManager, EVFContext context, IdentityContext identityC, IStringLocalizer<SettingsController> stringLocalizer, IOptions<RequestLocalizationOptions> locOptions)
        {
            _context = context;
            _identityC = identityC;
            _signInManager = signInManager;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
            _locOptions = locOptions.Value;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> UserSettings()
        {
            UserInfo loggedInUser = await _userManager.GetUserAsync(User);

            Parametrage parametrage = loggedInUser.ParametrageNav; //.FirstOrDefault(p => p.IdAspUser == loggedInUser.Id);

            Personnel personnel = loggedInUser.PersonnelNav;
            string userSociete = _context.Personnel.Include(p => p.IdSocieteNavigation).First(p => p.IdPersonnel == personnel.IdPersonnel).IdSocieteNavigation.NomSociete;

            var cultureItems = _locOptions.SupportedUICultures
          .Select(c => new SelectListItem { Value = c.Name, Text = c.DisplayName, Selected = c.Name == parametrage?.LangueBD ? true : false })
          .ToList();


            // List of date formats
            Dictionary<string, string> dateFormats = new Dictionary<string, string>()
            {
                { _stringLocalizer["page.formatDMYP"].Value,"dd.MM.yyyy"},
                { _stringLocalizer["page.formatYMDP"].Value,"yyyy.MM.dd"},
                { _stringLocalizer["page.formatMDYS"].Value, "MM/dd/yyyy"},
                { _stringLocalizer["page.formatYMDS"].Value, "yyyy/MM/dd"},
                { _stringLocalizer["page.formatDMYS"].Value,"dd/MM/yyyy"},
                { _stringLocalizer["page.formatMDYH"].Value, "MM-dd-yyyy"},
                { _stringLocalizer["page.formatYMDH"].Value, "yyyy-MM-dd"}
            };
          
            var dateFormatItems = new List<SelectListItem>();
            string defaultDateFormat = "";
            foreach(KeyValuePair<string,string> dateFormat in dateFormats)
            {
           
                dateFormatItems.Add(new SelectListItem()
                {
                    Text = dateFormat.Key,
                    Value = dateFormat.Value,

                });
                if (dateFormat.Value == "yyyy/MM/dd")
                {
                    defaultDateFormat = dateFormat.Value;
                }
            }

            string dateFormatBD = parametrage?.FormatDate != null ? parametrage?.FormatDate : defaultDateFormat;

            // List of decimal formats
            Dictionary<string, string> decimalFormats = new Dictionary<string, string>()
            {
                { "1.234.567,89","es-ES"},
                { "1,234,567.89","en-US"},
                { "1 234 567,89", "fr-FR"},
                { "12,34,567.89", "hi-IN"}
            };

            var decimalFormatItems = new List<SelectListItem>();
            string defaultDecimalFormat = "";
            foreach (KeyValuePair<string, string> decimalFormat in decimalFormats)
            {

                decimalFormatItems.Add(new SelectListItem()
                {
                    Text = decimalFormat.Key,
                    Value = decimalFormat.Value,
                    Selected = parametrage?.DecimalFormat == decimalFormat.Value ? true : false

                });

                if (decimalFormat.Value == "en-US")
                {
                    defaultDecimalFormat = decimalFormat.Value;
                }
            }

            string decimalFormatBD = parametrage != null ? parametrage?.DecimalFormat : defaultDecimalFormat;

            // List of type of save
            Dictionary<string, string> listTypeSave = new Dictionary<string, string>()
            {
                { _stringLocalizer["page.individualType"].Value,"Individual"},
                { _stringLocalizer["page.globalType"].Value, "Global"}
            };

            var saveTypeItems = new List<SelectListItem>();
            string defaultSaveType = "";
            foreach(KeyValuePair<string,string> saveType in listTypeSave)
            {
                saveTypeItems.Add(new SelectListItem()
                {
                    Text = saveType.Key,
                    Value = saveType.Value,
                    Selected = parametrage?.SaveType == saveType.Value ? true : false
                });

                if (saveType.Value == "Individual") { 
                defaultSaveType = saveType.Value;
                }
            }

            string saveTypeBD = parametrage != null ? parametrage?.SaveType : defaultSaveType;


            UserSettingsViewModel userSettingsModel = new UserSettingsViewModel(loggedInUser.UserName, userSociete, loggedInUser.Email, parametrage?.LangueBD, cultureItems, dateFormatBD, dateFormatItems,decimalFormatBD, decimalFormatItems, saveTypeItems,saveTypeBD) ;

            #region ViewDataLocalizer
            ViewData["page.title"] = _stringLocalizer["page.title"].Value;
            ViewData["lbl.username"] = _stringLocalizer["lbl.username"].Value;
            ViewData["lbl.company"] = _stringLocalizer["lbl.company"].Value;
            ViewData["lbl.email"] = _stringLocalizer["lbl.email"].Value;
            ViewData["lbl.language"] = _stringLocalizer["lbl.language"].Value;
            ViewData["page.submitbtn"] = _stringLocalizer["page.submitbtn"].Value;
            ViewData["page.cancelbtn"] = _stringLocalizer["page.cancelbtn"].Value;
            ViewData["page.selectlang"] = _stringLocalizer["page.selectlang"].Value;
            ViewData["page.selectformat"] = _stringLocalizer["page.selectformat"].Value;
            ViewData["lbl.dateFormat"] = _stringLocalizer["lbl.dateFormat"].Value;
            ViewData["lbl.numberFormat"] = _stringLocalizer["lbl.numberFormat"].Value;
            ViewData["lbl.saveType"] = _stringLocalizer["lbl.saveType"].Value;
            #endregion


            // Gets a NumberFormatInfo associated with the en-US culture.
            NumberFormatInfo nfiUS = new CultureInfo("en-US", false).NumberFormat;
            NumberFormatInfo nfiFR = new CultureInfo("fr-FR", false).NumberFormat;
            NumberFormatInfo nfiGB = new CultureInfo("en-GB", false).NumberFormat;

            NumberFormatInfo nfiES = new CultureInfo("es-ES", false).NumberFormat;
            NumberFormatInfo nfiIN = new CultureInfo("hi-IN", false).NumberFormat;
            // Displays a value with the default separator (",").
            var myInt = 123456789;

            var IntUS = myInt.ToString("N", nfiUS);
   
            // Displays the same value with a blank as the separator.

            var IntFR = myInt.ToString("N", nfiFR);

            var IntEspa = myInt.ToString("N", nfiES);

            var IntIndia = myInt.ToString("N", nfiIN);
            var IntGB = myInt.ToString("N", nfiGB);

            decimal.TryParse(IntUS, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal formattedAmount);

            var dbdecimal = formattedAmount;

            return View(userSettingsModel);
        }


        [HttpPost]
        [AllowAnonymous]
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


        [HttpPost]
        public async Task<IActionResult> UpdateSettings(string langueBD, string FormatDate, string FormatDecimal, string saveType)
        {
            UserInfo loggedInUser = await _userManager.GetUserAsync(User);

            Parametrage parametrage = loggedInUser.ParametrageNav;
            if (parametrage == null)
            {
                Parametrage newParametrage = new Parametrage()
                {
                    IdAspUser = loggedInUser.Id,
                    LangueBD = langueBD == null ? "" : langueBD,
                    FormatDate = FormatDate,
                    DecimalFormat = FormatDecimal,
                    SaveType = saveType
                };

                _identityC.Parametrage.Add(newParametrage);
                _identityC.SaveChanges();
            }
            else
            {
                parametrage.LangueBD = langueBD == null ? "" : langueBD;
                parametrage.FormatDate = FormatDate;
                parametrage.DecimalFormat = FormatDecimal;
                parametrage.SaveType = saveType;
                _identityC.SaveChanges();
            }

            var rqf = _contextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            var currentCulture =  rqf.RequestCulture.Culture.Name;
            string userCulture = (parametrage.LangueBD == "" || parametrage == null) ? currentCulture : parametrage.LangueBD;

                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(userCulture)),
        new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        }
);

       

            return LocalRedirect(Url.Content("/"));
        }




    }
}
