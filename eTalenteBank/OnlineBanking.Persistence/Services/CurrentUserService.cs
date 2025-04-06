using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using OnlineBanking.Application.Interfaces;

namespace OnlineBanking.Persistence.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Guid? UserId =>
        Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
}