using FluentValidation;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Command
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public CreateCandidateDTO Model { get; }
        public CreateCandidateCommand(CreateCandidateDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateCandidateDTO> _validator;

        public CreateCandidateCommandHandler(IUnitOfWork repository, IValidator<CreateCandidateDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            CreateCandidateDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Candidate
            {
                Name = model.Name,
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                InsertDate = DateTime.Now,
                Email = model.Email
            };

            _repository.Candidates.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}
