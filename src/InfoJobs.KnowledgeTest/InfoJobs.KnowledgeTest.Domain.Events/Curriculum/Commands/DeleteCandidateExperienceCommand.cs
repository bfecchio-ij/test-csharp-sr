using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands
{
    public class DeleteCandidateExperienceCommand : IRequest
    {
        public int IdCandidateExperience { get; internal set; }

        public DeleteCandidateExperienceCommand(int idCandidateExperience)
        {
            IdCandidateExperience = idCandidateExperience;
        }
    }
}