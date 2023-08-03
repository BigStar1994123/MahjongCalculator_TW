using MahjongCalculator_TW.src.Models;
using Xunit;

namespace FunctionalTests;

public class HandTests
{
    [Theory]
    [InlineData(new int[] { 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 27, 27, 27 }, // 11123456789萬東東東
        0b011001001001001001001001011, // 52728395
        0b0,
        0b0,
        0b011)]
    [InlineData(new int[] { 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 29, 29, 29 }, // 11123456789萬西西西
        0b011001001001001001001001011, // 52728395
        0b0,
        0b0,
        0b011000000)]
    [InlineData(new int[] { 13, 13, 13, 14, 14, 14, 15, 15, 15, 16, 16, 16, 27, 28, 29, 30 }, // 555666777888筒東南西北
        0b0,
        0b000011011011011000000000000, // 7188480
        0b0,
        0b001001001001)] // 585
    [InlineData(new int[] { 0, 1, 2, 12, 13, 14, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33 }, // 123萬456筒789條東南西北白發中
        0b001001001, // 73
        0b001001001000000000, // 37376
        0b001001001000000000000000000, // 19136512
        0b001001001001001001001)] // 299593
    public void Test_Hand_Convert_Correct(int[] tiles, long exceptedCharacters, long exceptedDots, long exceptedBamboos, long exceptedHonors)
    {
        // Arrange
        // Act
        var hand = new Hand(tiles);

        // Assert
        Assert.Equal(hand.Characters, exceptedCharacters);
        Assert.Equal(hand.Dots, exceptedDots);
        Assert.Equal(hand.Bamboo, exceptedBamboos);
        Assert.Equal(hand.Honors, exceptedHonors);
    }
}