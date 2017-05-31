using SmartHive.Services.Contracts;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SmartHive.Services
{
    public class SMSSenderService : ISMSSenderService
    {
        private readonly string accountSid = "ACe1a461fd80cabc103810f2786edc6b97";
        private readonly string authToken = "5ebf770fda1fe337396ee6c2961da113";
        private readonly string companyNumber = "+18036755767";

        public async Task SendAsync(string sendTo, string text)
        {
            try
            {
                TwilioClient.Init(accountSid, authToken);

                await MessageResource.CreateAsync(
                    from: new PhoneNumber(companyNumber),
                    to: new PhoneNumber(sendTo),
                    body: text
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }   
        }
    }
}