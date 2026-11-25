using Services;

public class AuthService : IAuthService
{
    private readonly UserRepository _UserRepository;

    public AuthService(UserRepository userRepository)
    {
        _UserRepository = userRepository;
    }
    public UserAccount? ActiveUser { get; private set; }
    public bool IsLoggedIn => ActiveUser != null;

    public (bool Success, string Message, bool IsAdmin) AuthLogin(string personalnumber, string password)
    {
        ActiveUser = _UserRepository.Login(personalnumber, password);
        if (ActiveUser == null)
        {
            return (false, "det fanns ingen med det lösenordet eller personnummret", false);
        }
        else if (ActiveUser.IsLocked == true)
        {
            ActiveUser = null;
            return (false, "ditt konto är låst", false);
        }
        else
        {
            if (ActiveUser.IsAdmin == true)
            {
                return (true, $"välkommen admin {ActiveUser.FName}", true);
            }
            else
            {
                return (true, $"välkommen {ActiveUser.FName}", false);
            }
        }
    }
    // public void Logout(UserAccount userAccount)
    // {
    //     IsLoggedIn = false;
    // }
    // public (bool Success, string Message) AuthCreateAccount(string fname, string lname, string personalnumber, string password)
    // {
    //     if ()
    //     {

    //     }
    // }

}
