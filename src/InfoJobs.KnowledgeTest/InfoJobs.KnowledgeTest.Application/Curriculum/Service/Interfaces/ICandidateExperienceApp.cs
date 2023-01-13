using InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels;

namespace InfoJobs.KnowledgeTest.Application.Curriculum.Service.Interfaces
{
    public interface ICandidateExperienceApp
    {
        Task Add(CandidateExperienceViewModel candidateExperience);
        Task Update(CandidateExperienceViewModel candidateExperience);
        Task Delete(int id);
        IReadOnlyList<CandidateExperienceViewModel> ListByCandidate(int idCandidate);
        CandidateExperienceViewModel GetById(int id);
    }
}