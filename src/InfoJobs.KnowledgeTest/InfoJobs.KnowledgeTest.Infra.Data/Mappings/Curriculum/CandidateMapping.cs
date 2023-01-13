using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoJobs.KnowledgeTest.Infra.Data.Mappings.Curriculum
{
    internal sealed class CandidateMapping : IEntityTypeConfiguration<CandidateEntity>
    {
        public void Configure(EntityTypeBuilder<CandidateEntity> builder)
        {
            builder.ToTable("Candidate")
                   .HasIndex(p => p.Email, "Uk_Candidate_Email")
                   .IsUnique();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("IdCandidate")
                   .HasColumnType("integer")
                   .UseIdentityColumn(1, 1)
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasColumnName("Name")
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Surname)
                   .HasColumnName("Surname")
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(p => p.Birthdate)
                   .HasColumnName("Birthdate")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(p => p.Email)
                   .HasColumnName("Email")
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.InsertDate)
                   .HasColumnName("InsertDate")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(p => p.ModifyDate)
                   .HasColumnName("ModifyDate")
                   .HasColumnType("datetime");
        }
    }
}