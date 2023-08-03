using MahjongCalculator_TW.Models;
using MahjongCalculator_TW.src.Models.Enums;
using MahjongCalculator_TW.src.Utils;

namespace MahjongCalculator_TW.src.Models;

public class Hand
{
    /// <summary>
    /// 萬子/万子
    /// </summary>
    public List<int> Characters { get; set; } = Enumerable.Repeat(0, 9).ToList();

    /// <summary>
    /// 筒子
    /// </summary>
    public List<int> Dots { get; set; } = Enumerable.Repeat(0, 9).ToList();

    /// <summary>
    /// 條子/索子
    /// </summary>
    public List<int> Bamboo { get; set; } = Enumerable.Repeat(0, 9).ToList();

    /// <summary>
    /// 字牌
    /// </summary>
    public List<int> Honors { get; set; } = Enumerable.Repeat(0, 7).ToList();

    /// <summary>
    /// 副露
    /// </summary>
    public List<MeldedBlock> Melds { get; set; } = new List<MeldedBlock>();

    // TODO: 持有花牌

    public Hand()
    {
    }

    public Hand(List<int> tiles)
    {
        ConvertFromTiles(tiles);
    }

    private void ConvertFromTiles(List<int> tiles)
    {
        var splitResult = TileAnalyzer.Split(tiles);
        Characters = splitResult.Characters;
        Dots = splitResult.Dots;
        Bamboo = splitResult.Bamboo;
        Honors = splitResult.Honors;
    }
}