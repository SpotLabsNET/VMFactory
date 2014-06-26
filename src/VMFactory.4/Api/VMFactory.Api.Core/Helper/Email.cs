using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace VMFactory.Api.Core.Helper
{
    public class Email
    {

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="smtpServer">The SMTP server.</param>
        /// <param name="fromEmail">From email.</param>
        /// <param name="destinationEmail">The destination email.</param>
        /// <param name="subsect">The subsect.</param>
        /// <param name="emailBody">The email body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> [is body HTML].</param>
        /// <param name="smtPCredentials">The SMT application credentials.</param>
        public static void SendEmail(string smtpServer, string fromEmail, string destinationEmail, string subsect, string emailBody, NetworkCredential smtPCredentials, bool isBodyHtml = true) {  try { using (SmtpClient SmtpServer = new SmtpClient(smtpServer)) { MailMessage mail = new MailMessage();  mail.From = new MailAddress(fromEmail); mail.To.Add(destinationEmail); mail.Subject = subsect; mail.IsBodyHtml = isBodyHtml; mail.Body = emailBody; SmtpServer.EnableSsl = true; SmtpServer.Credentials = smtPCredentials;  ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };  SmtpServer.Send(mail); } } catch (Exception e) { Api.Core.Exceptions.ExceptionManager.HandleException(e); }  }




    }
}
