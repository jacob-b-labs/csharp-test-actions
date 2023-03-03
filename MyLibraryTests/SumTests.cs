using Xunit;
using MyLibrary;

namespace MyLibraryTests;

public class UnitTest1
{
    [Fact]
    public void ReturnsZeroForEmptyString()
    {
        Assert.Equal(0, MyClass.Sum(""));
    }

    [Theory]
    [InlineData("0", 0)]
    [InlineData("14", 14)]
    [InlineData("366", 366)]
    [InlineData("1000", 1000)]
    public void ReturnsValueForSingleNumber(string Input, int Expected)
    {
        Assert.Equal(Expected, MyClass.Sum(Input));
    }

    [Theory]
    [InlineData("0,23", 23)]
    [InlineData("14,3,,7", 24)]
    [InlineData("366,23,1", 390)]
    [InlineData("1000,23,1,10,100", 1134)]
    [InlineData(",,,,,", 0)]
    public void ReturnsSumOfNumbersSeparatedByComma(string Input, int Expected)
    {
        Assert.Equal(Expected, MyClass.Sum(Input));
    }
}