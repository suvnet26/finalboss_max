using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
public class BankAccountRepositories
{
    private readonly string _connectionString;

    public BankAccountRepositories(string connectionString)
    {
        _connectionString = connectionString;
    }
    public void CreateBankAccount()
    {

    }


}