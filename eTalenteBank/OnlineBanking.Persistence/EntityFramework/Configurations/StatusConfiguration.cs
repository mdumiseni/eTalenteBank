using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBanking.Domain.Common;

namespace OnlineBanking.Persistence.EntityFramework.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        // Relationships
        builder.HasMany(s => s.NavAccounts)
            .WithOne(a => a.Status)
            .HasForeignKey(a => a.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.NavApplicationRoles)
            .WithOne(r => r.Status)
            .HasForeignKey(r => r.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.NavWithdrawals)
            .WithOne(w => w.Status)
            .HasForeignKey(w => w.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(new List<Status>()
        {
            new Status()
            {
                Id = 1,
                Name = "Active",
                Description = "Record is active and accessible"
            },
            new Status()
            {
                Id = 2,
                Name = "Deleted",
                Description = "Record is deleted"
            },
            
        });
    }
}