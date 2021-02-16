using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SkillAppId { get; set; }
        public int SkillVal { get; set; }
        public User User { get; set; }
        public SkillApp SkillApp { get; set; }
    }
}
