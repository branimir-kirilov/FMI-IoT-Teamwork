using SmartHive.Models;
using SmartHive.Web.Models;

namespace SmartHive.Web.Factories
{
    public interface IViewModelFactory
    {
        //Hive
        ShortHiveViewModel CreateShortHiveViewModel(Hive hive);
    }
}
