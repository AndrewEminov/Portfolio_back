﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ModelsDTO;
using Portfolio.Services.Interfaces;
using Portfolio.ViewModels;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private IProtfolioService _portfolioService;
        private readonly IMapper _mapper;

        public PortfolioController(IProtfolioService portfolioService, IMapper mapper)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PortfolioViewModel>> Get(string email)
        {
            var portfolioDto = await _portfolioService.GetPortfolioData(email);

            if (portfolioDto == null)
            {
                return BadRequest("User is not found");
            }

            var portfolio = _mapper.Map<PortfolioViewModel>(portfolioDto);

            return portfolio;
        }

        [HttpPost("[action]")]
      //  [Authorize] // add access_token in header "Authorization": "Bearer " + access_token 
        public async Task<ActionResult<PortfolioViewModel>> Update(PortfolioViewModel data)
        {
            var portfolio = _mapper.Map<PortfolioDTO>(data);


            var updatePortfolioDto = await _portfolioService.UpdatePortfolioData(portfolio);

            return _mapper.Map<PortfolioViewModel>(updatePortfolioDto);
        }

        [HttpPost("[action]")]
      //  [Authorize] //  [Authorize(Roles = "admin")] need create for admin
        public async Task<ActionResult<SkillAppViewModel>> AddSkillApp(SkillAppViewModel data)
        {
            var skillApp = _mapper.Map<SkillAppDTO>(data);
            var newSkillApp = await _portfolioService.CreateSkillApp(skillApp);

            return _mapper.Map<SkillAppViewModel>(newSkillApp);
        }
    }
}
