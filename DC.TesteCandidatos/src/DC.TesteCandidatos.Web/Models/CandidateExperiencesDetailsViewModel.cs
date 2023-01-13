using DC.TesteCandidatos.Domain.Models;

namespace DC.TesteCandidatos.Web.Models
{
    public class CandidateExperiencesDetailsViewModel : BaseViewModel
    {
        public int IdExperince { get; set; }
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string HistoricBack { get; set; }
    }
}
