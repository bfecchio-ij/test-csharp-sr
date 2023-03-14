using LinkedinTest.Model;
using Microsoft.EntityFrameworkCore;

namespace LinkedinTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDb");
        }

        public DbSet<CandidateModel> Candidates { get; set; }
    }
}
