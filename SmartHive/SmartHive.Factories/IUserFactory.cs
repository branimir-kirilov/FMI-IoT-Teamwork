using SmartHive.Models;

namespace SmartHive.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username, string email, string name, string description, string phoneNumber);
    }
}
