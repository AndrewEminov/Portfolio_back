using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Portfolio.ModelsDTO;
using Portfolio.Models;

namespace Portfolio.Controllers.Infrastructure.Mappings
{
    public class PortfolioMapperService : Profile
    {
        public PortfolioMapperService()
        {            
            CreateMap<Skill, SkillDTO>().ReverseMap(); 
            CreateMap<Product, ProductDTO>().ReverseMap(); 

            CreateMap<User, PortfolioDTO>()
                //.ForMember(e => e.Skills.Select(e => e.SkillVal), opt => opt.MapFrom(e => e.Skills.Select(e => e.SkillVal)))
                .ForMember(e => e.Skills, opt => opt.MapFrom(e => e.Skills))
                .ForMember(e => e.Products, opt => opt.MapFrom(e => e.Products))
                .ForMember(e => e.ImageUrl, opt => opt.MapFrom(e => e)) // e.AvatarImageId or user.ImageUrl = //userData.AvatarImageId
                .ReverseMap();

            CreateMap<ProductImage, ProductImageDTO>()
                .ForMember(e => e.Url, opt => opt.MapFrom(e => e)) //e.Id
                .ReverseMap();

            CreateMap<SkillApp, SkillAppDTO>()
                .ForMember(e => e.SkillImageUrl, opt => opt.MapFrom(e => e)) // e.SkillImageId
                .ReverseMap();
        }
    }
}
