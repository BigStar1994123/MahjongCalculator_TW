using MahjongCalculator_TW.src.Models;

namespace MahjongCalculator_TW;

public class RequiredTileSelector
{
    public IEnumerable<Tile> Select(Hand hand)
    {
        var tiles = new Tile[14];

        Hand hand_after = hand; // 自摸後の手牌

        // 現在の向聴数を計算する。
        int syanten = 0; /*SyantenCalculator::calc_normal(hand);*/

        throw new NotImplementedException();
    }
}