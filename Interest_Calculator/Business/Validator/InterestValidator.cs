using FluentValidation;
using Interest_Calculator.Schema;

namespace Interest_Calculator.Business.Validator;

public class InterestValidator : AbstractValidator<InterestRequest>
{
    public InterestValidator()
    {
        RuleFor(x => x.Principal)
            .NotEmpty().WithMessage("The Principal field is required.")
            .GreaterThanOrEqualTo(0).WithMessage("The Principal field must be a non-negative number.");

        RuleFor(x => x.InterestRate)
            .NotEmpty().WithMessage("The InterestRate field is required.")
            .InclusiveBetween(0,1).WithMessage("The InterestRate field must be between 0 and 100.");

        RuleFor(x => x.Maturity)
            .NotEmpty().WithMessage("The Maturity field is required.")
            .GreaterThan(0).WithMessage("The Maturity field must be a positive number.");

        RuleFor(x => x.InterestFrequency)
            .NotEmpty().WithMessage("The InterestFrequency field is required.")
            .Must(value => value == "gün" || value == "ay" || value == "yıl")
            .WithMessage("The InterestFrequency field must be 'gün', 'ay', or 'yıl'.");
    }
}