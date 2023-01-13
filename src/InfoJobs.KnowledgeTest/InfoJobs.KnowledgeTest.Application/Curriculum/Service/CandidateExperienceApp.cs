using AutoMapper;
using InfoJobs.KnowledgeTest.Application.Curriculum.Service.Interfaces;
using InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels;
using InfoJobs.KnowledgeTest.Application.Mappers;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;
using MediatR;

namespace InfoJobs.KnowledgeTest.Application.Curriculum.Service
{
    public sealed class CandidateExperienceApp : ICandidateExperienceApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly ICandidateExperienceQueryRepository _candidateExperienceQueryRepository;
        private readonly IMediator _mediator;

        public CandidateExperienceApp
        (
            ICandidateExperienceQueryRepository candidateExperienceQueryRepository,
            IMediator mediator
        )
        {
            _candidateExperienceQueryRepository = candidateExperienceQueryRepository;
            _mediator = mediator;
        }

        public async Task Add(CandidateExperienceViewModel candidateExperience)
        {
            var addCmd = new AddCandidateExperienceCommand(candidateExperience.IdCandidate, candidateExperience.Company, candidateExperience.Job, candidateExperience.Description, candidateExperience.Salary, candidateExperience.BeginDate, candidateExperience.EndDate);
            await _mediator.Send(addCmd);
        }

        public async Task Delete(int id)
        {
            var deleteCmd = new DeleteCandidateExperienceCommand(id);
            await _mediator.Send(deleteCmd);
        }

        public CandidateExperienceViewModel GetById(int id)
        {
            var oCandidateExperience = _candidateExperienceQueryRepository.ById(id);
            var oCandidateExperienceVM = _mapper.Map<CandidateExperienceViewModel>(oCandidateExperience);
            return oCandidateExperienceVM;
        }

        public IReadOnlyList<CandidateExperienceViewModel> ListByCandidate(int idCandidate)
        {
            var lstCandidateExperience = _candidateExperienceQueryRepository.List();
            lstCandidateExperience = lstCandidateExperience.OrderByDescending(p => p.BeginDate);
            var lstCandidateExperienceVM = _mapper.Map<IReadOnlyList<CandidateExperienceViewModel>>(lstCandidateExperience);
            return lstCandidateExperienceVM;
        }

        public async Task Update(CandidateExperienceViewModel candidateExperience)
        {
            var updateCmd = new UpdateCandidateExperienceCommand(candidateExperience.Id, candidateExperience.IdCandidate, candidateExperience.Company, candidateExperience.Job, candidateExperience.Description, candidateExperience.Salary, candidateExperience.BeginDate, candidateExperience.EndDate);
            await _mediator.Send(updateCmd);
        }
    }
}
