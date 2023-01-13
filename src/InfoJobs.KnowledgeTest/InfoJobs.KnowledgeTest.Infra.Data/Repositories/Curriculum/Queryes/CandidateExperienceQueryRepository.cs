using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;

namespace InfoJobs.KnowledgeTest.Infra.Data.Repositories.Curriculum.Queryes
{
    public sealed class CandidateExperienceQueryRepository : RepositoryQueryBase<CandidateExperienceEntity, CurriculumContext>, ICandidateExperienceQueryRepository
    {
        public CandidateExperienceQueryRepository(CurriculumContext context) : base(context)
        {
        }

        public IEnumerable<CandidateExperienceEntity> ListByCandidate(int idCandidate)
        {
            return _context.CandidateExperience
                           .Where(p => p.IdCandidate.Equals(idCandidate))
                           .OrderByDescending(p => p.BeginDate)
                           .ToList();
        }
    }
}