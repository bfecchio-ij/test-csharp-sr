using InfoJobsPoc.Core.Interfaces.IRepository;
using InfoJobsPoc.Infra.Contexts;

namespace InfoJobsPoc.Infra.RepositoryWrites
{
    public class RepositoryWriteBase<T> : IRepositoryWriteBase<T> where T : class
    {
        private readonly PocContextWritte _db;

        public RepositoryWriteBase(PocContextWritte context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T? Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _db.Set<T>();
        }

        public T Add(T item)
        {
            var ret = _db.Set<T>().Add(item).Entity;
            _db.SaveChanges();
            return ret;
        }

        public void Remove(T item)
        {
            _db.Set<T>().Remove(item);
            _db.SaveChanges();
        }

        public T Edit(T item)
        {
            var ret = Task.Run(async () =>
               {
                   var result = _db.Update(item);
                   await _db.SaveChangesAsync();
                   return result.Entity;
               });
            return ret.Result;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return _db.DisposeAsync();
        }
    }
}
