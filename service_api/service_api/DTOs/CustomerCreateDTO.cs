namespace service_api.DTOs
{
    public class CustomerCreateDTO
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? PhoneNumber { get; set; }
    }
}
