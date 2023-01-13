using InfoJobs.KnowledgeTest.Domain.Core.Entities;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfoJobs.KnowledgeTest.Infra.Data.Repositories
{
    public class RepositoryCommandBase<TEntity, TContext> : IRepositoryCommandBase<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public RepositoryCommandBase(TContext context)
        {
            _context = context;
        }

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public virtual void Delete(int id)
        {
            var obj = _context.Set<TEntity>().FirstOrDefault(p => p.Id.Equals(id));
            _context.Remove(obj);
        }
    }
}