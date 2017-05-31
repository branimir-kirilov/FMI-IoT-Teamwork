using PagedList;
using SmartHive.Authentication.Providers;
using SmartHive.Services.Contracts;
using SmartHive.Web.Factories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SmartHive.Web.Models.Account
{
    public class ProfileController : Controller
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IUserService userSerivce;
        private readonly IViewModelFactory viewModelFactory;

        public ProfileController(
            IAuthenticationProvider authenticationProvider, 
            IUserService userSerivce,
            IViewModelFactory viewModelFactory)
        {
            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (userSerivce == null)
            {
                throw new ArgumentNullException(nameof(userSerivce));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.authenticationProvider = authenticationProvider;
            this.userSerivce = userSerivce;
            this.viewModelFactory = viewModelFactory;
        }

        // GET: Profile
        public ActionResult UserProfile(string username)
        {
            var user = this.userSerivce.GetUserByUsername(username);

            var model = this.viewModelFactory.CreateUserProfileViewModel(user);

            return View(model);
        }

        public ActionResult AllUsers(int count = 5, int page =1)
        {
            var users = this.userSerivce.GetUsers().Select(u => this.viewModelFactory.CreateShortUserViewModel(u));

            var model = users.ToPagedList(page, count);

            return this.PartialView("_PagedUserListPartial", model);
        }
    }
}