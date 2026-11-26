using System.Data;
using System.Dynamic;
using System.Runtime.InteropServices;
using Services;
using Ui;

public class StartUi : BaseUi, IUserInterface
{
    public StartUi(IAuthService authService)
    {
        _AuthService = authService;
    }
    public void run()
    {
        Menu();
    }
    public void Menu()
    {
        while (_AuthService.ActiveUser == null)
        {
            System.Console.WriteLine("Vill du skapa ett konto?");
            System.Console.WriteLine("Vill du logga in?");
            StartChoice(InputValidator("1: Skapa konto / 2: Logga in"));
        }
    }

    private readonly IAuthService _AuthService;

    public void StartChoice(string input)
    {
        switch (input)
        {
            case "1":
                var CreateAccountResult = _AuthService.AuthCreateAccount(InputValidator("skriv ditt förnamn"), InputValidator("skriv ditt efternamn"),
                InputValidator("skriv ditt personnummer xxxx-xx-xx-xxxx"), InputValidator("skriv ditt lösenord"));
                System.Console.WriteLine(CreateAccountResult.Message);
                if (CreateAccountResult.Success)
                {
                    OpenUi(_AuthService.ActiveUser.IsAdmin).run();
                }
                break;
            case "2":
                var LoginResult = _AuthService.AuthLogin(InputValidator("skriv in ditt personnummer"), InputValidator("skriv in dit lösenord"));
                System.Console.WriteLine(LoginResult.Message);
                if (LoginResult.Success)
                {
                    OpenUi(LoginResult.IsAdmin).run();
                }
                break;
            default: System.Console.WriteLine("ogiltigt alternativ"); break;

        }
    }

    private IUserInterface OpenUi(bool IsAdmin)
    {

        if (IsAdmin)
        {
            AdminUi adminUi = new(_AuthService);
            return adminUi;
        }
        UserUi userUi = new(_AuthService);
        return userUi;
    }

}