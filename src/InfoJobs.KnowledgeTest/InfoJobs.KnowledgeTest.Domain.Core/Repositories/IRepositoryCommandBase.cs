namespace InfoJobs.KnowledgeTest.Domain.Core.Repositories
{
    public interface IRepositoryCommandBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
    }
}