using SmartHive.Models;
using SmartHive.Web.Models;
using SmartHive.Web.Models.Profile;

namespace SmartHive.Web.Factories
{
    public interface IViewModelFactory
    {
        //User profile
        UserProfileViewModel CreateUserProfileViewModel(User user);

        //Hive
        ShortHiveViewModel CreateShortHiveViewModel(Hive hive);
    }
}
