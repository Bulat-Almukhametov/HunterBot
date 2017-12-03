using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class Skill :Entity
    {
        public Personality Personality { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        static Skill()
        {
            GetInstance = () => new Skill();
        }
    }
}