using Xunit;
using Ui;
namespace Internetbanken.Tests;

public class ValidatorsTests
{
    [Theory]
    [InlineData("1990-01-15-1234", true)] // inte inehåller 15 tecken
    [InlineData("1990-011234", false)] // kontrollera siffror och bidestecken
    [InlineData("199001-15-1234", false)] // saknar bindestrek på rätt ställe
    [InlineData("1990-01-a5-1234", false)] // kontrollera att det inte finns några bokstäver
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