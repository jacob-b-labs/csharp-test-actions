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

    [Theory]
    [InlineData("0\n23", 23)]
    [InlineData("14\n3\n\n7", 24)]
    [InlineData("366\n23\n1", 390)]
    [InlineData("1000\n23\n1\n10\n100", 1134)]
    [InlineData("\n\n\n\n\n", 0)]
    public void ReturnsSumOfNumbersSeparatedByNewLine(string Input, int Expected)
    {
        Assert.Equal(Expected, MyClass.Sum(Input));
    }

    [Theory]
    [InlineData("0\n23,14", 37)]
    [InlineData("14\n3,\n7", 24)]
    [InlineData("366,23\n1", 390)]
    [InlineData("1000,23\n1,10\n100", 1134)]
    [InlineData(",\n\n,,\n", 0)]
    public void ReturnsSumOfNumbersSeparatedByCommaOrNewLine(string Input, int Expected)
    {
        Assert.Equal(Expected, MyClass.Sum(Input));
    }

    [Theory]
    [InlineData("1000,999,1001", 1999)]
    [InlineData("1000,1000", 2000)]
    [InlineData("1000", 1000)]
    [InlineData("1001", 0)]
    public void IgnoresNumbersLargerThan1000(string Input, int Expected)
    {
        Assert.Equal(Expected, MyClass.Sum(Input));
    }

    [Theory]
    [InlineData("1000,-5,235235")]
    [InlineData("-3")]
    public void ThrowsOnNegativeNumber(string Input)
    {
        Assert.Throws<ArgumentException>(() => MyClass.Sum(Input));
    }

    [Theory]
    [InlineData("/$/0\n23$14", 37)]
    [InlineData("/%/14\n3,%7", 24)]
    [InlineData("/*/1000,23*1*10\n100", 1134)]
    [InlineData("/@/,\n@@\n,@,\n", 0)]
    public void AcceptsCustomDelimiterChar(string Input, int Expected)
    {
        Assert.Equal(Expected, MyClass.Sum(Input));
    }

    [Theory]
    [InlineData("/[ABCD]/0\n23ABCD14", 37)]
    [InlineData("/@@/,\n@@\n,@@,\n", 0)]
    public void AcceptsCustomDelimiterString(string Input, int Expected)
    {
        Assert.Equal(Expected, MyClass.Sum(Input));
    }
}