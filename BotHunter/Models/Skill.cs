using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class Skill :Entity
    {
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание навыка")]
        public string Description { get; set; }

        static Skill()
        {
            GetInstance = () => new Skill();
        }
    }
}