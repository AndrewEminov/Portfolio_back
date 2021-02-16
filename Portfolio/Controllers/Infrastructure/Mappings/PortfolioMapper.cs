using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Portfolio.ModelsDTO;

namespace Portfolio.Controllers.Infrastructure.Mappings
{
    public class PortfolioMapper : Profile
    {
        public PortfolioMapper ()
        {
            CreateMap<PortfolioViewModel, PortfolioDTO>().ReverseMap();
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<SkillViewModel, SkillDTO>().ReverseMap();
            CreateMap<ProductImageViewModel, ProductImageDTO>().ReverseMap();
            CreateMap<SkillAppViewModel, SkillAppDTO>().ReverseMap();
        }
    }
}
