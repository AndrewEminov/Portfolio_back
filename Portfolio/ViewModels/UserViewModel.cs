using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string AboutMe { get; set; }
        public string InstagramLink { get; set; }
        public int? AvatarImageId { get; set; }
    }
}
