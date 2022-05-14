using MahjongCalculator_TW.Models;
using MahjongCalculator_TW.src.Models.Enums;
using MahjongCalculator_TW.src.Utils;

namespace MahjongCalculator_TW.src.Models;

public class Hand
{
    /// <summary>
    /// 萬牌
    /// </summary>
    /*! ビット列にした手牌
     * 例: [0, 2, 0, 2, 2, 1, 1, 1, 4] -> 69510160
     * (00|000|100|001|001|001|010|010|000|010|000)
     *         牌9 牌8 牌7 牌6  牌5 牌4 牌3 牌2 牌1
     */
    public uint Characters { get; set; } = 0;

    /// <summary>
    /// 筒牌
    /// </summary>
    public uint Dots { get; set; } = 0;

    /// <summary>
    /// 條牌
    /// </summary>
    public uint Sticks { get; set; } = 0;

    /// <summary>
    /// 字牌
    /// </summary>
    public uint Honors { get; set; } = 0;

    /// <summary>
    /// 副露
    /// </summary>
    public List<MeldedBlock> Melds { get; set; } = new List<MeldedBlock>();

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
            if (tile <= (int)TileType.Character9)
                Characters += Bit.Tile1[tile];
            else if (tile <= (int)TileType.Dot9)
                Dots += Bit.Tile1[tile];
            else if (tile <= (int)TileType.Stick9)
                Sticks += Bit.Tile1[tile];
            else
                Honors += Bit.Tile1[tile];
        }
    }
}