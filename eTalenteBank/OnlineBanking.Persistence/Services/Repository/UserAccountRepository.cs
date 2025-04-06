using Microsoft.EntityFrameworkCore;
using OnlineBanking.Application.Common;
using OnlineBanking.Application.Interfaces.Repository;
using OnlineBanking.Domain.Entities.User;
using OnlineBanking.Persistence.EntityFramework;

namespace OnlineBanking.Persistence.Services.Repository;

public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
{
    private readonly ApplicationDbContext _context;
    public UserAccountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserAccount?> GetUserAccount(Guid userId, string accountNumber)
    {
        return await _context.UserAccounts
            .Include(x => x.Account)
            .Include(x => x.User)
            .Where(x => x.UserId == userId && x.Account.Number == accountNumber && x.StatusId == (int)StatusEnum.Active)
            .Select(x => x)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}