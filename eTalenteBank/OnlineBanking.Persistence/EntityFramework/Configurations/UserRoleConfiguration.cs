using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Persistence.EntityFramework.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder
            .HasOne<ApplicationUser>(ur => ur.User)
            .WithMany(u => u.NavApplicationUserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Restrict); 
        builder
            .HasOne<ApplicationRole>(ur => ur.Role)
            .WithMany(u => u.NavApplicationUserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}