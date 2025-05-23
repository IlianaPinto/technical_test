using FluentValidation;
using service_api.DTOs;

namespace service_api.Validators
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreateDTO>
    {
        public CustomerCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must be 100 characters or less.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be valid.");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number must be 20 characters or less.")
                .Matches(@"^[0-9+\-\s()]*$").When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Phone number contains invalid characters.");
        }
    }
}
