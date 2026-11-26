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
        Console.Clear();
        System.Console.WriteLine("Hej vad vill du göra?");
        System.Console.WriteLine("1. Skapa ett bank konto");
        System.Console.WriteLine("2. Byta namn på konto");
        System.Console.WriteLine("3. Ta ut pengar från ett konto");
        System.Console.WriteLine("4. Lägga in pengar på ett konto");
        System.Console.WriteLine("5. Gör en överföring mellan konton");
        System.Console.WriteLine("6. se historik på ett konto");
        System.Console.WriteLine("7. Logga ut");
        choise(StringNumberNotLetterNotNullOrWhiteSpace(Console.ReadLine()));
    }

    public void choise(string input)
    {
        switch (input)
        {
            case "1":
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
            case "5":
                break;
            case "6":
                break;
            case "7":
                _AuthService.Logout();
                break;
        }
    }


}