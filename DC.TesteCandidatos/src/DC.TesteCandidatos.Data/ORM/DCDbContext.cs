using DC.TesteCandidatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.TesteCandidatos.Data.ORM
{
    public class DCDbContext : DbContext
    {
        public DCDbContext(DbContextOptions<DCDbContext> options) : base(options) { }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<CandidateExperiences> CandidateExperiences { get; set; }

    }
}
