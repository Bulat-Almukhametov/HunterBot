﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
    }
}