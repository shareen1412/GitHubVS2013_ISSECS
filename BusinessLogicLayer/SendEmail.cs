using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BusinessLogicLayer
{
    class SendEmail
    {
        static void Main(string[] args)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpC = new SmtpClient("smtp.gmail.com");
                //From address to send email
                mail.From = new MailAddress("from@gmail.com");
                //To address to send email
                mail.To.Add("suju4eva060396@gmail.com");
                mail.Body = "This is a test mail from C# program";
                mail.Subject = "TEST";
                smtpC.Port = 587;
                //Credentials for From address
                smtpC.Credentials = new System.Net.NetworkCredential("EmailID", "password");
                smtpC.EnableSsl = true;
                smtpC.Send(mail);
                Console.WriteLine("Message sent successfully");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                Console.ReadLine();
            }
        }
    }
}
