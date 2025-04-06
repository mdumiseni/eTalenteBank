using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Domain.Common;

namespace OnlineBanking.Domain.Entities.Account;

[Index(nameof(Number), IsUnique = true)]
[Table("Account", Schema = "Account")]
public class Account : AuditableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Number { get; set; }
    public required AccountType AccountType { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
}