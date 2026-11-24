public abstract class BankAccount
{

    public string Name { get; private set; }
    public string AccountNumber { get; private set; }

    public decimal Balance { get; private set; }

    public bool LockedByAdmin { get; private set; } = false;

    public int AccountTypeId { get; private set; }

}