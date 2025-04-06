using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Domain.Common;

public abstract class AuditableEntity
{
    public DateTime CreatedOnDateTime { get; set; }
    public DateTime? ModifiedOnDateTime { get; set; }

    public Guid CreatedByUserId { get; set; }
    public ApplicationUser CreatedByUser { get; set; }
    
    public Guid? ModifiedByUserId { get; set; }
    public ApplicationUser? ModifiedByUser { get; set; }
}