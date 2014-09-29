using System.Net;
using System.Net.Mail;

namespace SendingEmail
{
    public class EmailServer
    {
        public void SendEmail(string from, string to, string subject, string body)
        {
            var fromAddress = new MailAddress(from);
            var toAddress = new MailAddress(to);

            var smtp = new SmtpClient
            {
                //dummy data
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

    }
}
