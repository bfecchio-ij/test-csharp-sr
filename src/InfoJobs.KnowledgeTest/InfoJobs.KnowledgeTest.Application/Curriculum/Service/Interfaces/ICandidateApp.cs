using InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels;

namespace InfoJobs.KnowledgeTest.Application.Curriculum.Service.Interfaces
{
    public interface ICandidateApp
    {
        Task<int> Add(CandidateViewModel candidate);
        Task Update(CandidateViewModel candidate);
        Task Delete(int id);
        IReadOnlyList<CandidateViewModel> List();
        CandidateViewModel GetById(int id);
    }
}
