namespace MahjongCalculator_TW;

public static class CombinationCounter
{
    public static (int SetCount, int PartialSetCount, int PairCount) Count
        (List<int> tiles, int setCount, int partialSetCount, int pairCount)
    {
        // 先找刻子 Find triplets
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i] >= 3)
            {
                setCount++;
                tiles[i] -= 3;
                Count(tiles, setCount, partialSetCount, pairCount);
                tiles[i] += 3;
                setCount--;
            }
        }
    }

    public static (int SetCount, int PairCount) CountHonors(List<int> honorTiles)
    {
        var pairCount = 0;
        var tripletCount = 0;

        for (int i = 0; i < honorTiles.Count; i++)
        {
            switch (honorTiles[i])
            {
                case >= 3:
                    tripletCount++;
                    break;

                case 2:
                    pairCount++;
                    break;
            }
        }

        return (tripletCount, pairCount);
    }
}