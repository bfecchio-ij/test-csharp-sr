using AutoMapper;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Helpers;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;
using InfoJobs.KnowledgeTest.Domain.Events.Mappers;
using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Events
{
    public sealed class AddCandidateEvent : RequestHandler<AddCandidateCommand, int>
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly ICandidateCommandRepository _candidateCommandRepository;
        private readonly ICandidateQueryRepository _candidateQueryRepository;
        private readonly IUnitOfWork<CurriculumContext> _unitOfWork;

        public AddCandidateEvent
        (
            ICandidateCommandRepository candidateCommandRepository,
            ICandidateQueryRepository candidateQueryRepository,
            IUnitOfWork<CurriculumContext> unitOfWork
        )
        {
            _candidateCommandRepository = candidateCommandRepository;
            _candidateQueryRepository = candidateQueryRepository;
            _unitOfWork = unitOfWork;
        }

        protected override int Handle(AddCandidateCommand request)
        {
            bool registered = _candidateQueryRepository.EmailRegistered(request.Email);
            ExceptionDomainHelper.Validar(registered, "E-mail already registered");

            var oCandidate = _mapper.Map<CandidateEntity>(request);
            _candidateCommandRepository.Add(oCandidate);
            _unitOfWork.Commit();

            return oCandidate.Id;
        }
    }
}