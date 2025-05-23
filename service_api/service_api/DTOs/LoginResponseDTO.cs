namespace service_api.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
