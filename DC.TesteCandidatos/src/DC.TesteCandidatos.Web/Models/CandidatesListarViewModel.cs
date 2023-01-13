using DC.TesteCandidatos.Domain.Entities;
using DC.TesteCandidatos.Domain.Models;

namespace DC.TesteCandidatos.Web.Models
{
    public class CandidatesListarViewModel : BaseViewModel
    {
        public IList<Candidates> lstCandidadtes { get; set; } = new List<Candidates>(); 
    }
}
