using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using InfoJobsPoc.Application.Interfaces.ICommand;

namespace InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest
{
    public class RemoveExperienceRequest : IRequestCommandBase<ExperienceResponse>
    {
        public int Id { get; set; }
    }
}
