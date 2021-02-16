using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class PortfolioDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string AboutMe { get; set; }
        public string InstagramLink { get; set; }
        public string ImageUrl { get; set; }
        public List<ProductDTO> Products { get; set; }
        public List<SkillDTO> Skills { get; set; }
    }
}
