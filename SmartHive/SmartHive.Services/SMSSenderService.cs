using System.Diagnostics;
using System.Threading.Tasks;
using Twilio;

namespace SmartHive.Services
{
    public class SMSSenderService
    {
        private readonly string accountSid = "ACe1a461fd80cabc103810f2786edc6b97";
        private readonly string authToken = "5ebf770fda1fe337396ee6c2961da113n";
        private readonly string companyNumber = "+359898739493";

        public async Task SendAsync(string sendTo, string text)
        {
            TwilioRestClient twilio = new TwilioRestClient(accountSid, authToken);

            if (twilio != null)
            {
               twilio.SendMessage(companyNumber, sendTo, text);
            }
            else
            {
                Trace.TraceError("Failed to create a connection with twilio.");
                await Task.FromResult(0);
            }
        }
    }
}
