using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Persistence.EntityFramework.Configurations;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder
            .HasOne(ua => ua.User)
            .WithMany(u => u.NavUserAccounts)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(ua => ua.Status)
            .WithMany() 
            .HasForeignKey(ua => ua.StatusId)
            .OnDelete(DeleteBehavior.Restrict); 
        builder.ConfigureAuditableEntity();
    }
}