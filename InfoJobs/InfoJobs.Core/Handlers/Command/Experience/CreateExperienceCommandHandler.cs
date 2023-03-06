using FluentValidation;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.Data.Entities;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Command
{
    public class CreateExperienceCommand : IRequest<int>
    {
        public CreateExperienceDTO Model { get; }
        public CreateExperienceCommand(CreateExperienceDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateExperienceDTO> _validator;

        public CreateExperienceCommandHandler(IUnitOfWork repository, IValidator<CreateExperienceDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            CreateExperienceDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Experience
            {
                Company = model.Company,
                Job = model.Job,
                Description = model.Description,
                Salary = model.Salary,
                BeginDate = model.BeginDate,
                EndDate = model.EndDate,
                InsertDate = DateTime.Now,
                CandidateId = model.CandidateId
            };

            _repository.Experiences.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}
