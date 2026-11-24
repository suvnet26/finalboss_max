using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

public class Repository
{
    static string preConnectionString = File.ReadAllText("tokens.txt");
    static string[] connectionItems = preConnectionString.Split(';');

    static string connectionString = $"""
        Server={connectionItems[0]};
        Port={connectionItems[1]};
        Database={connectionItems[2]};
        User={connectionItems[3]};
        Password={connectionItems[4]};
    """;

}