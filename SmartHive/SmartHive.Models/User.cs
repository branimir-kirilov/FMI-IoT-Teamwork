using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartHive.Models
{
    public class User : IdentityUser
    {
        private ICollection<Hive> Hives;

        public User() : base(string.Empty)
        {
            this.HiveCollection = new HashSet<Hive>();
        }

        public User(string username, string email, string name, string description)
        {
            this.UserName = username;
            this.Email = email;
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Hive> HiveCollection
        {
            get { return this.Hives; }
            set { this.Hives = value; }
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
