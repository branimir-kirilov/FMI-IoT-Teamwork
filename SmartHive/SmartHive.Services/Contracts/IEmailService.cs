using System.Threading.Tasks;

namespace SmartHive.Services.Contracts
{
    public interface IEmailService
    {
        Task SendAsync(string sendTo, string subject, string body);
    }
}
