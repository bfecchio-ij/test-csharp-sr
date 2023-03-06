using InfoJobs.Domain.Data;
using MediatR;

namespace InfoJobs.Command
{
    public class DeleteCandidateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteCandidateCommand(int id)
        {
            this.Id = id;
        }
    }
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, int>
    {
        private readonly IUnitOfWork _repository;

        public DeleteCandidateCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {

            _repository.Candidates.Delete(request.Id);
            await _repository.CommitAsync();

            return request.Id;
        }
    }
}
