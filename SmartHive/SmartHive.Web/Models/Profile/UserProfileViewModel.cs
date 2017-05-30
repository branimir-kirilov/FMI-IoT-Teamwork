using SmartHive.Models;

namespace SmartHive.Web.Models.Profile
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel(User user)
        {
            this.Id = user.Id;
            this.Username = user.UserName;
            this.Name = user.Name;
            this.Email = user.Email;
            this.Description = user.Description;
            this.PhoneNumber = user.PhoneNumber;
        }

        public UserProfileViewModel()
        {

        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}