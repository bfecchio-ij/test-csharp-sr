using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands
{
    public sealed class AddCandidateExperienceCommand : IRequest
    {
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public AddCandidateExperienceCommand(int idCandidate, string company, string job, string description, decimal salary, DateTime beginDate, DateTime? endDate)
        {
            IdCandidate = idCandidate;
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
        }
    }
}
