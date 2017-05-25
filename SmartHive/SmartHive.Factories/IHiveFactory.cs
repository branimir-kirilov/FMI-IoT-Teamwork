using SmartHive.Models;

namespace SmartHive.Factories
{
    public interface IHiveFactory
    {
        Hive CreateHive(string name, string dataKey, string userId);
    }
}
