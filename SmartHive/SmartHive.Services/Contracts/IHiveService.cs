using SmartHive.Models;
using System.Collections.Generic;

namespace SmartHive.Services.Contracts
{
    public interface IHiveService
    {
        Hive GetHiveById(string id);

        IEnumerable<Hive> GetHivesByUserId(string id);
    }
}
