﻿namespace service_api.DTOs
{
    public class LoginRequestDTO
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
