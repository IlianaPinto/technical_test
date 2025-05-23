using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using service_api.Configurations;
using service_api.Context;
using service_api.DTOs;
using service_api.Entities;
using System;

namespace service_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly DBContext _context;
        private readonly JwtHelper _jwt;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthService(DBContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<LoginResponseDTO?> LoginAsync(LoginRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null) return null;

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result != PasswordVerificationResult.Success) return null;

            return new LoginResponseDTO
            {
                Token = _jwt.GenerateToken(user),
                Role = user.Role,
            };
        }
    }
}
