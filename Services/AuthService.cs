using Services;
using Repositories;
using BCrypt.Net;

public class AuthService : IAuthService
{
    private readonly UserRepository _UserRepository;

    public AuthService(UserRepository userRepository)
    {
        _UserRepository = userRepository;
    }
    public IUserAccounts? ActiveUser { get; private set; }
    public bool IsLoggedIn => ActiveUser != null;

    public bool IsAdmin => ActiveUser is AdminAccount;
    public (bool Success, string Message) AuthLogin(string personalnumber, string plainPassword)
    {
        IUserAccounts? user = _UserRepository.GetUserByPersonalNumber(personalnumber);
        if (user == null)
        {
            user = _UserRepository.GetAdminByPersonalNumber(personalnumber);
        }
        if (user == null || !BCrypt.Net.BCrypt.Verify(plainPassword, user.Password))
        {
            return (false, "det fanns ingen med det lösenordet eller personnummret");
        }
        else if (user is UserAccount userAccount && userAccount.IsLocked == true)
        {
            user = null;
            return (false, "ditt konto är låst");
        }
        else
        {
            ActiveUser = user;
            return (true, $"välkommen {ActiveUser.FName}");
        }
    }

    public (bool Success, string Message) AuthCreateAccount(string fname, string lname, string personalnumber, string plainPassword)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
        ActiveUser = _UserRepository.CreateAccount(fname, lname, personalnumber, passwordHash);
        if (ActiveUser != null)
        {
            return (true, "ditt konto skapades");
        }
        return (false, "dit konto skapades inte");
    }

    public void Logout()
    {
        ActiveUser = null;
    }
}
