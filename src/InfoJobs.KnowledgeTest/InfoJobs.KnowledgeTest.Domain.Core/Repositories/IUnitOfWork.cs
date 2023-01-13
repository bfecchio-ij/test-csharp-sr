namespace InfoJobs.KnowledgeTest.Domain.Core.Repositories
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        void Commit();
    }
}