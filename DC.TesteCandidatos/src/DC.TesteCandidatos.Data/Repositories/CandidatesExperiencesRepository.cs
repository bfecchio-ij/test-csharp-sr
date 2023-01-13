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
    public class CandidatesExperiencesRepository : IRepository<CandidateExperiences>, IDisposable
    {
        private readonly DCDbContext _context;
        private bool disposed = false;

        public CandidatesExperiencesRepository(DCDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateExperiences>> GetAll()
        {
            return await _context.CandidateExperiences.AsNoTracking().ToListAsync();
        }

        public async Task<CandidateExperiences> Select(int id)
        {
            return await _context.CandidateExperiences.AsNoTracking().FirstAsync(prop => prop.IdCandidateExperiences == id);
        }

        public async Task<CandidateExperiences> Add(CandidateExperiences entity)
        {
            try
            {
                _context.CandidateExperiences.Add(entity);
                await _context.SaveChangesAsync();
                return await _context.CandidateExperiences.FirstOrDefaultAsync(prop => prop.InsertDate == entity.InsertDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(CandidateExperiences entity)
        {
            _context.CandidateExperiences.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            try
            {
                var experience = _context.CandidateExperiences.AsNoTracking().FirstAsync(prop => prop.IdCandidateExperiences == id).Result;
                _context.CandidateExperiences.Remove(experience);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
