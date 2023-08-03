namespace MahjongCalculator_TW;

public class ReadyHandCountCalculator
{
    public static int HandLength(List<List<int>> hand)
    {
        int s = 0;
        foreach (var suit in hand)
        {
            foreach (var tileCount in suit)
            {
                s += tileCount;
            }
        }
        return s;
    }

    public static int MeltTargetCount(List<List<int>> hand)
    {
        var length = HandLength(hand);
        return length / 3;
    }

    public static int CalculateReadyHandCountNormal(List<List<int>> hand, int target)
    {
        static int MeltFormula(int deficit, int taatsu, int pairExists)
        {
            if (taatsu < deficit + 1)
            {
                return 2 * deficit - taatsu;
            }
            else
            {
                return deficit - 1;
            }
        };
    }

    public static Tuple<int, int, int> CalOptimalSuitCombination(List<int> suit, bool isZi)
    {
        // 請實現計算 suit 中最佳組合的邏輯，並返回 Tuple<int, int, int> 物件
        // 第一個元素代表不足的牌數，第二個元素代表最大的對子數量，第三個元素代表已經存在的對子數量
        // 可根據 suit 的內容進行計算
        throw new NotImplementedException();
    }

    public static int Execute(List<List<int>> hand, int? target = null)
    {
        var stats = new List<Tuple<int, int, int>>
        {
            CalOptimalSuitCombination(hand[0], false),  // man
            CalOptimalSuitCombination(hand[1], false),  // pin
            CalOptimalSuitCombination(hand[2], false),  // sou
            CalOptimalSuitCombination(hand[3], true)   // zi
        };

        return 0;
    }
}