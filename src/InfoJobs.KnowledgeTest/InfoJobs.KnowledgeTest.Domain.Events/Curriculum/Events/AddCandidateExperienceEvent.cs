using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;
using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using MediatR;
using AutoMapper;
using InfoJobs.KnowledgeTest.Domain.Events.Mappers;
using InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Helpers;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Events
{
    public sealed class AddCandidateExperienceEvent : RequestHandler<AddCandidateExperienceCommand>
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly ICandidateExperienceCommandRepository _candidateExperienceCommandRepository;
        private readonly IUnitOfWork<CurriculumContext> _unitOfWork;

        public AddCandidateExperienceEvent
        (
            ICandidateExperienceCommandRepository candidateExperienceCommandRepository,
            IUnitOfWork<CurriculumContext> unitOfWork
        )
        {
            _candidateExperienceCommandRepository = candidateExperienceCommandRepository;
            _unitOfWork = unitOfWork;
        }

        protected override void Handle(AddCandidateExperienceCommand request)
        {
            ExceptionDomainHelper.Validar(request.EndDate.HasValue && request.EndDate < request.BeginDate, "End date cannot be less than begin date");

            var oCandidateExperience = _mapper.Map<CandidateExperienceEntity>(request);
            _candidateExperienceCommandRepository.Add(oCandidateExperience);
            _unitOfWork.Commit();
        }
    }
}
