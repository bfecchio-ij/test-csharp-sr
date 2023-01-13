using InfoJobs.KnowledgeTest.UI.Web.ApiHelper.ViewModels.Curriculum;
using System.Collections.Generic;

namespace InfoJobs.KnowledgeTest.UI.Web.Areas.Curriculum.ViewModels.Candidate
{
    public class RegisterViewModel
    {
        public CandidateViewModel Candidate { get; set; } = new CandidateViewModel();
        public List<CandidateExperienceViewModel> CandidateExperience { get; set; } = new List<CandidateExperienceViewModel>();
    }
}