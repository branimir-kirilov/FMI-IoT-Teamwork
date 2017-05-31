namespace SmartHive.Services.Contracts
{
    public interface ISMSSenderService
    {
        void Send(string sendTo, string text);
    }
}
