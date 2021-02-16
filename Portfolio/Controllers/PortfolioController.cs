using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Controllers.Infrastructure.Mappings;
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
        //[Authorize]
        public async Task<ActionResult<PortfolioViewModel>> Update(PortfolioViewModel data, string token)
        {
            var portfolio = _mapper.Map<PortfolioDTO>(data);


            var updatePortfolioDto = await _portfolioService.UpdatePortfolioData(portfolio);

            return _mapper.Map<PortfolioViewModel>(updatePortfolioDto);
        }

        [HttpPost("[action]")]
        //[Authorize] Admin
        public async Task<ActionResult<PortfolioViewModel>> AddSkillApp(SkillAppViewModel data)
        {
            var skillApp = _mapper.Map<SkillAppDTO>(data);

            var newSkillApp = await _portfolioService.CreateSkillApp(skillApp);

            return null; //_mapper.Map<PortfolioViewModel>(updatePortfolioDto);
        }
    }
}
