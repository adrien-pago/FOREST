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
using EVF.DAL.Entity.EVF;
using Microsoft.EntityFrameworkCore;
using evf.Models.Customer;
using System.Drawing.Printing;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using evf.Models.User;
using Microsoft.AspNetCore.Authorization;

namespace evf.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrateur")]
    public class ManageCustomersController : Controller

    {
        private readonly ILogger<ManageCustomersController> _logger;
        private readonly EVFContext _context;
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly List<SocieteClient> _societeClient;
        private readonly List<Client> _clients;
        private readonly List<Personnel> _personnel;
        private readonly List<Societe> _societe;
        private readonly UserInfo _user;
        private readonly IStringLocalizer<ManageCustomersController> _stringLocalizer;

        public ManageCustomersController(ILogger<ManageCustomersController> logger, EVFContext context, UserManager<UserInfo> userManager, IStringLocalizer<ManageCustomersController> stringLocalizer, RoleManager<IdentityRole> rolesManager, SignInManager<UserInfo> signInManager, IHttpContextAccessor contextAccessor, IOptions<RequestLocalizationOptions> locOptions)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _rolesManager = rolesManager;
            _logger = logger;
            _stringLocalizer = stringLocalizer;
            _societeClient = _context.SocieteClients.Include(n => n.IdClientNavigation).Include(sc => sc.IdCommercialNavigation).Include(sc => sc.IdAssistantCommercialNavigation).ToList();
            _clients = _context.Clients.ToList();
            _personnel = _context.Personnel.ToList();
            _societe = _context.Societes.ToList();

        }


        // GET: ManageCustomersController
        public ActionResult CustomersList(int? page, int? idSoc)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            ListsViewModel listsModel = new ListsViewModel();
            List<SocieteModel> societesList = new List<SocieteModel>();


            // Liste des sociétés
            List<Societe> societeListBD = _context.Societes.ToList(); // from db

            foreach (var soc in societeListBD)
            {
                SocieteModel societe = new SocieteModel()
                {
                    IdSociete = soc.IdSociete,
                    CodeSociete = soc.CodeSociete
                };
                societesList.Add(societe);
            }



            List<CustomerModel> customersList = new List<CustomerModel>();

            int idSociete = idSoc ?? societesList.First().IdSociete;

            listsModel.IdSociete = idSociete;

            foreach (var societeC in _societeClient.Where(sc => sc.IdSociete == idSociete))
            {
                Client cust = _clients.FirstOrDefault(c => c.IdClient == societeC.IdClient);

                CustomerModel customer = new CustomerModel()
                {
                    CustomerCodeSAP = cust.CodeSap,
                    CustomerName = cust.Libelle,
                    AssistantName = _personnel.FirstOrDefault(p => p.IdPersonnel == societeC.IdAssistantCommercial).Nom,
                    SalespersonName = _personnel.FirstOrDefault(p => p.IdPersonnel == societeC.IdCommercial).Nom,
                    CodeSociete = societesList.FirstOrDefault(soc => soc.IdSociete == idSociete).CodeSociete,
                };
                customersList.Add(customer);
            }

            customersList = customersList.OrderBy(c => c.CustomerName).ToList();


            // Get liste des assistantes sans doublons
            List<CustomerModel> distinctAssistants = customersList.DistinctBy(c => c.AssistantName).ToList();

            List<SelectListItem> distinctAssistantsList = new List<SelectListItem>();


            foreach (var assistant in distinctAssistants)
            {
                distinctAssistantsList.Add(new SelectListItem()
                {
                    Value = assistant.AssistantName,
                    Text = assistant.AssistantName
                });
            }

            listsModel.DistinctAssistantList = distinctAssistantsList.OrderBy(c => c.Text).ToList();

            // Get liste des commerciaux sans doublons
            List<CustomerModel> distinctSalespeople = customersList.DistinctBy(c => c.SalespersonName).ToList();
            List<SelectListItem> distinctSalespeopleList = new List<SelectListItem>();

            foreach (var salespeople in distinctSalespeople)
            {
                distinctSalespeopleList.Add(new SelectListItem()
                {
                    Value = salespeople.SalespersonName,
                    Text = salespeople.SalespersonName
                });
            }

            listsModel.DistinctSalespeopleList = distinctSalespeopleList.OrderBy(s => s.Text).ToList();

            listsModel.CustomersList = new PagedList<CustomerModel>(customersList, pageNumber, pageSize);
            listsModel.CustomersListTotal = customersList.Count();
            listsModel.SocieteList = societesList;

            ViewData["sideBar.createUser"] = _stringLocalizer["sideBar.createUser"].Value;
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;

            return View(listsModel);
        }

        // GET: ManageCustomersController/Details/5
        public ActionResult FilteredCustomersList(string selectedAssistant, string selectedSalesperson, int? page, int idSoc)
        {
            ListsViewModel listsModel = new ListsViewModel();
            int pageSize = 10;
            int pageNumber = page ?? 1;

            List<CustomerModel> customersList = new List<CustomerModel>();

            foreach (var societeC in _societeClient.Where(sc => sc.IdSociete == idSoc))
            {
                Client cust = _clients.FirstOrDefault(c => c.IdClient == societeC.IdClient);

                CustomerModel customer = new CustomerModel()
                {
                    CustomerCodeSAP = cust.CodeSap,
                    CustomerName = cust.Libelle,
                    AssistantName = _personnel.FirstOrDefault(p => p.IdPersonnel == societeC.IdAssistantCommercial).Nom,
                    SalespersonName = _personnel.FirstOrDefault(p => p.IdPersonnel == societeC.IdCommercial).Nom,
                    CodeSociete = _societe.FirstOrDefault(s => s.IdSociete == societeC.IdSociete).CodeSociete,
                };
                customersList.Add(customer);
            }

            customersList = customersList.OrderBy(c => c.CustomerName).ToList();

            // Get liste des assistantes sans doublons
            List<CustomerModel> distinctAssistants = customersList.DistinctBy(c => c.AssistantName).ToList();

            List<SelectListItem> distinctAssistantsList = new List<SelectListItem>();


            foreach (var assistant in distinctAssistants)
            {
                distinctAssistantsList.Add(new SelectListItem()
                {
                    Value = assistant.AssistantName,
                    Text = assistant.AssistantName
                });
            }

            listsModel.DistinctAssistantList = distinctAssistantsList.OrderBy(c => c.Text).ToList();

            // Get liste des commerciaux sans doublons
            List<CustomerModel> distinctSalespeople = customersList.DistinctBy(c => c.SalespersonName).ToList();
            List<SelectListItem> distinctSalespeopleList = new List<SelectListItem>();

            foreach (var salespeople in distinctSalespeople)
            {
                distinctSalespeopleList.Add(new SelectListItem()
                {
                    Value = salespeople.SalespersonName,
                    Text = salespeople.SalespersonName
                });
            }

            listsModel.DistinctSalespeopleList = distinctSalespeopleList.OrderBy(s => s.Text).ToList();


            if (selectedAssistant != "4")
            {
                customersList = customersList.Where(c => c.AssistantName.Equals(selectedAssistant)).ToList();
            }

            if (selectedSalesperson != "4")
            {
                customersList = customersList.Where(c => c.SalespersonName.Equals(selectedSalesperson)).ToList();
            }

            listsModel.CustomersList = new PagedList<CustomerModel>(customersList, pageNumber, pageSize);
            listsModel.CustomersListTotal = customersList.Count();
            listsModel.SelectedAssistant = selectedAssistant;
            listsModel.SelectedSalesperson = selectedSalesperson;

            ViewData["sideBar.createUser"] = _stringLocalizer["sideBar.createUser"].Value;
            ViewData["sideBar.customers"] = _stringLocalizer["sideBar.customers"].Value;
            ViewData["sideBar.listCustomers"] = _stringLocalizer["sideBar.listCustomers"].Value;
            ViewData["sideBar.listExistingUsers"] = _stringLocalizer["sideBar.listExistingUsers"].Value;
            ViewData["sideBar.users"] = _stringLocalizer["sideBar.users"].Value;


            return PartialView("_FilterCustomersListView", listsModel);
        }

        // GET: ManageCustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageCustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageCustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageCustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageCustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageCustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
