using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class PortfolioViewModel
    {
        public string Name { get; set; }
        public string Sername { get; set; }
        public string AboutAuthor { get; set; }
        public string Instagram_link { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<SkillViewModel> Skills { get; set; }

    }
}
