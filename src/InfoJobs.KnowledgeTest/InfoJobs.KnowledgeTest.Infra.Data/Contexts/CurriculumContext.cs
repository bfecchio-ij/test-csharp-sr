using Microsoft.EntityFrameworkCore;
using InfoJobs.KnowledgeTest.Infra.Data.Mappings.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;

namespace InfoJobs.KnowledgeTest.Infra.Data.Contexts
{
    public sealed class CurriculumContext : DbContext
    {
        public CurriculumContext(DbContextOptions<CurriculumContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #region Curriculum

        public DbSet<CandidateEntity> Candidate { get; set; }
        public DbSet<CandidateExperienceEntity> CandidateExperience { get; set; }

        #endregion

        #region Mapeamentos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModuloCurriculum(modelBuilder);
        }

        private static void ModuloCurriculum(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateMapping());
            modelBuilder.ApplyConfiguration(new CandidateExperiencesMapping());
        }

        #endregion
    }
}
