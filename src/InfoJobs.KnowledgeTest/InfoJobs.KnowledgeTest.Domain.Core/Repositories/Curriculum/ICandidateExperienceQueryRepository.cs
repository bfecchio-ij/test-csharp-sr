using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;

namespace InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum
{
    public interface ICandidateExperienceQueryRepository : IRepositoryQueryBase<CandidateExperienceEntity>
    {
        IEnumerable<CandidateExperienceEntity> ListByCandidate(int idCandidate);
    }
}