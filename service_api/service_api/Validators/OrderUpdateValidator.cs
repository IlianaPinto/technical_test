using FluentValidation;
using service_api.DTOs;

namespace service_api.Validators
{
    public class OrderUpdateValidator
    {
        public class OrderUpdateDTOValidator : AbstractValidator<OrderUpdateDTO>
        {
            public OrderUpdateDTOValidator()
            {
                RuleFor(x => x.Status)
                    .NotEmpty()
                    .Must(BeAValidStatus)
                    .WithMessage("Status must be one of: Pending, Canceled, Completed");

                RuleFor(x => x.Total)
                    .GreaterThanOrEqualTo(0);
            }

            private bool BeAValidStatus(string status)
            {
                var allowed = new[] { "Pending", "Canceled", "Completed" };
                return allowed.Contains(status, StringComparer.OrdinalIgnoreCase);
            }
        }
    }
}
