using MahjongCalculator_TW.Services;
using MahjongCalculator_TW.src.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace FunctionalTests;

public class ShantenCalculatorTests
{
    [Fact]
    public void Test()
    {
        var s = new ShantenTableGenerator();
        s.Execute();
        Assert.True(true);
    }

    [Theory]
    [InlineData(new int[] { 0, 1, 4, 6, 6, 10, 10, 10, 12, 14, 16, 21, 21, 22 }, 2)]
    [InlineData(new int[] { 4, 9, 12, 15, 16, 17, 21, 21, 24, 27, 29, 30, 32, 33 }, 5)]
    [InlineData(new int[] { 1, 1, 3, 3, 4, 4, 5, 6, 7, 8, 8, 31, 33, 33 }, 1)]
    [InlineData(new int[] { 0, 0, 0, 9, 10, 11, 13, 16, 17, 20, 22, 23, 26, 28, 30, 32, 33 }, 4)]
    [InlineData(new int[] { 0, 3, 6, 9, 12, 15, 18, 21, 24, 27, 28, 29, 30, 31, 32, 33 }, 10)]
    [InlineData(new int[] { 0, 0, 0, 1, 2, 4, 4, 5, 7, 7, 8, 16, 16, 17, 28, 28, 33 }, 3)]
    [InlineData(new int[] { 0, 0, 0, 1, 2, 4, 4, 5, 7, 7, 8, 16, 16, 17, 28, 28 }, 3)]
    [InlineData(new int[] { 1, 2, 4, 5, 5, 10, 13, 14, 14, 15, 18, 22, 26, 33, 33, 33 }, 4)]
    [InlineData(new int[] { 0, 1, 2, 4, 5, 7, 8, 10, 11, 13, 14, 16, 17, 18, 20, 26 }, 4)]
    [InlineData(new int[] { 0, 1, 2, 6, 7, 8, 9, 10, 11, 15, 16, 17, 18, 20, 25, 26 }, 1)]
    [InlineData(new int[] { 0, 1, 2, 6, 7, 8, 9, 10, 11, 15, 16, 17, 18, 20, 25, 26, 26 }, 0)]
    public void TestByInlineData(int[] testCase, int expectedShanten)
    {
        var hand = new Hand(testCase.ToList());
        var shanten = ShantenCalculator.Calculate(hand);
        Assert.Equal(expectedShanten, shanten);
    }

    [Fact]
    public void TestFromFile()
    {
        var line = string.Empty;
        var lineIndex = 1;

        var haveError = false;
        var errorSb = new StringBuilder();

        using (var sr = new StreamReader("SyantenTestFile.txt"))
        {
            while ((line = sr.ReadLine()) != null)
            {
                var data = line.Split(' ');
                var tiles = data.Take(14).Select(x => Convert.ToInt32(x)).ToArray();
                var expectedShanten = Convert.ToInt32(data[14]);

                var hand = new Hand(tiles.ToList());
                var shanten = ShantenCalculator.Calculate(hand);

                if (expectedShanten != shanten)
                {
                    errorSb.AppendLine($"Line: {lineIndex} TestCase: {line}, " +
                        $"ExpectedShanten is: {expectedShanten}, Calculated Shanten is {shanten}");
                    haveError = true;
                }

                lineIndex++;
            }

            if (haveError)
            {
                Assert.True(false, errorSb.ToString());
            }

            Assert.True(true);
        }
    }
}