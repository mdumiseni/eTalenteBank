namespace OnlineBanking.Shared.Dto;

public class WithdrawalDto
{
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public string AccountNumber { get; set; }
}