using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;
using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Events
{
    public sealed class DeleteCandidateExperienceEvent : RequestHandler<DeleteCandidateExperienceCommand>
    {
        private readonly ICandidateExperienceCommandRepository _candidateExperienceCommandRepository;
        private readonly IUnitOfWork<CurriculumContext> _unitOfWork;

        public DeleteCandidateExperienceEvent
        (
            ICandidateExperienceCommandRepository candidateExperienceCommandRepository,
            IUnitOfWork<CurriculumContext> unitOfWork
        )
        {
            _candidateExperienceCommandRepository = candidateExperienceCommandRepository;
            _unitOfWork = unitOfWork;
        }

        protected override void Handle(DeleteCandidateExperienceCommand request)
        {
            _candidateExperienceCommandRepository.Delete(request.IdCandidateExperience);
            _unitOfWork.Commit();
        }
    }
}