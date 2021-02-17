using Portfolio.Models;
using Portfolio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public class SkillAppRepository : GenericRepository<SkillApp>, ISkillAppRepository
    {
        PortfolioContext db;

        public SkillAppRepository(PortfolioContext context) : base(context)
        {
            db = context;
        }


    }
}
