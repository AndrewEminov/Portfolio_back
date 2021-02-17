using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        PortfolioContext db;

        public UserRepository(PortfolioContext context) : base(context)
        {
            db = context;
        }

        public async Task<User> GetPortfolio(string userEmail)
        {
            var userData = await db.Users
                .Include(e => e.Products)
                    .ThenInclude(e => e.Images)
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

        public async Task<bool> CheckUserByEmail(string email)
        {
            return await db.Users.AnyAsync(user => user.Email == email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await db.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
