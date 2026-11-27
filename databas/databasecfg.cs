public class DatabaseCfg
{
    public static string GetConnection(string filePath = "tokens.txt")
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("kunde inte hitta databas connection filen");
        }
        string preConnectionString = File.ReadAllText("tokens.txt");
        string[] connectionItems = preConnectionString.Split(';');

        return $"""
        Server={connectionItems[0]};
        Port={connectionItems[1]};
        Database={connectionItems[2]};
        User={connectionItems[3]};
        Password={connectionItems[4]};
    """;
    }
}