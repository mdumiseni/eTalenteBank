using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Persistence.EntityFramework.Configurations;

public class WithdrawalConfiguration : IEntityTypeConfiguration<Withdrawal>
{
    public void Configure(EntityTypeBuilder<Withdrawal> builder)
    {
        builder.HasOne(w => w.UserAccount)
            .WithMany(u => u.NavWithdrawals)
            .HasForeignKey(w => w.UserAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(ua => ua.Status)
            .WithMany(s => s.NavWithdrawals) 
            .HasForeignKey(ua => ua.StatusId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        builder.ConfigureAuditableEntity();
    }
}