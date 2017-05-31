using SmartHive.Models;
using SmartHive.Services.JsonModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHive.Services.Contracts
{
    public interface IHiveService
    {
        Hive GetHiveById(int id);

        IEnumerable<Hive> GetHivesByUserId(string id);

        Hive CreateHive(string name, string dataKey, string userId);

        void EditHive(int id, string name, string dataKey);

        IList<JsonHive> GetHive(string dataKey);

        IEnumerable<Hive> GetAllHives();
    }
}
