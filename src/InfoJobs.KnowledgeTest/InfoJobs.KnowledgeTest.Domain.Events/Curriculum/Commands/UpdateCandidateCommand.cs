using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands
{
    public sealed class UpdateCandidateCommand : IRequest
    {
        public int IdCandidate { get; internal set; }
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public DateTime Birthdate { get; internal set; }
        public string Email { get; internal set; }
        public DateTime ModifyDate { get; internal set; }

        public UpdateCandidateCommand(int idCandidate, string name, string surname, DateTime birthdate, string email)
        {
            IdCandidate = idCandidate;
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
        }
    }
}