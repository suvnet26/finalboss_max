using Xunit;
using Ui;
namespace Internetbanken.Tests;

public class ValidatorsTests
{
    [Theory]
    [InlineData("1990-01-15-1234", true)] // inte inehåller 15 tecken
    //testet ska se så att input är ett giltigt personnummer xxxx-xx-xx-xxxx
    public void Validate_PersonalNumber_input(string input, bool expectedresult)
    {
        //förbered
        BaseUi baseUi = new();
        //gör
        var result = baseUi.Validate_PersonalNumber_input(input);

        //utför
        Assert.Equal(expectedresult, result.succes);

    }
}