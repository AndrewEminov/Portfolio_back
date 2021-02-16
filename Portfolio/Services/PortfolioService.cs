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
    public class PortfolioService : IProtfolioService
    {
        private IUserRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public PortfolioService(IUserRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<PortfolioDTO> GetPortfolioData(string userEmail)
        {
            var userData = await _portfolioRepository.GetPortfolio(userEmail);

            if(userData == null)
            {
                return null; 
            }

            var user = _mapper.Map<PortfolioDTO>(userData);

            return user;
        }

        public async Task<PortfolioDTO> UpdatePortfolioData(PortfolioDTO data)
        {
            var user = _mapper.Map<User>(data);

            var userDataDTO = await _portfolioRepository.UpdatePortfolio(user);

            return _mapper.Map<PortfolioDTO>(userDataDTO); 
        }


        public async Task<SkillAppDTO> CreateSkillApp(SkillAppDTO data)
        {
            return null;
        }


    }
}
