using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotHunter.Models
{
    public class Dialog: Entity
    {
        [Required(ErrorMessage = "Диалог должен иметь название")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Структура блоков")]
        [AllowHtml]
        public string BlocksXml { get; set; }

        [DisplayName("Сценарий диалога")]
        [AllowHtml]
        public string Aiml { get; set; }
        [DisplayName("Тема")]
        public DialogTopic Topic { get; set; }
        public Guid? TopicId { get; set; }

        static Dialog()
        {
            GetInstance = () => new Dialog();
        }
    }
}