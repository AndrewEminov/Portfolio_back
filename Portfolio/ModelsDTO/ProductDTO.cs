﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<string> ImagesData { get; set; } 
    }
}
