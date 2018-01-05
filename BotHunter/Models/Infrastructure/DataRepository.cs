using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class DataRepository : DbContext
    {
        public DataRepository() : base("DataContext") { }

        public DbSet<User> SysUsers { get; set; }
        public DbSet<Personality> Personalities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }

        public DbSet<DialogTopic> Topics { get; set; }
    }
}