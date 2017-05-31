using PagedList;
using SmartHive.Authentication.Providers;
using SmartHive.Services.Contracts;
using SmartHive.Web.Factories;
using SmartHive.Web.Models.Hive;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SmartHive.Web.Areas.Administration.Controllers
{
    public class HivesAdministrationController : Controller
    {
        private readonly IAuthenticationProvider authProvider;
        private readonly IUserService userService;
        private readonly IHiveService hiveService;
        private readonly IViewModelFactory viewModelFactory;

        public HivesAdministrationController(
            IAuthenticationProvider authProvider,
            IUserService userService,
            IHiveService hiveService,
            IViewModelFactory viewModelFactory)
        {
            if (authProvider == null)
            {
                throw new ArgumentNullException(nameof(authProvider));
            }

            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (hiveService == null)
            {
                throw new ArgumentNullException(nameof(hiveService));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.authProvider = authProvider;
            this.userService = userService;
            this.hiveService = hiveService;
            this.viewModelFactory = viewModelFactory;
        }

        // GET: Administration/HivesAdministration
        public ActionResult Index(int page = 1, int count = 15)
        {
            var userId = this.authProvider.CurrentUserId;
            var hives = this.hiveService.GetAllHives().Select(p => this.viewModelFactory.CreateShortHiveViewModel(p));

            var model = hives.ToPagedList(page, count);

            return this.PartialView("_PagedHiveListPartial", model);
        }

        public ActionResult Add()
        {
            return View(this.viewModelFactory.CreateAddHiveViewModel());
        }

        // Post: Add
        [HttpPost]
        public ActionResult Add(AddHiveViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.userService.GetUserByUsername(model.Username).Id;

                var news = this.hiveService.CreateHive(model.Name, model.DataKey, userId);

                return RedirectToAction("Index", "HivesAdministration");
            }

            return View(model);
        }
    }
}