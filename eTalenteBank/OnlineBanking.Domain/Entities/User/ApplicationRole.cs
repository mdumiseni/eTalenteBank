using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using OnlineBanking.Domain.Common;

namespace OnlineBanking.Domain.Entities.User;

[Table("Role", Schema = "User")]
public class ApplicationRole : IdentityRole<Guid>
{
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public ICollection<ApplicationUserRole> NavApplicationUserRoles { get; set; }
}