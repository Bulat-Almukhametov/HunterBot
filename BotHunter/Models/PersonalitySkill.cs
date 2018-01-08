using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BotHunter.Models
{
    public class PersonalitySkill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Personality Personality { get; set; }
        public Guid PersonalityId { get; set; }
        public Skill Skill { get; set; }
        public Guid SkillId { get; set; }
    }
}