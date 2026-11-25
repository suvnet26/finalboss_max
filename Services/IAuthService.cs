namespace Services;

public interface IAuthService
{

    UserAccount? ActiveUser { get; }
    bool IsLoggedIn { get; }

    (bool Success, string Message, bool IsAdmin) AuthLogin(string personalnumber, string password);
    void Logout();
    (bool Success, string Message) AuthCreateAccount(string fname, string lname, string personalnumber, string password);

}