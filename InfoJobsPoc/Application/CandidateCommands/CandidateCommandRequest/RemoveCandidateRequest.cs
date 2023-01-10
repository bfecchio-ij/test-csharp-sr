using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.Interfaces.ICommand;

namespace InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest
{
    public class RemoveCandidateRequest : IRequestCommandBase<CandidateReponse>
    {
        public int Id { get; set; } = 0;
    }
}
