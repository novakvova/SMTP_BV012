using System;
using System.Collections.Generic;

namespace ClassSendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSender sender = new EmailSender();

            Message message = new Message(
                new List<string> { "voboke5632@aikusy.com", 
                    "novakvova@gmail.com", "vinnichukpetro@gmail.com" },
                "Усім привіт -",
                "Нарешті прийшла весна. Стало тепло і весело. +",
                @"files\1.jpg"
                );

            sender.SendMessage(message);
        }
    }
}
