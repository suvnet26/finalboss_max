namespace Repositories;

using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using Microsoft.VisualBasic;

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

    public UserAccount? CreateAccount(string fname, string lname, string personalnumber, string hashedPassword)
    {
        using IDbConnection connection = new MySqlConnection(connectionString);

        string CreateUserAccountSql = """
                            INSERT INTO UserAccount (FName, LName, PersonalNumber, Password)
                            VALUES (@fname, @lname, @personalnumber, @password);
                            SELECT * FROM UserAccount
                            WHERE UserAccount.Id = LAST_INSERT_ID();
                            """;

        return connection.QueryFirstOrDefault<UserAccount>(CreateUserAccountSql, new
        {
            fname,
            lname,
            personalnumber,
            password = hashedPassword
        });
    }

    public UserAccount? GetUserByPersonalNumber(string personalnumber)
    {
        using IDbConnection connection = new MySqlConnection(connectionString);

        string sql = """
                 SELECT Id, FName, LName, PersonalNumber, Password, IsLocked
                 FROM UserAccount
                 WHERE PersonalNumber = @personalnumber;
                 """;

        return connection.QueryFirstOrDefault<UserAccount>(sql, new { personalnumber });
    }

    public AdminAccount? GetAdminByPersonalNumber(string personalnumber)
    {
        using IDbConnection connection = new MySqlConnection(connectionString);

        string sql = """
                 SELECT Id, Name, PersonalNumber, Password
                 FROM AdminAccount
                 WHERE PersonalNumber = @personalnumber;
                 """;

        return connection.QueryFirstOrDefault<AdminAccount>(sql, new { personalnumber });
    }




}
