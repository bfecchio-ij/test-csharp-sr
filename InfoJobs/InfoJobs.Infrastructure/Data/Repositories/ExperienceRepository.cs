using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.Data.Repositories;
using InfoJobs.Infrastructure.Data.Repositories.Generic;
using InfoJobs.Migrations;
using Microsoft.EntityFrameworkCore;

namespace InfoJobs.Infrastructure.Data.Repositories
{
    public class ExperienceRepository : Repository<Experience>, IExperienceRepository
    {
        private readonly InfoJobsDbContext _context;
        private readonly DbSet<Experience> _dbSet;

        public ExperienceRepository(InfoJobsDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Experience>();
        }

        public IQueryable<Experience> GetExperienceByCandidadeId(object id)
        {
            return _dbSet.Where(c => c.CandidateId == (int)id);
        }
    }
}
