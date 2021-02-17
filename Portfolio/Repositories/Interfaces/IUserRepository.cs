using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetPortfolio(string userEmail);
        public Task<User> UpdatePortfolio(User data);
        public Task<bool> CheckUserByEmail(string email);
        public Task<User> GetUserByEmail(string email);
    }
}
