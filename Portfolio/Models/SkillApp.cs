using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class SkillApp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SkillImageId { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
