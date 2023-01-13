using DC.TesteCandidatos.Data.ORM;
using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Data.Repositories
{
    public class CandidatesRepository : IRepository<Candidates>, IDisposable
    {
        private readonly DCDbContext _context;
        private bool disposed = false;

        public CandidatesRepository(DCDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidates>> GetAll()
        {
            return await _context.Candidates.AsNoTracking().ToListAsync();
        }

        public async Task<Candidates> Select(int id)
        {
            try
            {
                return await _context.Candidates.AsNoTracking().FirstAsync(prop => prop.IdCandidates == id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Candidates> Add(Candidates entity)
        {
            _context.Candidates.Add(entity);
            await _context.SaveChangesAsync();
            return await _context.Candidates.FirstOrDefaultAsync(prop => prop.Email == entity.Email);
        }

        public async Task Update(Candidates entity)
        {
            _context.Candidates.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var candidate = await _context.Candidates.FirstAsync(prop => prop.IdCandidates == id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
