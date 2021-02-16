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
                .Include(e => e.Products)
                    .ThenInclude(e => e.ProductImages)
                .Include(e => e.Skills)
                    .ThenInclude(e => e.SkillApp)
                .FirstOrDefaultAsync(e => e.Email == userEmail);

            return userData;
        }

        public async Task<User> UpdatePortfolio(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
}
