using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.Data.Repositories;
using InfoJobs.Infrastructure.Data.Repositories.Generic;
using InfoJobs.Migrations;

namespace InfoJobs.Infrastructure.Data.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(InfoJobsDbContext context) : base(context)
        {
        }
    }
}
