using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TaxiApp.Network
{
    static class Network
    {
        public static void SendNotification(string receiveMail, string messageSubject, string messageBody)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("emiraslaneliyev12@gmail.com"); // sender email

            message.To.Add(new MailAddress(receiveMail));
            message.Subject = messageSubject;
            message.Body = messageBody;

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("emiraslaneliyev12@gmail.com", "isakamal10");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}