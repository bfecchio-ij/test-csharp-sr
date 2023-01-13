using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;
using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using MediatR;
using AutoMapper;
using InfoJobs.KnowledgeTest.Domain.Events.Mappers;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Events
{
    public sealed class UpdateCandidateEvent : RequestHandler<UpdateCandidateCommand>
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly ICandidateCommandRepository _candidateCommandRepository;
        private readonly IUnitOfWork<CurriculumContext> _unitOfWork;

        public UpdateCandidateEvent
        (
            ICandidateCommandRepository candidateCommandRepository,
            IUnitOfWork<CurriculumContext> unitOfWork
        )
        {
            _candidateCommandRepository = candidateCommandRepository;
            _unitOfWork = unitOfWork;
        }

        protected override void Handle(UpdateCandidateCommand request)
        {
            var oCandidate = _mapper.Map<UpdateCandidateCommand, CandidateEntity>(request);
            _candidateCommandRepository.Update(oCandidate);
            _unitOfWork.Commit();
        }
    }
}