using service_api.Entities;

namespace service_api.DTOs
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Date { get; set; }
    }
}
