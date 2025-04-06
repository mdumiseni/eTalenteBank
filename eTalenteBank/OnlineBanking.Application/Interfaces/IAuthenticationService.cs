using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Application.Interfaces;

public interface IAuthenticationService
{
    Task<string> GenerateJwtToken(string email, string password);
}