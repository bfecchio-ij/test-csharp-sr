using FluentValidation;
using InfoJobs.Domain.DTO;

namespace InfoJobs.Core.Validators
{
    public class UpdateCandidateDTOValidator : NullReferenceAbstractValidator<UpdateCandidateDTO>
    {
        public UpdateCandidateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate is required");
        }
    }
}
