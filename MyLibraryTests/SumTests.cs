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
}