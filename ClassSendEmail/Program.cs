using System;
using System.Collections.Generic;
using System.IO;

namespace ClassSendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "";
            using (FileStream fs = new FileStream("16/index.html", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    content = sr.ReadToEnd();
                }
            }
            EmailSender sender = new EmailSender();

            Message message = new Message(
                new List<string> { "voboke5632@aikusy.com", "novakvova@gmail.com", "vinnichukpetro@gmail.com" },
                "Усім привіт -",
                content,
                @"files\1.jpg"
                );

            sender.SendMessage(message);
        }
    }
}
