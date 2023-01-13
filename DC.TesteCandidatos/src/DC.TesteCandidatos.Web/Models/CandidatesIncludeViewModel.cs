using DC.TesteCandidatos.Domain.Models;

namespace DC.TesteCandidatos.Web.Models
{
    public class CandidatesIncludeViewModel : BaseViewModel
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public String Email { get; set; }
    }
}
