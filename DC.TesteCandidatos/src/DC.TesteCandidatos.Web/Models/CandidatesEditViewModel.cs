using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Models;

namespace DC.TesteCandidatos.Web.Models
{
    public class CandidatesEditViewModel : BaseViewModel
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Surname { get; set; }
        public String LastSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastBirthDate { get; set; }
        public String Email { get; set; }
        public String LastEmail { get; set; }
        public IList<CandidateExperiences> lstExperiences { get; set; }

    }
}
