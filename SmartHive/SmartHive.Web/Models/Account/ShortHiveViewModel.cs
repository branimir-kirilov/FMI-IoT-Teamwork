using SmartHive.Models;

namespace SmartHive.Web.Models.Account
{
    public class ShortHiveViewModel
    {
        public ShortHiveViewModel(Hive hive)
        {
            this.Name = hive.Name;
        }

        public string Name { get; set; }
        
    }
}