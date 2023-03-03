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
}