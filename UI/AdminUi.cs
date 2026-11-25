using Ui;

public class AdminUi : IUserInterface
{
    public void run()
    {
        AdminMenu();
    }
    private readonly UserAccount _ActiveUser;
    public AdminUi(UserAccount activeuser)
    {
        _ActiveUser = activeuser;
    }
    public void AdminMenu()
    {

    }
}