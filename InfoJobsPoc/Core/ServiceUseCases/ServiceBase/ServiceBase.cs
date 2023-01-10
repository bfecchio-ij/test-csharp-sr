using InfoJobsPoc.Core.Interfaces.IRepository;
using System.Linq.Expressions;

namespace InfoJobsPoc.Core.ServiceUseCases.ServiceBase
{
    public abstract class ServiceBase<T> where T : class
    {
        private readonly IRepositoryWriteBase<T> repositoryWriteBase;

        protected ServiceBase(IRepositoryWriteBase<T> repositoryWriteBase)
        {
            this.repositoryWriteBase = repositoryWriteBase ?? throw new ArgumentNullException(nameof(repositoryWriteBase));
        }
        protected IQueryable<T> Find(Expression<Func<T, bool>> expression) => repositoryWriteBase.List().Where(expression).AsQueryable();
    }
}
