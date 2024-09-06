using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace shop.Services
{
    public static class EmailSenderService
    {
        public static async Task SendEmail(string UserMail, string Subject, string Text)
        {
            MailAddress from = new MailAddress("rwrdkdywencka2@gmail.com", "Shop ToysNow");
            MailAddress to = new MailAddress(UserMail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = Subject;
            message.Body = Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("rwrdkdywencka2@gmail.com", "nyacxvedyinsiczi");
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            await smtp.SendMailAsync(message);
        }
        public static async Task SendEmailFromUser(string UserMail, string UserName, string Text)
        {
            MailAddress from = new MailAddress("rwrdkdywencka2@gmail.com", "Письмо от пользователя");
            MailAddress to = new MailAddress(UserMail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = UserName;
            message.Body = Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("rwrdkdywencka2@gmail.com", "nyacxvedyinsiczi");//brxsDXj6NHRxV24
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            await smtp.SendMailAsync(message);
        }
    }
}
