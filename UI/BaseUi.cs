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
}