using SmartHive.Models;
using System.Collections.Generic;

namespace SmartHive.Services.Contracts
{
    public interface IHiveService
    {
        Hive GetHiveById(string id);

        IEnumerable<Hive> GetHivesByUsername(string username);

        IEnumerable<Hive> GetHivesByUser(User user);
    }
}
