using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands
{
    public sealed class UpdateCandidateExperienceCommand : IRequest
    {
        public int IdCandidateExperience { get; internal set; }
        public int IdCandidate { get; internal set; }
        public string Company { get; internal set; }
        public string Job { get; internal set; }
        public string Description { get; internal set; }
        public decimal Salary { get; internal set; }
        public DateTime BeginDate { get; internal set; }
        public DateTime? EndDate { get; internal set; }

        public UpdateCandidateExperienceCommand(int idCandidateExperience, int idCandidate, string company, string job, string description, decimal salary, DateTime beginDate, DateTime? endDate)
        {
            IdCandidateExperience = idCandidateExperience;
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
