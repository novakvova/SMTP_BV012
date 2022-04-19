using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSendEmail
{
    public class EmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;
        public EmailSender()
        {
            _emailConfiguration = new EmailConfiguration
            {
                From = "its222809@gmail.com",
                //From= "\"Josh Man\" <its222809@gmail.com",
                SmtpServer = "smtp.gmail.com",
                Port = 587,
                UserName = "its222809@gmail.com",
                Password = "Qwerty1_()8"
            };
        }

        public void SendMessage(Message message)
        {
            var msg = CreateEmailMessage(message);
            Send(msg);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message.Content;
            if(!string.IsNullOrEmpty(message.File))
                bodyBuilder.Attachments.Add(message.File);
            var emailMessage = new MimeMessage();
            //emailMessage.
            emailMessage.From.Add(new MailboxAddress("Stepan", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = bodyBuilder.ToMessageBody(); //new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            //emailMessage.HtmlBody = message.Content;
            
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port);
                    client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        } 
    }
}
