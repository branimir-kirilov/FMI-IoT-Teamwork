using SmartHive.Models;

namespace SmartHive.Web.Models.Profile
{
    public class ShortUserViewModel
    {
        public ShortUserViewModel(User user)
        {
            this.UserName = user.UserName;
            this.Name = user.Name;
        }

        public ShortUserViewModel()
        {

        }

        public string UserName { get; set; }
        public string Name { get; set; }
    }
}