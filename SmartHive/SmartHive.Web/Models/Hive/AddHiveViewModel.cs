using System.ComponentModel.DataAnnotations;

namespace SmartHive.Web.Models.Hive
{
    public class AddHiveViewModel
    {
        public AddHiveViewModel()
        {

        }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "DataKey")]
        public string DataKey { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}