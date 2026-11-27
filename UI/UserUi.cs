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
        while (_AuthService.IsLoggedIn)
        {
            System.Console.WriteLine("Hej vad vill du göra?");
            System.Console.WriteLine("1. Skapa ett bank konto");
            System.Console.WriteLine("2. Byta namn på konto");
            System.Console.WriteLine("3. Ta ut pengar från ett konto");
            System.Console.WriteLine("4. Lägga in pengar på ett konto");
            System.Console.WriteLine("5. Gör en överföring mellan konton");
            System.Console.WriteLine("6. se historik på ett konto");
            System.Console.WriteLine("7. Logga ut");
            var isdigit = ReadNumericString(Console.ReadLine() ?? "");
            System.Console.WriteLine(isdigit.message);
            if (isdigit.IsDigit)
            {
                Console.Clear();
                choiseUi(isdigit.output);
            }
        }
    }

    public void choiseUi(string input)
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