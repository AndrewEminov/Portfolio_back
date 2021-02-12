using Microsoft.AspNetCore.Mvc;
using Portfolio.ModelsDTO;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services.Interfaces
{
    public interface IUserService
    {
        public Task<PortfolioDTO> GetPortfolioData(string email);
        public Task<bool> UpdateUserData(UserDTO data);
    }
}
