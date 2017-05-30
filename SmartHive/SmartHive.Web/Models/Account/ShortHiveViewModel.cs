using SmartHive.Models;

namespace SmartHive.Web.Models
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