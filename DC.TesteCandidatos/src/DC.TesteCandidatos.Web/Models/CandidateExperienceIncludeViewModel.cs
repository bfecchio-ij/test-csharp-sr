using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Models;

namespace DC.TesteCandidatos.Web.Models
{
    public class CandidateExperienceIncludeViewModel : BaseViewModel
    {
        public int IdCandidate { get; set; }
        public virtual Candidates Candidate { get; set; } = new Candidates();
        public IList<CandidateExperiences> Experiences { get; set; } = new List<CandidateExperiences>();
        public CandidateExperiences NewExperience { get; set; } = new CandidateExperiences();
        public String Fullname { get; set; }
        public int IdExperince { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
