using SmartHive.Authentication.Providers;
using SmartHive.Services.Contracts;
using SmartHive.Web.Factories;
using System;
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
    }
}