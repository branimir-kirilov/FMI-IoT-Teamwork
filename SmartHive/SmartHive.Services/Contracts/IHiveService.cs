using SmartHive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHive.Services.Contracts
{
    public interface IHiveService
    {
        Hive GetHiveById(string id);

        IEnumerable<Hive> GetHivesByUserId(string id);

        Hive CreateHive(string name, string dataKey, string userId);

        void EditHive(int id, string name, string dataKey);

        Task<List<Hive>> GetHiveAsync(string dataKey);
    }
}
