using System.Linq.Expressions;

namespace InfoJobsPoc.Application.Interfaces.IQuery
{
    public interface IQueryApplication<T> where T : class
    {
        IQueryable<O> QueryList<O>(Expression<Func<T, bool>> expression, Func<T, O> parse);
        IQueryable<O> QueryList<O>(Func<T, O> parse);
        IQueryable<T> QueryList();
    }
}
