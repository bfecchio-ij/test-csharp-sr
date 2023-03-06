using InfoJobs.Domain.Data.Entities;

namespace InfoJobs.Domain.Data.Repositories
{
    public interface IExperienceRepository : IRepository<Experience>
    {
        IQueryable<Experience> GetExperienceByCandidadeId(object id);
    }
}
