using MahjongCalculator_TW.src.Models.Enums;

namespace MahjongCalculator_TW;

public static class TileAnalyzer
{
    /// Spilt tiles
    /// Ex: tiles:
    /// [0, 1, 4, 6, 6, 10, 10, 10, 12, 14, 16, 21, 21, 22]
    /// 一  二 五 七 七  二  二  二   四  六  八  四  四  五
    /// 萬  萬 萬 萬 萬  筒  筒  筒   筒  筒  筒  索  索  索
    public static (List<int> Characters, List<int> Dots, List<int> Bamboos, List<int> Honors) Split(List<int> tiles)
    {
        var characters = Enumerable.Repeat(0, 9).ToList();
        var dots = Enumerable.Repeat(0, 9).ToList();
        var Bamboos = Enumerable.Repeat(0, 9).ToList();
        var honors = Enumerable.Repeat(0, 7).ToList();

        foreach (var tile in tiles)
        {
            if (tile >= (int)TileType.Character1 && tile <= (int)TileType.Character9)
            {
                var index = tile;
                characters[index]++;
            }
            else if (tile >= (int)TileType.Dot1 && tile <= (int)TileType.Dot9)
            {
                var index = tile - (int)TileType.Dot1;
                dots[index]++;
            }
            else if (tile >= (int)TileType.Bamboos1 && tile <= (int)TileType.Bamboos9)
            {
                var index = tile - (int)TileType.Bamboos1;
                Bamboos[index]++;
            }
            else if (tile >= (int)TileType.EastWind && tile <= (int)TileType.RedDragon)
            {
                var index = tile - (int)TileType.EastWind;
                honors[index]++;
            }
            else
                throw new ArgumentException("Tile value is not correct.");
        }

        return (characters, dots, Bamboos, honors);
    }
}