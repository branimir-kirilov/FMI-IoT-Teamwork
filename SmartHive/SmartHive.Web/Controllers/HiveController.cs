using SmartHive.Authentication.Providers;
using SmartHive.Services.Contracts;
using System;
using System.Web.Mvc;
using PagedList;
using System.Linq;
using SmartHive.Web.Factories;
using SmartHive.Web.Models;
using System.Collections.Generic;

namespace SmartHive.Web.Controllers
{
    [Authorize]
    public class HiveController : Controller
    {
        private readonly IHiveService hiveService;
        private readonly IAuthenticationProvider authProvider;
        private readonly IViewModelFactory viewModelFactory;

        public HiveController(
            IHiveService hiveService,
            IAuthenticationProvider authProvider,
            IViewModelFactory viewModelFactory)
        {
            if (hiveService == null)
            {
                throw new ArgumentNullException(nameof(hiveService));
            }

            if (authProvider == null)
            {
                throw new ArgumentNullException(nameof(authProvider));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.hiveService = hiveService;
            this.authProvider = authProvider;
            this.viewModelFactory = viewModelFactory;
        }


        //GET: All
        public ActionResult All(int count = 3, int page = 1)
        {
            var userId = this.authProvider.CurrentUserId;
            var hives = this.hiveService.GetHivesByUserId(userId).Select(p => this.viewModelFactory.CreateShortHiveViewModel(p));

            var model = hives.ToPagedList(page, count);

            return this.PartialView("_PagedHiveListPartial", model);
        }

        // GET: Hive
        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            return View("Details", hiveService.GetHive($"EXO847SOXW7L55HJ&results=3"));
        }
    }
}