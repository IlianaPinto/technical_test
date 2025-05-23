using FluentValidation;
using service_api.DTOs;

namespace service_api.Validators
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateDTO>
    {
        public OrderCreateValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty()
                .Must(BeAValidStatus)
                .WithMessage("Status must be one of: Pending, Canceled, Completed");

            RuleFor(x => x.Total)
                .GreaterThanOrEqualTo(0).WithMessage("Total must be a positive number");
        }

        private bool BeAValidStatus(string status)
        {
            var allowed = new[] { "Pending", "Canceled", "Completed" };
            return allowed.Contains(status, StringComparer.OrdinalIgnoreCase);
        }
    }
}
