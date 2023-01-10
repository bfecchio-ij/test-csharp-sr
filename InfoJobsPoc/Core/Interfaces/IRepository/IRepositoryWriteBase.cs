namespace InfoJobsPoc.Core.Interfaces.IRepository
{
    public interface IRepositoryWriteBase<T> : IAsyncDisposable, IDisposable where T : class
    {
        T Add(T item);
        T Edit(T item);
        T? Find(int id);
        IQueryable<T> List();
        void Remove(T item);
    }
}