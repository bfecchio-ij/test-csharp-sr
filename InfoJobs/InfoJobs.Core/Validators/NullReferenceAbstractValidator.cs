using FluentValidation;
using FluentValidation.Results;

namespace InfoJobs.Core.Validators
{
    public class NullReferenceAbstractValidator<T> : AbstractValidator<T>
    {
        public ValidationResult Validate(T instance)
        {
            return instance == null
                ? new ValidationResult(new[] { new ValidationFailure(instance.ToString(), "response cannot be null", "Error") })
                : base.Validate(instance);
        }
    }
}
