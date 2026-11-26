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

    //.  2003-09-10-0477
    public (bool succes, string message, string? personnummer) Validate_PersonalNumber_input(string? input)
    {
        if (string.IsNullOrWhiteSpace(input) || input.Length != 15)
        {
            return (false, "Det måste vara 15 tecken", null);
        }
        if (input[4] != '-' || input[7] != '-' || input[10] != '-')
        {
            return (false, "bindesstrecken måste sitta på rätt plats", null);
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (i == 4 || i == 7 || i == 10)
                continue;
            if (!char.IsDigit(input[i]))
            {
                return (false, "Alla andra tecken måste vara siffror.", null);
            }
        }
        return (true, "lyckades", input);
    }


}