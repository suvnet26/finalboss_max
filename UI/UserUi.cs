using Ui;

public class UserUi : BaseUi, IUserInterface
{
    private readonly AuthService _AuthService;
    public UserUi(AuthService authService)
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