namespace Services;

public interface IAuthService
{

    IUserAccounts? ActiveUser { get; }
    bool IsLoggedIn { get; }

    bool IsAdmin { get; }
    (bool Success, string Message) AuthLogin(string personalnumber, string password);
    void Logout();
    (bool Success, string Message) AuthCreateAccount(string fname, string lname, string personalnumber, string password);

}