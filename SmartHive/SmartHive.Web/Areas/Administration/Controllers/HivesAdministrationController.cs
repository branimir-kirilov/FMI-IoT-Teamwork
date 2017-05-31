using SmartHive.Authentication.Providers;
using SmartHive.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHive.Web.Areas.Administration.Controllers
{
    public class HivesAdministrationController : Controller
    {
        private readonly IAuthenticationProvider authProvider;
        private readonly IUserService userService;
        private readonly IHiveService hiveService;

        public HivesAdministrationController(
            IAuthenticationProvider authProvider,
            IUserService userService,
            IHiveService hiveService)
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

            this.authProvider = authProvider;
            this.userService = userService;
            this.hiveService = hiveService;
        }

        // GET: Administration/HivesAdministration
        public ActionResult Index(int page = 1, int count = 15)
        {
            var users = this.userService.GetUsers();

            var model = new List<UserViewModel>();

            foreach (var user in users)
            {
                var isAdmin = this.authProvider.IsInRole(user.Id, "Administrator");
                var viewModel = new UserViewModel(user, isAdmin);
                model.Add(viewModel);
            }

            return this.View(model.ToPagedList(page, count));
        }
    }
}