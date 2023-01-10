using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.Interfaces.ICommand;
using System.ComponentModel.DataAnnotations;

namespace InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest
{

    public class UpdateCandidateRequest : IRequestCommandBase<CandidateReponse>
    {

        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }
        
        public IEnumerable<UpdateCandidateExperience>? experiences { get; set; }
    }
    public class UpdateCandidateExperience
    {
        public int Id { get; set; } = 0;
        [Required]
        public string Company { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
