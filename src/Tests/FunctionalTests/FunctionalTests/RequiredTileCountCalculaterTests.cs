using MahjongCalculator_TW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

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