using InfoJobsPoc.Application.CandidateCommands.CandidateCommandResponse;
using InfoJobsPoc.Application.Interfaces.ICommand;
using System.ComponentModel.DataAnnotations;

namespace InfoJobsPoc.Application.CandidateCommands.CandidateCommandRequest
{
    public class AddCandidateRequest : IRequestCommandBase<CandidateReponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Range(typeof(DateTime), "1/1/1700", "1/1/2500",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Birthdate { get; set; }
        [Required]        
        public string Email { get; set; }

        public IEnumerable<AddCandidateExperience>? AddExperience { get; set; }
    }
    public class AddCandidateExperience
    {          
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
