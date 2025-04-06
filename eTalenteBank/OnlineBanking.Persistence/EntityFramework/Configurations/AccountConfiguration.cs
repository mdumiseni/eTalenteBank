using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBanking.Domain.Entities.Account;

namespace OnlineBanking.Persistence.EntityFramework.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasOne(ua => ua.Status)
            .WithMany() 
            .HasForeignKey(ua => ua.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(a => a.CreatedByUser)
            .WithMany()  
            .HasForeignKey(a => a.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.ConfigureAuditableEntity();
    }
}