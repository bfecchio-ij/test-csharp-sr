using InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandResponse;
using InfoJobsPoc.Application.Interfaces.ICommand;

namespace InfoJobsPoc.Application.ExperienceCommands.ExperienceCommandRequest
{
    public class UpdateExperienceRequest : IRequestCommandBase<ExperienceResponse>
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }

        public float Salary { get; set; }
        
        public DateTime BeginDate { get; set; }
        
        public DateTime? EndDate { get; set; }
    }
}
