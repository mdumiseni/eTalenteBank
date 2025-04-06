using OnlineBanking.Application.Interfaces;
using OnlineBanking.Domain.Entities.User;
using OnlineBanking.Shared.Dto;

namespace OnlineBanking.Application.Services;

public class WithdrawalService : IWithdrawalService
{
    private readonly IUnitOfWork _unitOfWork;

    public WithdrawalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<string> Withdraw(WithdrawalDto request)
    {
        var userAccountRepo = _unitOfWork.GetRepository<UserAccount>();
        
 
        throw new NotImplementedException();
    }
}