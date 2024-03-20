﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace EmailManagement
{
    public class Email
    {
        public string Subject { get; set; }
        public List<string> To { get; set; } = new List<string>();
        public List<string> CC { get; set; } = new List<string>();
        public List<string> BCC { get; set; } = new List<string>();
        public List<string> Attachements { get; set; } = new List<string>();
        public string Message { get; set; }
        public Email() { }
        public static void SendEmail(EmailClient _eClient, Email _mail)
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
                message.Subject = _mail.Subject;
                message.Body = _mail.Message;

                foreach (string _To in _mail.To) {
                    message.To.Add(_To);
                };

                foreach (string _CC in _mail.CC)
                {
                    message.CC.Add(_CC);
                };

                foreach (string _BCC in _mail.BCC)
                {
                    message.Bcc.Add(_BCC);
                };

                foreach (string attachmentPath in _mail.Attachements)
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
