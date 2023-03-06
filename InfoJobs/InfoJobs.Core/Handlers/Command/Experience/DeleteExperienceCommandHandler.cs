using InfoJobs.Domain.Data;
using MediatR;

namespace InfoJobs.Command
{
    public class DeleteExperienceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteExperienceCommand(int id)
        {
            this.Id = id;
        }
    }
    public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand, int>
    {
        private readonly IUnitOfWork _repository;

        public DeleteExperienceCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
        {

            _repository.Experiences.Delete(request.Id);
            await _repository.CommitAsync();

            return request.Id;
        }
    }
}
