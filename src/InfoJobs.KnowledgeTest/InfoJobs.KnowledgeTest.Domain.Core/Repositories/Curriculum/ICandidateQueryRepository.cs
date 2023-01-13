using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;

namespace InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum
{
    public interface ICandidateQueryRepository : IRepositoryQueryBase<CandidateEntity>
    {
        bool EmailRegistered(string email);
    }
}