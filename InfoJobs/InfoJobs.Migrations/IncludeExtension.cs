using InfoJobs.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace InfoJobs.Migrations
{
    public class IncludeExtension
    {
        private readonly InfoJobsDbContext _context;
        private readonly DbSet<Candidate> _dbSet;

        public IncludeExtension(InfoJobsDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Candidate>();
        }
        public IQueryable<Candidate> Include(params Expression<Func<Candidate, object>>[] includes)
        {
            IIncludableQueryable<Candidate, object> query = null;

            if (includes.Length > 0)
            {
                query = _dbSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? _dbSet : (IQueryable<Candidate>)query;
        }

    }
}
