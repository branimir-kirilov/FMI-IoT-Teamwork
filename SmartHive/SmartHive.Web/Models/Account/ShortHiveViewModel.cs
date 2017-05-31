using SmartHive.Models;

namespace SmartHive.Web.Models
{
    public class ShortHiveViewModel
    {
        public ShortHiveViewModel(Hive hive)
        {
            this.Name = hive.Name;
            this.Id = hive.HiveId;
            this.isInFunction = (hive.DataKey != null) ? true : false;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public bool isInFunction { get; set; }
    }
}