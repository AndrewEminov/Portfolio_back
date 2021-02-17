using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class ProductViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}
