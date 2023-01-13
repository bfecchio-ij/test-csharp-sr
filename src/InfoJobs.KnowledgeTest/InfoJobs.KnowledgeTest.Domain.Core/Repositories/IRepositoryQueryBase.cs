using System.Collections.Generic;

namespace InfoJobs.KnowledgeTest.Domain.Core.Repositories
{
    public interface IRepositoryQueryBase<TEntity> where TEntity : class
    {
        TEntity ById(int id);
        IEnumerable<TEntity> List();
    }
}