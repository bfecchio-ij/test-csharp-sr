using FluentValidation;
using InfoJobs.Domain.DTO;

namespace InfoJobs.Core.Validators
{
    public class UpdateExperienceDTOValidator : NullReferenceAbstractValidator<UpdateExperienceDTO>
    {
        public UpdateExperienceDTOValidator()
        {
            RuleFor(x => x.Company).NotEmpty().WithMessage("Company is required");
            RuleFor(x => x.Job).NotEmpty().WithMessage("Job is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary is required");
            RuleFor(x => x.BeginDate).NotEmpty().WithMessage("BeginDate is required");
        }
    }
}
