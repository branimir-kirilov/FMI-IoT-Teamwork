using System.Net.Mail;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace SmartHive.Services
{
    public class EmailService : IEmailService
    {
        private readonly string companyEmail = "smarthivebg@gmail.com";
        private readonly string password = "123456smart";
        public async Task SendAsync(string sendTo, string subject, string body)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(companyEmail);
            mail.To.Add(sendTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(companyEmail, password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
