using SmartHive.Models;
using System.Collections.Generic;

namespace SmartHive.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        User GetUserById(string id);

        User GetUserByUsername(string username);
    }
}
