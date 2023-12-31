using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.Common
{
    public class MailSender
    {
        public static void SendEmail(string email, string subject, string body)
        {
            //Mail Message
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("fener_fenere@outlook.com", "KareAjansi Hoşgeldiniz!");
            sender.Subject = subject;
            sender.Body = body;
            sender.BodyEncoding = Encoding.UTF8;
            sender.To.Add(email);

            //Smtp
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("fener_fenere@outlook.com", "DragonDragon123");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.EnableSsl = true;
            smtpClient.Send(sender);
        }
    }
}