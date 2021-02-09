using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string About_me { get; set; }
        public string Instagram_link { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();

    }
}
