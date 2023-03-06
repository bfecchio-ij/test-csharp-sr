
namespace InfoJobs.Domain.Data.Entities
{
    public class Experience : BaseEntity
    {
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }

        public string Company { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }

        public decimal Salary { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
