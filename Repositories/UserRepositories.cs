namespace Repositories;

using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using Microsoft.VisualBasic;

public class UserRepository
{
    private readonly string _connectionString;
    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }


    public UserAccount? CreateAccount(string fname, string lname, string personalnumber, string hashedPassword)
    {
        using IDbConnection connection = new MySqlConnection(_connectionString);

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
        using IDbConnection connection = new MySqlConnection(_connectionString);

        string sql = """
                 SELECT Id, FName, LName, PersonalNumber, Password, IsLocked
                 FROM UserAccount
                 WHERE PersonalNumber = @personalnumber;
                 """;

        return connection.QueryFirstOrDefault<UserAccount>(sql, new { personalnumber });
    }

    public AdminAccount? GetAdminByPersonalNumber(string personalnumber)
    {
        using IDbConnection connection = new MySqlConnection(_connectionString);

        string sql = """
                 SELECT Id, Name, PersonalNumber, Password
                 FROM AdminAccount
                 WHERE PersonalNumber = @personalnumber;
                 """;

        return connection.QueryFirstOrDefault<AdminAccount>(sql, new { personalnumber });
    }




}
