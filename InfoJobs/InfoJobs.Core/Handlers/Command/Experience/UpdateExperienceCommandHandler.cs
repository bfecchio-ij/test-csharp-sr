using FluentValidation;
using InfoJobs.Core.Exceptions;
using InfoJobs.Domain.Data;
using InfoJobs.Domain.DTO;
using MediatR;

namespace InfoJobs.Command
{
    public class UpdateExperienceCommand : IRequest<int>
    {
        public int Id { get; set; }
        public UpdateExperienceDTO Model { get; }

        public UpdateExperienceCommand(UpdateExperienceDTO model, int id)
        {
            this.Model = model;
            this.Id = id;
        }
    }

    public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<UpdateExperienceDTO> _validator;

        public UpdateExperienceCommandHandler(IUnitOfWork repository, IValidator<UpdateExperienceDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            UpdateExperienceDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entityToUpdate = _repository.Experiences.Get(request.Id);
            if (entityToUpdate == null || entityToUpdate.CandidateId != model.CandidateId)
            {
                return default;
            }
            else
            {
                entityToUpdate.Company = model.Company;
                entityToUpdate.Job = model.Job;
                entityToUpdate.Salary = model.Salary;
                entityToUpdate.Description = model.Description;
                entityToUpdate.BeginDate = model.BeginDate;
                entityToUpdate.EndDate = model.EndDate;
                entityToUpdate.ModifyDate = DateTime.Now;
                _repository.Experiences.Update(entityToUpdate);
                await _repository.CommitAsync();

                return entityToUpdate.Id;
            }

        }
    }
}
