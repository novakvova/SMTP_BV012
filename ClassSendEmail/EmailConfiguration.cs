using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSendEmail
{
    public class EmailConfiguration
    {
        //Хто відправляє листа
        public string From { get; set; }
        //Який сервер використовуємо
        public string SmtpServer { get; set; }
        //порт, який буде використовуватися для SMTP
        public int Port { get; set; }
        //Користувач для доступу до сервера SMTP
        public string UserName { get; set; }
        //Пароль
        public string Password { get; set; }
    }
}
