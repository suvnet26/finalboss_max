public class UserAccount
{
    public int Id;
    public string FName;
    public string LName;
    public string PersonalNumber;
    public string Password { get; private set; }
    public bool IsAdmin { get; private set; } = false;
    public bool IsLocked { get; private set; } = false;

}