namespace MahjongCalculator_TW;

public static class TileAnalyzer
{
    public static (List<int> Characters, List<int> Dots, List<int> Bamboo, List<int> Honors) Split(List<int> tiles)
    {
        var characters = Enumerable.Repeat(0, 9).ToList();
        var dots = Enumerable.Repeat(0, 9).ToList();
        var bamboo = Enumerable.Repeat(0, 9).ToList();
        var honors = Enumerable.Repeat(0, 7).ToList();

        for (int i = 0; i < 9; i++)
        {
            characters[i] = tiles[i];
            dots[i] = tiles[i + 9];
            bamboo[i] = tiles[i + 18];
            if (i < 7)
            {
                honors[i] = tiles[i + 27];
            }
        }

        return (characters, dots, bamboo, honors);
    }
}