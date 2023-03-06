using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Repositories;
using InfoJobs.Infrastructure.Data.Repositories;
using InfoJobs.Migrations;

namespace InfoJobs.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InfoJobsDbContext _context;

        public UnitOfWork(InfoJobsDbContext context)
        {
            _context = context;
        }
        public ICandidateRepository Candidates => new CandidateRepository(_context);
        public IExperienceRepository Experiences => new ExperienceRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
