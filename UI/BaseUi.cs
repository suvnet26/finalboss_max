namespace Ui;

public class BaseUi
{
    protected static string InputValidator(string prompt)
    {

        while (true)
        {
            System.Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                System.Console.WriteLine("det kan inte vara tomt, försök igen");
            }
            else return input;
        }
    }

    public (bool succes, string message, string? personnummer) Validate_PersonalNumber_input(string input)
    {
        if (input.Length != 15)
        {
            return (false, "Det måste vara 14 tecken", null);
        }
        return (true, "lyckades", input);
    }


}