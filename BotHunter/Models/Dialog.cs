using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class Dialog: Entity
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Структура блоков")]
        public string BlocksXml { get; set; }

        [DisplayName("Сценарий диалога")]
        public string Aiml { get; set; }

        static Dialog()
        {
            GetInstance = () => new Dialog();
        }
    }
}