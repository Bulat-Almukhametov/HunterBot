using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class Personality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telegram { get; set; }
        public string Phone { get; set; }
    }
}