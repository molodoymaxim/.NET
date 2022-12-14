using FluentValidation;
using FluentValidation.Results;

namespace MedicationPlan.WebAPI.Models;

public abstract class AuthStudentRequest
{
    public string Login { get; set; }
    public string Password { get; set; }

    public class Validator : AbstractValidator<AuthStudentRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Login)
            .MaximumLength(50).WithMessage("Length must be not great than 50")
            .MinimumLength(3).WithMessage("Length must be not less than 3");

            RuleFor(x => x.Password)
            .MaximumLength(50).WithMessage("Length must be not great than 50")
            .MinimumLength(5).WithMessage("Length must be not less than 5");
        }
    }
}

public static class AuthUserRequestExtension
{
    public static ValidationResult Validate(this AuthStudentRequest model)
    {
        return new AuthStudentRequest.Validator().Validate(model);
    }
}