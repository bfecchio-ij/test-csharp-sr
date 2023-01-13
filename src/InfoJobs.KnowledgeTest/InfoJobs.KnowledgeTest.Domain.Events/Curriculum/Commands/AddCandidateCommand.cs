using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands
{
    public sealed class AddCandidateCommand : IRequest<int>
    {
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public DateTime Birthdate { get; internal set; }
        public string Email { get; internal set; }
        public DateTime InsertDate { get; internal set; }

        public AddCandidateCommand(string name, string surname, DateTime birthdate, string email)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
        }
    }
}