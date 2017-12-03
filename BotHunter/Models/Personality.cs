using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
        public class Personality: Entity
    {
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Электронная почта")]
        public string Email { get; set; }
        [DisplayName("Номер телеграм")]
        public string Telegram { get; set; }
        [DisplayName("Номер телефона")]
        public string Phone { get; set; }

        static Personality()
        {
            GetInstance = () => new Personality();
        }
    }
}