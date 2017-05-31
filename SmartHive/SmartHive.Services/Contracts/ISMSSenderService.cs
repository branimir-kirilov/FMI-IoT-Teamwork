using System.Threading.Tasks;

namespace SmartHive.Services.Contracts
{
    public interface ISMSSenderService
    {
        Task SendAsync(string sendTo, string text);
    }
}
