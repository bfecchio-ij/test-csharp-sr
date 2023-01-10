using System.Linq.Expressions;

namespace InfoJobsPoc.Core.Interfaces.IRepository
{
    public interface IQueryInfraBase<T> : IAsyncDisposable, IDisposable where T : class
    {
        IQueryable<O> QueryList<O>(Expression<Func<T, bool>> expression, Func<T, O> parse);
        IQueryable<O> QueryList<O>(Func<T, O> parse);
        IQueryable<T> QueryList();
    }
}
