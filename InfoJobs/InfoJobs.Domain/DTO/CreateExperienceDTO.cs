namespace InfoJobs.Domain.DTO
{
    public class CreateExperienceDTO
    {  

        public string Company { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }

        public decimal Salary { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int CandidateId { get; set; }
    }
}
