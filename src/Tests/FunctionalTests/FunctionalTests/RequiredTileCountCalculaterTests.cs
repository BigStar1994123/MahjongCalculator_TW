using MahjongCalculator_TW;
using Xunit;

namespace FunctionalTests;

public class RequiredTileCountCalculaterTests
{
    [Fact]
    public void Test()
    {
        var b = new RequiredTileTableGenerator();
        b.Execute();
        Assert.True(true);
    }
}