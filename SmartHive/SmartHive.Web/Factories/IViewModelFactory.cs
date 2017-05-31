using SmartHive.Models;
using SmartHive.Web.Models;
using SmartHive.Web.Models.Profile;

namespace SmartHive.Web.Factories
{
    public interface IViewModelFactory
    {
        //User profiles
        UserProfileViewModel CreateUserProfileViewModel(User user);

        ShortUserViewModel CreateShortUserViewModel(User user);

        //Hive
        ShortHiveViewModel CreateShortHiveViewModel(Hive hive);
    }
}
