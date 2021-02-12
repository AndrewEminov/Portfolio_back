using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public string Name { get; set; }
        public bool Avatar_key { get; set; }
        public User User { get; set; }  // User for images
        public Skill Skill { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        //public string Path { get; set; }
    }
}
