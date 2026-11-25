using System.Data;
using System.Dynamic;
using Ui;

public class StartUi : BaseUi, IUserInterface
{
    public void run()
    {
        Menu();
    }
    public void Menu()
    {

        System.Console.WriteLine("Vill du logga in");
        System.Console.WriteLine("Vill du skapa ett konto?");
        StartChoice(InputValidator("1: Skapa konto / 2: Logga in"));
    }
    public UserAccount? ActiveUser { get; private set; }
    private readonly UserRepository _userRepository = new();

    public void StartChoice(string input)
    {
        switch (input)
        {
            case "1":

                ActiveUser = _userRepository.CreateAccount(InputValidator("skriv ditt förnamn"), InputValidator("skriv ditt efternamn"), InputValidator("skriv ditt personnummer xxxx-xx-xx"), InputValidator("skriv ditt lösenord"));
                break;
            case "2":
                ActiveUser = _userRepository.
                break;
        }
    }

}