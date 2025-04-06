using Microsoft.AspNetCore.Identity;

namespace OnlineBanking.Domain.Entities.User;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser User { get; set; }
    public ApplicationRole Role { get; set; }
}