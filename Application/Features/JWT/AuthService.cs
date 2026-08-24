using Application.DTOs;
using Application.Features.JWT;
using Application.Services.JWT;
using domain;
using infra;
using infra.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Application.Services.JWT
{
    public class AuthService
    {
        private readonly KpmContext _context;
        private readonly TokenService _tokenService;

        public AuthService(KpmContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string?> Register(RegisterDTO dto)
        {
            var exists = await _context.Users.AnyAsync(u => u.Username == dto.username);
            if (exists) return null;

            var user = new User
            {
                
                Username = dto.username,
                Email = dto.email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _tokenService.GenerateToken(user);
        }

        public async Task<string?> Login(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.username);
            if (user == null) return null;

            var valid = BCrypt.Net.BCrypt.Verify(dto.password, user.PasswordHash);
            if (!valid) return null;

            return _tokenService.GenerateToken(user);
        }
    }
}