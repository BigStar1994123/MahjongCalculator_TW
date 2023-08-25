using MahjongCalculator_TW.src.Models;
using MahjongCalculator_TW.src.Models.Enums;

namespace MahjongCalculator_TW.Services;

public class RequitedTileSelector
{
    public static List<TileType> Select(Hand hand)
    {
        return SelectNormal(hand);
    }

    public static List<TileType> SelectNormal(Hand hand)
    {
        var shanten = ShantenCalculator.Calculate(hand);
        if (shanten < 0)
            return new List<TileType>(); // Return empty list
    }
}