using Services;
using Ui;

public class AdminUi : BaseUi, IUserInterface
{
    public void run()
    {
        AdminMenu();
    }
    private readonly IAuthService _AuthService;
    public AdminUi(IAuthService authService)
    {
        _AuthService = authService;
    }
    public void AdminMenu()
    {

    }
}