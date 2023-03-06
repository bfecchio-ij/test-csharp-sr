
namespace InfoJobs.Domain.Data.Entities
{
    public class Candidate : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public ICollection<Experience> Experiences { get; set; }

    }
}
