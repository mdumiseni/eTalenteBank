using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using OnlineBanking.Domain.Common;

namespace OnlineBanking.Domain.Entities.User;
[Table("User", Schema = "User")]
public class ApplicationUser : IdentityUser<Guid>
{
    public required string IDNumber { get; set; }
    
    public int ResidentialAddressId { get; set; }
    public Address ResidentialAddress { get; set; }
    
    public int StatusId { get; set; }  
    public Status Status { get; set; }

    public ICollection<UserAccount> NavUserAccounts { get; set; } = new HashSet<UserAccount>();
    public ICollection<ApplicationUserRole> NavApplicationUserRoles { get; set; }
}