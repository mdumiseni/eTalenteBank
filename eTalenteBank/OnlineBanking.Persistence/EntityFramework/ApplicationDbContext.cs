using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Application.Interfaces;
using OnlineBanking.Domain.Common;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Entities.Account;
using OnlineBanking.Domain.Entities.User;
using OnlineBanking.Persistence.EntityFramework.Configurations;

namespace OnlineBanking.Persistence.EntityFramework;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public DbSet<Address> Addresses { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    
    
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationRole> Roles { get; set; }

    public DbSet<Status> Statuses { get; set; }
    
    private readonly ICurrentUserService _currentUser;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUser = currentUserService;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserRoleConfiguration());
        builder.ApplyConfiguration(new AddressConfiguration());
        builder.ApplyConfiguration(new AccountConfiguration());
        builder.ApplyConfiguration(new UserAccountConfiguration());
        
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditInfo()
    {
        var entries = ChangeTracker
            .Entries<AuditableEntity>();

        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOnDateTime = now;
                    entry.Entity.CreatedByUserId = _currentUser.UserId ?? Guid.Empty;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedOnDateTime = now;
                    entry.Entity.ModifiedByUserId = _currentUser.UserId ?? Guid.Empty; ;
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}