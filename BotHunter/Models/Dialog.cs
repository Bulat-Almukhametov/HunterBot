using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class Dialog
    {
        public Guid Id { get; set; }

        [DisplayName("Создал")]
        public User Creator { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        public string BlocksXml { get; set; }

        public string Aiml { get; set; }
    }
}