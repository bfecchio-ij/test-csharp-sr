namespace InfoJobs.Domain.DTO
{
    public class CreateCandidateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
