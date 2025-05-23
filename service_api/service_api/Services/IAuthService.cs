using Microsoft.AspNetCore.Identity.Data;
using service_api.DTOs;

namespace service_api.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> LoginAsync(LoginRequest request);
    }
}
