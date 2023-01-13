namespace InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum
{
    public sealed class CandidateEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}