using FluentValidation;
using Interest_Calculator.Schema;

namespace Interest_Calculator.Business.Validator
{
    // InterestRequest nesnesi için doğrulama kurallarını içeren bir FluentValidation validator sınıfı.
    public class InterestValidator : AbstractValidator<InterestRequest>
    {
        public InterestValidator()
        {
            // Principal alanı için doğrulama kuralları
            RuleFor(x => x.Principal)
                .NotEmpty().WithMessage("The Principal field is required.")
                .GreaterThanOrEqualTo(0).WithMessage("The Principal field must be a non-negative number.");

            // InterestRate alanı için doğrulama kuralları
            RuleFor(x => x.InterestRate)
                .NotEmpty().WithMessage("The InterestRate field is required.")
                .InclusiveBetween(0, 100).WithMessage("The InterestRate field must be between 0 and 1.");

            // Maturity alanı için doğrulama kuralları
            RuleFor(x => x.Maturity)
                .NotEmpty().WithMessage("The Maturity field is required.")
                .GreaterThan(0).WithMessage("The Maturity field must be a positive number.");

            // InterestFrequency alanı için doğrulama kuralları
            RuleFor(x => x.InterestFrequency)
                .NotEmpty().WithMessage("The InterestFrequency field is required.")
                .Must(value => value == "gün" || value == "ay" || value == "yıl")
                .WithMessage("The InterestFrequency field must be 'gün', 'ay', or 'yıl'.");
        }
    }
}