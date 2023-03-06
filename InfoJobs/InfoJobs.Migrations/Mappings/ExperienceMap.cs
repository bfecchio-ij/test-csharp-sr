using InfoJobs.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoJobs.Infrastructure
{
    public class ExperienceMap : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("CandidateExperiences");

            builder.Property(c => c.Id)
                .HasColumnName("Id");            

            builder.Property(c => c.Company)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Job)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(4000)")
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(c => c.Salary)
                .HasColumnType("decimal(18, 2)")
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(c => c.BeginDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.EndDate)
                .HasColumnType("datetime");

            builder.Property(c => c.InsertDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.ModifyDate)
                .HasColumnType("datetime");

            builder.HasOne(p => p.Candidate)
                .WithMany(p => p.Experiences)
                .HasForeignKey(p => p.CandidateId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
