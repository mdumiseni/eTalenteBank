namespace OnlineBanking.Application.Interfaces;

public interface IAccountService
{
    Task GetAccountInformation(string accountNumber);
}