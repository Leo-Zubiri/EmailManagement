using System;
using System.Net;
using System.Net.Mail;

namespace EmailManagement
{
    public static class Email
    {
        public static void SendEmail(EmailClient _eClient, EmailContent _eContent)
        {
            // Set up the SMTP client
            using (SmtpClient client = new SmtpClient(_eClient.smtpClient))
            {
                client.Port = _eClient.port; // Specify the SMTP port number
                client.Credentials = new NetworkCredential(_eClient.user, _eClient.password);
                client.EnableSsl = _eClient.enableSSL; // Enable SSL if required

                // Create the email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_eClient.user);
                message.Subject = _eContent.Subject;
                message.Body = _eContent.Message;

                foreach (string _To in _eContent.To) {
                    message.To.Add(_To);
                };

                foreach (string _CC in _eContent.CC)
                {
                    message.CC.Add(_CC);
                };

                foreach (string _BCC in _eContent.BCC)
                {
                    message.Bcc.Add(_BCC);
                };

                foreach (string attachmentPath in _eContent.Attachements)
                {
                    message.Attachments.Add(new Attachment(attachmentPath));
                };

                try
                {
                    // Send the email
                    client.Send(message);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to send email: " + ex.Message);
                }
                finally
                {
                    // Dispose of the email message and attachments
                    message.Dispose();
                    foreach (Attachment attachment in message.Attachments)
                    {
                        attachment.Dispose();
                    }
                }
            }
        }
    }
}
