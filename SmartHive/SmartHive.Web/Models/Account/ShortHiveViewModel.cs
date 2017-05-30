using SmartHive.Models;

namespace SmartHive.Web.Models
{
    public class ShortHiveViewModel
    {
        public ShortHiveViewModel(Hive hive)
        {
            this.Name = hive.Name;
            this.Id = hive.HiveId;
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }
}