using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
namespace Polling
{
    public static class SMTPEngine
    {
        public static void SendEmail(string emailAdress, string emailBody)
        {
            try{
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("abhinavmedikonda1@gmail.com", "123123123123"),
                    EnableSsl = true
                };

                MailMessage mailMesage = new MailMessage(emailAdress, emailAdress, "test", emailBody);
                mailMesage.IsBodyHtml = true;

                client.Send(mailMesage);
            }
            catch(Exception e)
            {
            }
        }
    }
}