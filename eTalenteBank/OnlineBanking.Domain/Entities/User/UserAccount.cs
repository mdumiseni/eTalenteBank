using System.ComponentModel.DataAnnotations.Schema;
using OnlineBanking.Domain.Common;

namespace OnlineBanking.Domain.Entities.User;
[Table("UserAccount", Schema = "User")]
public class UserAccount : AuditableEntity
{
    public Guid Id { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Balance { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }

    public Guid AccountId { get; set; }
    public Account.Account Account { get; set; }
    
    public int StatusId { get; set; }
    public Status Status { get; set; }

    public ICollection<Withdrawal> NavWithdrawals { get; set; } = new HashSet<Withdrawal>();
}