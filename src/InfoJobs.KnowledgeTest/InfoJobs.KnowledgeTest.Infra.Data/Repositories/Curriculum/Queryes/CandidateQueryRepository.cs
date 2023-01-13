using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Infra.Data.Contexts;

namespace InfoJobs.KnowledgeTest.Infra.Data.Repositories.Curriculum.Queryes
{
    public sealed class CandidateQueryRepository : RepositoryQueryBase<CandidateEntity, CurriculumContext>, ICandidateQueryRepository
    {
        public CandidateQueryRepository(CurriculumContext context) : base(context)
        {
        }

        public bool EmailRegistered(string email)
        {
            return _context.Candidate
                           .Where(p => p.Email.Equals(email))
                           .Any();
        }
    }
}