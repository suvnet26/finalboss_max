using Services;
using Ui;

public class UserUi : BaseUi, IUserInterface
{
    private readonly IAuthService _AuthService;
    public UserUi(IAuthService authService)
    {
        _AuthService = authService;
    }
    public void run()
    {
        UserMenu();
    }

    public void UserMenu()
    {

    }
}