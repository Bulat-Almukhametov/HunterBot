using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class DialogTopic
    {
        public Guid Id { get; set; }
        [DisplayName("Родительский элемент")]
        public DialogTopic Parent { get; set; }
        [DisplayName("Родительский элемент")]
        public Guid? ParentId { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Тип")]
        [DefaultValue(0)]
        public TopicType Type { get; set; }
    }
}