using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

public class UserRepository
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

    public UserAccount CreateAccount(string fname, string lname, string personalnumber, string password)
    {
        using IDbConnection connection = new MySqlConnection(connectionString);

        string CreateUserAccountSql = """
                                INSERT INTO UserAccount (FName, LName, PersonalNumber, Password)
                                Values(@fname, @lname, @personalnumber, @password);
                                SELECT * FROM UserAccount
                                WHERE UserAccount.Id = LAST_INSERT_ID()
                                """;
        return connection.QueryFirstOrDefault<UserAccount>(CreateUserAccountSql, new { fname, lname, personalnumber, password });


    }
}