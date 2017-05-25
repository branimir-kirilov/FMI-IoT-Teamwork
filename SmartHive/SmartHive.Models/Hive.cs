using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHive.Models
{
    public class Hive
    {
        public Hive()
        {

        }

        public Hive(string name, string dataKey, string userId)
        {
            this.Name = name;
            this.DataKey = dataKey;
            this.UserId = userId;
        }

        [Key]
        public int HiveId { get; set; }

        public string Name { get; set; }

        public string DataKey { get; set; }

        [ForeignKey("Owner")]
        public string UserId { get; set; }

        public virtual User Owner { get; set; }
    }
}
