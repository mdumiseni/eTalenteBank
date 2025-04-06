using OnlineBanking.Domain.Entities.Account;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Domain.Common;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Account> NavAccounts { get; set; } = new HashSet<Account>();
    public ICollection<ApplicationRole> NavApplicationRoles { get; set; } = new HashSet<ApplicationRole>();
}