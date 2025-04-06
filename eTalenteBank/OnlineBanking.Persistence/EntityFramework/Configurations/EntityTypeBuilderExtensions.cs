using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBanking.Domain.Common;

namespace OnlineBanking.Persistence.EntityFramework.Configurations;

public static class EntityTypeBuilderExtensions
{
    public static void ConfigureAuditableEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : AuditableEntity
    {
        builder.Property(e => e.CreatedOnDateTime)
            .IsRequired();

        builder.Property(e => e.ModifiedOnDateTime);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ModifiedByUser)
            .WithMany()
            .HasForeignKey(e => e.ModifiedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}