using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Domain.Common;
using OnlineBanking.Domain.Entities;
using OnlineBanking.Domain.Entities.User;
using OnlineBanking.Persistence.EntityFramework;

namespace OnlineBanking.Persistence.Services;

public static class DataSeed
{
    public static async Task GenerateData(ModelBuilder builder)
    {

        var passwordHasher = new PasswordHasher<ApplicationUser>();
        
        builder.Entity<Status>().HasData(
            new List<Status>()
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
            }
            );
        

        
        var admin = new ApplicationUser
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
            IDNumber = "9001015800087",
            StatusId = 1, // Make sure this status exists in your Status seed
            ResidentialAddressId = 1, // Ensure you seed this address too
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
            PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "Admin123!")
        };
        
        var user1 = new ApplicationUser
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            UserName = "user1",
            NormalizedUserName = "USER1",
            Email = "user1@example.com",
            NormalizedEmail = "USER1@EXAMPLE.COM",
            EmailConfirmed = true,
            IDNumber = "9001015800087",
            ResidentialAddressId = 1,
            StatusId = 1,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        };
        user1.PasswordHash = passwordHasher.HashPassword(user1, "User1Password!");
        
        builder.Entity<Address>().HasData(new Address
        {
            Id = 1,
            StreetAddress = "123 Main Street",
            City = "Cape Town",
            Province = "Western Cape",
            PostalCode = "8000",
            Country = "South Africa",
            CreatedByUserId = user1.Id
        });
        
        var user2 = new ApplicationUser
        {
            Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
            UserName = "user2",
            NormalizedUserName = "USER2",
            Email = "user2@example.com",
            NormalizedEmail = "USER2@EXAMPLE.COM",
            EmailConfirmed = true,
            IDNumber = "9001025800088",
            ResidentialAddressId = 1,
            StatusId = 1,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        };
        user2.PasswordHash = passwordHasher.HashPassword(user2, "User2Password!");
        
        builder.Entity<Address>().HasData(new Address
        {
            Id = 1,
            StreetAddress = "123 Main Street",
            City = "Cape Town",
            Province = "Western Cape",
            PostalCode = "8000",
            Country = "South Africa",
            CreatedByUserId = user2.Id
        });
        
        var user3 = new ApplicationUser
        {
            Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
            UserName = "user3",
            NormalizedUserName = "USER3",
            Email = "user3@example.com",
            NormalizedEmail = "USER3@EXAMPLE.COM",
            EmailConfirmed = true,
            IDNumber = "9001035800089",
            ResidentialAddressId = 1,
            StatusId = 1,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        };
        user3.PasswordHash = passwordHasher.HashPassword(user3, "User3Password!");
        
        builder.Entity<Address>().HasData(new Address
        {
            Id = 1,
            StreetAddress = "123 Main Street",
            City = "Cape Town",
            Province = "Western Cape",
            PostalCode = "8000",
            Country = "South Africa",
            CreatedByUserId = user1.Id
        });

        builder.Entity<ApplicationUser>().HasData(admin, user1, user2, user3);
    }
}