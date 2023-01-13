using InfoJobs.KnowledgeTest.Domain.Core.Repositories.Curriculum;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Commands;
using InfoJobs.KnowledgeTest.Infra.Data.Contexts;
using MediatR;

namespace InfoJobs.KnowledgeTest.Domain.Events.Curriculum.Events
{
    public sealed class DeleteCandidateEvent : RequestHandler<DeleteCandidateCommand>
    {
        private readonly ICandidateCommandRepository _candidateCommandRepository;
        private readonly IUnitOfWork<CurriculumContext> _unitOfWork;

        public DeleteCandidateEvent
        (
            ICandidateCommandRepository candidateCommandRepository,
            IUnitOfWork<CurriculumContext> unitOfWork
        )
        {
            _candidateCommandRepository = candidateCommandRepository;
            _unitOfWork = unitOfWork;
        }

        protected override void Handle(DeleteCandidateCommand request)
        {
            _candidateCommandRepository.Delete(request.IdCandidate);
            _unitOfWork.Commit();
        }
    }
}
