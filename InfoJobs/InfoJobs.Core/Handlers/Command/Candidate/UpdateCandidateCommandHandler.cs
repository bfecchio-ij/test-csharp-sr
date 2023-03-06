using FluentValidation;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Command
{
    public class UpdateCandidateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public UpdateCandidateDTO Model { get; }
        public UpdateCandidateCommand(UpdateCandidateDTO model, int id)
        {
            this.Model = model;
            this.Id = id;
        }
    }

    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<UpdateCandidateDTO> _validator;

        public UpdateCandidateCommandHandler(IUnitOfWork repository, IValidator<UpdateCandidateDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            UpdateCandidateDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entityToUpdate = _repository.Candidates.Get(request.Id);
            if (entityToUpdate == null)
            {
                return default;
            }
            else
            {
                entityToUpdate.Name = model.Name;
                entityToUpdate.Surname = model.Surname;
                entityToUpdate.Email = model.Email;
                entityToUpdate.BirthDate = model.BirthDate;
                entityToUpdate.ModifyDate = DateTime.Now;
                _repository.Candidates.Update(entityToUpdate);
                await _repository.CommitAsync();

                return entityToUpdate.Id;
            }

        }
    }
}
