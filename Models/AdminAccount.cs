public class AdminAccount : IUserAccounts
{
    public int Id { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string PersonalNumber { get; set; }
    public string Password { get; set; }

    public AdminAccount(string fname, string lname, string personalnumber, string password)
    {
        FName = fname;
        LName = lname;
        PersonalNumber = personalnumber;
        Password = password;
    }
    public AdminAccount()
    {

    }
}