using InfoJobsPoc.Core.Entities;

namespace InfoJobsPoc.Core.Interfaces.IService
{
    public interface IServiceBase<T> where T : class
    {
        ResultNormalized<T> Add(T entity);
        ResultNormalized<T> Remove(int identity);
        ResultNormalized<T> Update(T entity);
    }
}
