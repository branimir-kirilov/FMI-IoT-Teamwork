using System.ComponentModel.DataAnnotations;

namespace SmartHive.Models
{
    public class Hive
    {
        public Hive()
        {

        }

        public Hive(string name, string dataKey)
        {
            this.Name = name;
            this.DataKey = dataKey;
        }

        [Key]
        public int HiveId { get; set; }

        public string Name { get; set; }

        public string DataKey { get; set; }

    }
}
