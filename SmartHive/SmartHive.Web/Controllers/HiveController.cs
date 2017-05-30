using SmartHive.Authentication.Providers;
using SmartHive.Services.Contracts;
using System;
using System.Web.Mvc;
using PagedList;
using System.Linq;
using SmartHive.Web.Factories;

namespace SmartHive.Web.Controllers
{
    [Authorize]
    public class HiveController : Controller
    {
        private readonly IHiveService hiveService;
        private readonly IAuthenticationProvider authProvider;
        private readonly IViewModelFactory viewModelFactory;

        public HiveController(IHiveService hiveService, IAuthenticationProvider authProvider, IViewModelFactory viewModelFactory)
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
        public ActionResult All(int count = 5, int page = 1)
        {
            var hives = this.hiveService.GetHivesByUserId(this.authProvider.CurrentUserId).Select(p => this.viewModelFactory.CreateShortHiveViewModel(p));
            var model = hives.ToPagedList(count, page);

            return this.PartialView("_PagedHiveListPartial", model);
        }

        //// GET: Hive
        //public async System.Threading.Tasks.Task<ActionResult> Index()
        //{
        //    return View("index", await hiveService.GetHiveAsync($"uri"));
        //}
    }
}