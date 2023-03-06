using InfoJobs.Domain.Data.Repositories;

namespace InfoJobs.Domain.Data
{
    public interface IUnitOfWork
    {
        ICandidateRepository Candidates { get; }
        IExperienceRepository Experiences { get; }
        Task CommitAsync();
    }
}
