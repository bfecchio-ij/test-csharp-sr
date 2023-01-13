using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.ViewModels.Curriculum;
using System.Collections.Generic;

namespace InfoJobs.KnowledgeTest.UI.Web.Areas.Curriculum.ViewModels.Candidate
{
    public class IndexViewModel
    {
        public IEnumerable<CandidateViewModel> Candidates { get; set; } = new List<CandidateViewModel>();
    }
}