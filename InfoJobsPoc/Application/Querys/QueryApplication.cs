using InfoJobsPoc.Application.Interfaces.IQuery;
using InfoJobsPoc.Core.Interfaces.IRepository;
using System.Linq.Expressions;

namespace InfoJobsPoc.Application.Querys
{
    public class QueryApplication<T> : IQueryApplication<T> where T : class
    {
        private readonly IQueryInfraBase<T> repository;

        public QueryApplication(IQueryInfraBase<T> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IQueryable<O> QueryList<O>(Expression<Func<T, bool>> expression, Func<T, O> parse)
        {
            return repository.QueryList(expression, parse);
        }

        public IQueryable<O> QueryList<O>(Func<T, O> parse)
        {
            return repository.QueryList(parse);
        }

        public IQueryable<T> QueryList()
        {
            return repository.QueryList();
        }
    }
}
