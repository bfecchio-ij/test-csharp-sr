using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands
{
    public sealed class DeleteCandidateCommand : IRequest
    {
        public int IdCandidate { get; internal set; }

        public DeleteCandidateCommand(int idCandidate)
        {
            IdCandidate = idCandidate;
        }
    }
}