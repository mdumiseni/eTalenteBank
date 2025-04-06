using System.ComponentModel.DataAnnotations.Schema;
using OnlineBanking.Domain.Common;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Domain.Entities;

[Table("Withdrawal", Schema = "Withdrawal")]
public class Withdrawal : AuditableEntity
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }

    public Guid UserAccountId { get; set; }
    public UserAccount UserAccount { get; set; }

    public int StatusId { get; set; }
    public Status Status { get; set; }
}