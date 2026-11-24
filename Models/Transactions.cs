public record Transactions
{
    public int Id;

    public int FromBankAccountId;
    public int ToBankAccountId;

    public DateTime TransactionDate;

    public string? Message;

    public decimal Amount;


}