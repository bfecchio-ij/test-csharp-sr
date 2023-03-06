using InfoJobs.Domain.Data.Entities;
using InfoJobs.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InfoJobs.Migrations
{
    public class InfoJobsDbContext : DbContext
    {
        public InfoJobsDbContext()
        {

        }
        public InfoJobsDbContext(DbContextOptions<InfoJobsDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateMap());
            modelBuilder.ApplyConfiguration(new ExperienceMap());

            modelBuilder.Entity<Candidate>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Experience> Experiences { get; set; }

    }
}
