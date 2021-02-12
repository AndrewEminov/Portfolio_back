using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ModelsDTO;
using Portfolio.Services.Interfaces;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private IUserService _portfolioService;

        public PortfolioController(IUserService portfolioService)
        {
            _portfolioService = portfolioService;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<PortfolioViewModel>> Get(string email)
        {
            var portfolioDto = await _portfolioService.GetPortfolioData(email);

            if (portfolioDto == null)
            {
                return BadRequest("User is not found");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PortfolioDTO, PortfolioViewModel>());
            var mapper = new Mapper(config);
            var portfolio = mapper.Map<PortfolioViewModel>(portfolioDto);

            return portfolio;
        }

        [HttpPost("[action]")]
        //[Authorize]

        public async Task<ActionResult<PortfolioViewModel>> Update(PortfolioViewModel data, string token)
        {
            var userConfig = new MapperConfiguration(cfg => cfg.CreateMap<PortfolioViewModel, UserDTO>()
               .ForMember(e => e.About_me, opt => opt.MapFrom(e => e.AboutAuthor))
            );
            var userMapper = new Mapper(userConfig);
            var user = userMapper.Map<UserDTO>(data);

            var portfolioConfig = new MapperConfiguration(cfg => cfg.CreateMap<PortfolioViewModel, ProductDTO>()
               .ForMember(e => e.Description, opt => opt.MapFrom(e => e.Products.Select(e => e.Description)))
               .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Products.Select(e => e.Name)))
               .ForMember(e => e.ImagesData, opt => opt.MapFrom(e => e.Products.Select(e => e.ImagesData)))
               .ForMember(e => e.Link, opt => opt.MapFrom(e => e.Products.Select(e => e.Link)))
            );

            var portfolioMapper = new Mapper(portfolioConfig);
            var portfolio = portfolioMapper.Map<ProductDTO>(data);

            var imageConfig = new MapperConfiguration(cfg => cfg.CreateMap<PortfolioViewModel, ImageDTO>()
               .ForMember(e => e. , opt => opt.MapFrom(e => e. ))
            );
            var imageMapper = new Mapper(imageConfig);
            var image = imageMapper.Map<ImageDTO>(data);

            /*var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Skill, SkillDTO>()
                    .ForMember(e => e.ImageData, opt => opt.MapFrom(e => e.Image.Id));

                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(e => e.ImagesData, opt => opt.MapFrom(e => e.Images.Select(e => e.Id).ToList()));

                cfg.CreateMap<User, PortfolioDTO>()
                    .ForMember(e => e.AboutAuthor, opt => opt.MapFrom(e => e.About_me))
                    .ForMember(e => e.Skills, opt => opt.MapFrom(e => e.Images.Select(e => e.Skill)))
                    .ForMember(e => e.Products, opt => opt.MapFrom(e => e.Images.Select(e => e.Products)));
            });*/





            return null;
        }
    }
}
