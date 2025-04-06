using OnlineBanking.Shared.Dto;

namespace OnlineBanking.Application.Interfaces;

public interface IWithdrawalService
{
    Task<string> Withdraw(WithdrawalDto request);
    
}