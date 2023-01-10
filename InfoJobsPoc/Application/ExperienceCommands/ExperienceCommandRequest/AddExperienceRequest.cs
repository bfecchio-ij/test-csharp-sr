using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using InfoJobsPoc.Application.Interfaces.ICommand;

namespace InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest
{
    public class AddExperienceRequest : IRequestCommandBase<ExperienceResponse>
    {
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public float Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmailCandidate { get; set; }
        public int IdCandidate { get; set; }
    }
}
