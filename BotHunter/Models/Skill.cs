using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public Personality Personality { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}