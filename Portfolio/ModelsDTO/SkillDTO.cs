﻿using Portfolio.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewModels
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public int SkillVal { get; set; }
        public SkillAppDTO SkillApp { get; set; }

    }
}
