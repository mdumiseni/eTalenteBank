using OnlineBanking.Domain.Entities.User;

namespace OnlineBanking.Application.Interfaces.Repository;

public interface IUserAccountRepository : IRepository<UserAccount>
{
    Task<UserAccount?> GetUserAccount(Guid userId, string accountNumber);
}