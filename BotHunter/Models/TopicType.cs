using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public enum TopicType
    {
        [Display(Name = "По умолчанию")]
        Default,
        [Display(Name = "О компании")]
        Office,
        HR,
        [Display(Name = "Вопрос по специальности")]
        Technical
    }
}