using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OnlineBanking.Application.Interfaces;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationService(IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }
    public async Task<string> GenerateJwtToken(string email, string password)
    {
        var userRepo = _unitOfWork.GetRepository<ApplicationUser>();
        var passwordHasher = new PasswordHasher<ApplicationUser>();

        var findUserByEmail = await userRepo.GetByExpression(x => x.Email == email);

        if (findUserByEmail == null)
        {
            return string.Empty;
        }
        var hashedPassword = passwordHasher.HashPassword(findUserByEmail, password);
        
        var user = await userRepo.GetByExpression(x => x.Email == email && x.PasswordHash == hashedPassword);
        if (user == null)
        {
            return string.Empty;
        }
        
        string secretKey = _configuration["Jwt:Secret"]!;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            ]),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpireMinutes"])),
            SigningCredentials = credentials,
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };

        var handler = new JsonWebTokenHandler();

        string token = handler.CreateToken(tokenDescriptor);

        return token;
    }
}