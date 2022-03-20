using TaiwaneseMahjongCalculator.src.Models.Enums;
using TaiwaneseMahjongCalculator.src.Utils;

namespace TaiwaneseMahjongCalculator.src.Models;

public class Hand
{
    /// <summary>
    ///
    /// </summary>
    /*! ビット列にした手牌
     * 例: [0, 2, 0, 2, 2, 1, 1, 1, 4] -> 69510160
     * (00|000|100|001|001|001|010|010|000|010|000) 牌9 牌8 牌7 牌6 牌5 牌4 牌3 牌2 牌1
     */
    public uint Manzu { get; set; } = 0;

    public uint Pinzu { get; set; } = 0;

    public uint Sozu { get; set; } = 0;

    public uint ZiHai { get; set; } = 0;

    // TODO: 副露

    // TODO: 持有花牌

    public Hand()
    {
    }

    public Hand(int[] tiles)
    {
        ConvertFromTile34(tiles);
    }

    private void ConvertFromTile34(int[] tiles)
    {
        foreach (var tile in tiles)
        {
            if (tile <= (int)TileType.Manzu9)
                Manzu += Bit.Tile1[tile];
            else if (tile <= (int)TileType.Pinzu9)
                Pinzu += Bit.Tile1[tile];
            else if (tile <= (int)TileType.Sozu9)
                Sozu += Bit.Tile1[tile];
            else
                ZiHai += Bit.Tile1[tile];
        }
    }
}