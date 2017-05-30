using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SmartHive.Services
{
    public class SMSSenderService
    {
        private readonly string accountSid = "ACe1a461fd80cabc103810f2786edc6b97";
        private readonly string authToken = "5ebf770fda1fe337396ee6c2961da113";
        private readonly string companyNumber = "+18036755767";

        public void Send(string sendTo, string text)
        {
            TwilioClient.Init(accountSid, authToken);

            MessageResource.Create(
                from: new PhoneNumber(companyNumber),
                to: new PhoneNumber(sendTo),
                body: text
            );
        }
    }
}