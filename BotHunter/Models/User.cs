using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BotHunter.Models
{
    public class User
    {
        [DisplayName("Идентификатор")]
        public Guid Id { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

    }
}