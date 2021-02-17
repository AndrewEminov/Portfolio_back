using AutoMapper;
using Portfolio.Models;
using Portfolio.ModelsDTO;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers.Infrastructure.Mappings
{
    public class SkillMapperService : Profile
    {
        public SkillMapperService()
        {
            CreateMap<SkillAppDTO, SkillApp>().ReverseMap();
        }
    }
}