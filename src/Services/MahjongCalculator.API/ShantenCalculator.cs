using MahjongCalculator_TW.src.Models;

namespace MahjongCalculator_TW;

public class ShantenCalculator
{
    public static int Calculate(List<int> tiles)
    {
        int normalShanten = CalculateNormalShanten(tiles);

        return normalShanten;
    }

    private static int CalculateNormalShanten(List<int> tiles)
    {
        var hand = new Hand(tiles);
        var a = CombinationCounter.CountHonors(hand.Honors);
        //var b = CombinationCounter.C

        throw new NotImplementedException();
    }
}