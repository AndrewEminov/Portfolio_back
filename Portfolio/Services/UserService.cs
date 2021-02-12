using AutoMapper;
using Portfolio.Models;
using Portfolio.ModelsDTO;
using Portfolio.Repositories.Interfaces;
using Portfolio.Services.Interfaces;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _portfolioRepository;

        public UserService(IUserRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<PortfolioDTO> GetPortfolioData(string userEmail)
        {
            var userData = await _portfolioRepository.GetPortfolio(userEmail);

            if(userData == null)
            {
                return null;
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Skill, SkillDTO>()
                    .ForMember(e => e.ImageData, opt => opt.MapFrom(e => e.Image.Id));

                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(e => e.ImagesData, opt => opt.MapFrom(e => e.Images.Select(e => e.Id).ToList()));

                cfg.CreateMap<User, PortfolioDTO>()
                    .ForMember(e => e.AboutAuthor, opt => opt.MapFrom(e => e.About_me))
                    .ForMember(e => e.Skills, opt => opt.MapFrom(e => e.Images.Select(e => e.Skill)))
                    .ForMember(e => e.Products, opt => opt.MapFrom(e => e.Images.Select(e => e.Products)));
            });

            var mapper = new Mapper(config);

            PortfolioDTO user = mapper.Map<User, PortfolioDTO>(userData);

            return user;
        }

        public Task<bool> UpdateUserData(UserDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
