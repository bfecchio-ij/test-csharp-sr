using InfoJobsPoc.Core.Interfaces.IRepository;
using InfoJobsPoc.Infra.Contexts;
using System.Linq.Expressions;

namespace InfoJobsPoc.Infra.QuerysInfra
{
    public class QueryInfraBase<T> : IQueryInfraBase<T> where T : class
    {
        private readonly PocContextQuery _db;

        public QueryInfraBase(PocContextQuery db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return _db.DisposeAsync();
        }

        public IQueryable<O> QueryList<O>(Expression<Func<T, bool>> expression, Func<T, O> parse)
        {
            return _db.Set<T>().Where(expression).Select(x => parse(x));
        }
        public IQueryable<O> QueryList<O>(Func<T, O> parse)
        {
            return _db.Set<T>().Select(x => parse(x));
        }
        public IQueryable<T> QueryList()
        {
            return _db.Set<T>().AsQueryable();
        }
    }
}
