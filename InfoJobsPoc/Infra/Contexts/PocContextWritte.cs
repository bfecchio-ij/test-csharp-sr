using InfoJobsPoc.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoJobsPoc.Infra.Contexts
{
    public class PocContextWritte : DbContext
    {
        public PocContextWritte(DbContextOptions<PocContextWritte> options)
        : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SampleDB;Trusted_Connection=True;");
            }

            optionsBuilder.LogTo(message => Console.WriteLine(message), LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Experience       
            modelBuilder.Entity<Experience>(b =>
            {
                b.Property(e => e.Id)
                .HasColumnName("IdCandidateExperience")
                .HasColumnType("int")
                .UseIdentityColumn(1)
                .ValueGeneratedOnAdd();

                b.Property(e => e.BeginDate)
                    .IsRequired()
                    .HasColumnType("datetime2")
                    .HasColumnName("BeginDate");

                b.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar")
                    .HasColumnName("Company");

                b.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasColumnType("varchar")
                    .HasColumnName("Description");

                b.Property(e => e.EndDate)
                    .HasColumnType("datetime2")
                    .HasColumnName("EndDate");

                b.Property(e => e.IdCandidate)
                    .HasColumnName("IdCandidate")
                    .HasColumnType("int");

                b.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar")
                    .HasColumnName("Job");

                b.Property(e => e.InsertDate)
                 .HasColumnType("datetime2")
                 .HasColumnName("InsertDate");

                b.Property(e => e.ModifyDate)
                    .HasColumnType("datetime2")
                    .HasColumnName("ModifyDate");

                b.Property(e => e.Salary)
                    .HasColumnType("numeric(8,2)")
                    .HasColumnName("Salary");

                // constr
                b.HasKey(e => e.Id)
                    .HasName("IdCandidateExperience")
                    .IsClustered(true);


                //index
                b.HasIndex("IdCandidate");
                //

                b.Navigation(e => e.Candidate).AutoInclude();

                b.ToTable("candidateexperiences");
            });
            //candidate
            modelBuilder.Entity<Candidate>(b =>
            {
                b.Property(e => e.Id)
                .HasColumnName("IdCandidate")
                .HasColumnType("int")
                .UseIdentityColumn(1)
                .ValueGeneratedOnAdd();

                b.Property(e => e.Birthdate)
                    .HasColumnType("datetime2")
                    .HasColumnName("Birthdate");

                b.Property(e => e.Email)

                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(true)
                    .HasColumnType("varchar")
                    .HasColumnName("Email");



                b.Property(e => e.InsertDate)
                 .HasColumnType("datetime2")
                 .HasColumnName("InsertDate");

                b.Property(e => e.ModifyDate)
                    .HasColumnType("datetime2")
                    .HasColumnName("ModifyDate");

                b.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar")
                    .HasColumnName("Name");

                b.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnType("varchar")
                    .HasColumnName("Surname");
                //const
                b.HasKey(e => e.Id);

                b.HasMany(e => e.Experiences)
                .WithOne(p => p.Candidate)
                .HasForeignKey(e => e.IdCandidate)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                //index
                b.HasIndex(e => e.Email)
                .IsUnique();
                //
                b.Navigation(e => e.Experiences).AutoInclude();
                b.ToTable("candidates");
            });
            // dados
            modelBuilder.Entity<Candidate>().HasData(new Candidate()
            {
                Id = 1,
                Birthdate = new DateTime(1994, 7, 21),
                Email = "loribao@hotmail.com",
                InsertDate = DateTime.Now,
                Name = "loribao",
                Surname = "sanjinez",
            });
            modelBuilder.Entity<Experience>().HasData(new Experience()
            {
                Id = 1,
                BeginDate = new DateTime(2023, 02, 01),
                IdCandidate = 1,
                Company = "InfoJobs - Pandapé",
                Description = "Estagiario não remunerado!",
                InsertDate = DateTime.Now,
                Job = "Estagiario",
                Salary = 10000.59f
            });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .HaveColumnType("varchar");
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("datetime2");
        }
    }
}
