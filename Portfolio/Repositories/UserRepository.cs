using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class UserRepository : IUserRepository
    {
        PortfolioContext db;

        public UserRepository(PortfolioContext context)
        {
            db = context;
        }

        public async Task<User> GetPortfolio(string userEmail)
        {

           var userData = await db.Users
                .Include(e => e.Images)
                    .ThenInclude(e => e.Products)
                        .ThenInclude(e => e.Images)
                .Include(e => e.Images)
                    .ThenInclude(e => e.Skill)
                .FirstOrDefaultAsync(e => e.Email == userEmail);

            return userData;
        }
    }
}
