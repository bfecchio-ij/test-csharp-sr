using AutoMapper;
using InfoJobs.KnowledgeTest.Application.Curriculum.Service.Interfaces;
using InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels;
using InfoJobs.KnowledgeTest.Application.Mappers;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;
using MediatR;

namespace InfoJobs.KnowledgeTest.Application.Curriculum.Service
{
    public sealed class CandidateApp : ICandidateApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IMediator _mediator;
        private readonly ICandidateQueryRepository _candidateQueryRepository;

        public CandidateApp
        (
            IMediator mediator,
            ICandidateQueryRepository candidateQueryRepository
        )
        {
            _mediator = mediator;
            _candidateQueryRepository = candidateQueryRepository;
        }

        public Task<int> Add(CandidateViewModel candidate)
        {
            var addCmd = new AddCandidateCommand(candidate.Name, candidate.Surname, candidate.Birthdate, candidate.Email);
            Task<int> idCandidate = _mediator.Send(addCmd);
            return idCandidate;
        }

        public async Task Delete(int id)
        {
            var deleteCmd = new DeleteCandidateCommand(id);
            await _mediator.Send(deleteCmd);
        }

        public CandidateViewModel GetById(int id)
        {
            var oCandidate = _candidateQueryRepository.ById(id);
            var oCandidateVM = _mapper.Map<CandidateViewModel>(oCandidate);
            return oCandidateVM;
        }

        public IReadOnlyList<CandidateViewModel> List()
        {
            var lstCandidate = _candidateQueryRepository.List();
            var lstCandidateVM = _mapper.Map<IReadOnlyList<CandidateViewModel>>(lstCandidate);
            return lstCandidateVM;
        }

        public async Task Update(CandidateViewModel candidate)
        {
            var updateCmd = new UpdateCandidateCommand(candidate.Id, candidate.Name, candidate.Surname, candidate.Birthdate, candidate.Email);
            await _mediator.Send(updateCmd);
        }
    }
}
