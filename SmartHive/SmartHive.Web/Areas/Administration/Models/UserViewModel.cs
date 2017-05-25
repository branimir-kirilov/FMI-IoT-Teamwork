using SmartHive.Models;

namespace SmartHive.Web.Areas.Administration.Models
{
    public class UserViewModel
    {
        public UserViewModel(User user, bool isAdministrator)
        {
            this.UserId = user.Id;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.IsAdministrator = isAdministrator;
        }
        public UserViewModel()
        {

        }

        public string UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
        
        public bool IsAdministrator { get; set; }
    }
}