using MahjongCalculator_TW.Models;
using System.Text;

namespace MahjongCalculator_TW.src.Models;

/// <summary>
/// 所持手牌
/// </summary>
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
    public List<int> Bamboos { get; set; } = Enumerable.Repeat(0, 9).ToList();

    /// <summary>
    /// 字牌
    /// </summary>
    public List<int> Honors { get; set; } = Enumerable.Repeat(0, 7).ToList();

    /// <summary>
    /// 副露
    /// </summary>
    public List<MeldedBlock> Melds { get; set; } = new List<MeldedBlock>();

    // TODO: 持有花牌

    public int Length { get; set; } = 0;

    public Hand()
    {
    }

    /// <summary>
    /// Constructor Ex: tiles:
    /// [0, 1, 4, 6, 6, 10, 10, 10, 12, 14, 16, 21, 21, 22]
    /// 一  二 五 七 七  二  二  二   四  六  八  四  四  五
    /// 萬  萬 萬 萬 萬  筒  筒  筒   筒  筒  筒  索  索  索
    /// </summary>
    /// <param name="tiles"></param>
    public Hand(List<int> tiles)
    {
        if (tiles.Count <= 2 || tiles.Count % 3 == 0 || tiles.Count >= 18)
        {
            throw new ArgumentException("Tiles count is incorrect.");
        }

        ConvertFromTiles(tiles);
        Length = tiles.Count;
    }

    public string GetCharacterKey()
    {
        return ConvertToKey(Characters);
    }

    public string GetDotKey()
    {
        return ConvertToKey(Dots);
    }

    public string GetBamboosKey()
    {
        return ConvertToKey(Bamboos);
    }

    public string GetHonorKey()
    {
        return ConvertToKey(Honors);
    }

    public override string ToString()
    {
        return $"CharacterKey:{GetCharacterKey()}, DotKey:{GetDotKey()}, " +
            $"BamboosKey:{GetBamboosKey()}, HonorKey:{GetHonorKey()}";
    }

    private void ConvertFromTiles(List<int> tiles)
    {
        var splitResult = TileAnalyzer.Split(tiles);
        Characters = splitResult.Characters;
        Dots = splitResult.Dots;
        Bamboos = splitResult.Bamboos;
        Honors = splitResult.Honors;
    }

    private string ConvertToKey(List<int> tiles)
    {
        if (tiles.Count == 9)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < tiles.Count; i++)
            {
                sb.Append(tiles[i]);
            }

            return sb.ToString();
        }
        else if (tiles.Count == 7)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < tiles.Count; i++)
            {
                sb.Append(tiles[i]);
            }

            sb.Append("00");
            return sb.ToString();
        }

        throw new ArgumentException("Tiles count is not 7 or 9.");
    }
}