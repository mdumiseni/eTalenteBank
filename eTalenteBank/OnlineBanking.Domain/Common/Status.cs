using System.ComponentModel.DataAnnotations.Schema;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Entities.Account;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Domain.Common;
[Table("Status", Schema = "Shared")]
public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Account> NavAccounts { get; set; } = new HashSet<Account>();
    public ICollection<ApplicationRole> NavApplicationRoles { get; set; } = new HashSet<ApplicationRole>();
    public ICollection<Withdrawal> NavWithdrawals { get; set; } = new HashSet<Withdrawal>();
}