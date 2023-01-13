using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoJobs.KnowledgeTest.Infra.Data.Mappings.Curriculum
{
    internal sealed class CandidateExperiencesMapping : IEntityTypeConfiguration<CandidateExperienceEntity>
    {
        public void Configure(EntityTypeBuilder<CandidateExperienceEntity> builder)
        {
            builder.ToTable("CandidateExperiences");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("IdCandidateExperience")
                   .HasColumnType("integer")
                   .UseIdentityColumn(1, 1)
                   .IsRequired();

            builder.Property(p => p.Company)
                   .HasColumnName("Company")
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Job)
                   .HasColumnName("Job")
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Description)
                   .HasColumnName("Description")
                   .HasColumnType("varchar")
                   .HasMaxLength(4000)
                   .IsRequired();

            builder.Property(p => p.Salary)
                   .HasColumnName("Salary")
                   .HasColumnType("numeric")
                   .HasPrecision(8, 2)
                   .IsRequired();

            builder.Property(p => p.BeginDate)
                   .HasColumnName("BeginDate")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(p => p.EndDate)
                   .HasColumnName("EndDate")
                   .HasColumnType("datetime");

            builder.Property(p => p.InsertDate)
                   .HasColumnName("InsertDate")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(p => p.ModifyDate)
                   .HasColumnName("ModifyDate")
                   .HasColumnType("datetime");

            builder.HasOne(p => p.Candidate)
                   .WithMany()
                   .HasForeignKey(p => p.IdCandidate)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}