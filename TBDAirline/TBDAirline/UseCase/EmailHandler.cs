using System.Net.Mail;
using System.Net;
using TBDAirline.Models;

namespace TBDAirline.UseCase
{
    public static class EmailHandler
    {
        public static bool SendEmail(List<string> emails, Guid tracking)
        {
            bool success = true;
            try
            {
                if (emails == null || emails.Count == 0 || tracking == null) return false;
                foreach (var email in emails)
                {
                    var fromAddress = new MailAddress("cs380group5@gmail.com", "TBD Airline");
                    var toAddress = new MailAddress(email, "Customer");
                    const string fromPassword = "ComSci380";
                    const string subject = "Your Flight Reservation Confirmation";
                    string body = $"TrackingID: {tracking}. To track your flight, go to http://tbdairline.azurewebsites.net/Tracking";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
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
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

    }
}
