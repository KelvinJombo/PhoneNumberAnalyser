using FluentValidation;
using PhoneNumberAnalyser.Application.DTOs;

namespace PhoneNumberAnalyser.Application.Validation
{
    public class PhoneNumberRequestValidator : AbstractValidator<PhoneNumberRequestDto>
    {
        public PhoneNumberRequestValidator()
        {
            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required")

            .Matches(@"^\d+$")
            .WithMessage("Phone number must contain only digits")

            .MinimumLength(3)
            .WithMessage("Phone number must be at least 3 digits long")

            .MaximumLength(15)
            .WithMessage("Phone number cannot exceed 15 digits");
        }
    }
}
