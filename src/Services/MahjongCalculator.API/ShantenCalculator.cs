using MahjongCalculator_TW.Models;
using MahjongCalculator_TW.src.Models;

namespace MahjongCalculator_TW;

public class ShantenCalculator
{
    private static readonly Dictionary<string, ShantenPattern> _shantenSuitDic = new();
    private static readonly Dictionary<string, ShantenPattern> _shantenHonorDic = new();

    static ShantenCalculator()
    {
        using (var sr = new StreamReader("Data/shanten_table_9.txt"))
        {
            var line = string.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(' ');
                var key = data[0];
                var shantenValue = data[1];
                var shantenPattern = new ShantenPattern
                {
                    SetCount = (int)char.GetNumericValue(shantenValue[0]),
                    PartialSetCount = (int)char.GetNumericValue(shantenValue[1]),
                    IsHeadExist = shantenValue[2] == '1',
                    SetWithHeadCount = (int)char.GetNumericValue(shantenValue[3]),
                    PartialSetWithHeadCount = (int)char.GetNumericValue(shantenValue[4]),
                    TileGreatEqual1Count = (int)char.GetNumericValue(shantenValue[5]),
                    TileGreatEqual2Count = (int)char.GetNumericValue(shantenValue[6]),
                    TileGreatEqual3Count = (int)char.GetNumericValue(shantenValue[7]),
                    TileGreatEqual4Count = (int)char.GetNumericValue(shantenValue[8])
                };

                _shantenSuitDic.Add(key, shantenPattern);
            }
        }

        using (var sr = new StreamReader("Data/shanten_table_7.txt"))
        {
            var line = string.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(' ');
                var key = data[0];
                var shantenValue = data[1];
                var shantenPattern = new ShantenPattern
                {
                    SetCount = (int)char.GetNumericValue(shantenValue[0]),
                    PartialSetCount = (int)char.GetNumericValue(shantenValue[1]),
                    IsHeadExist = shantenValue[2] == '1',
                    SetWithHeadCount = (int)char.GetNumericValue(shantenValue[3]),
                    PartialSetWithHeadCount = (int)char.GetNumericValue(shantenValue[4]),
                    TileGreatEqual1Count = (int)char.GetNumericValue(shantenValue[5]),
                    TileGreatEqual2Count = (int)char.GetNumericValue(shantenValue[6]),
                    TileGreatEqual3Count = (int)char.GetNumericValue(shantenValue[7]),
                    TileGreatEqual4Count = (int)char.GetNumericValue(shantenValue[8])
                };

                _shantenHonorDic.Add(key, shantenPattern);
            }
        }
    }

    public static Dictionary<string, ShantenPattern> ShantenSuitDic
    {
        get { return _shantenSuitDic; }
    }

    public static Dictionary<string, ShantenPattern> ShantenHonorDic
    {
        get { return _shantenHonorDic; }
    }

    public static int Calculate(Hand hand)
    {
        int normalShanten = CalculateNormalShanten(hand);

        return normalShanten;
    }

    private static int CalculateNormalShanten(Hand hand)
    {
        var setCountTarget = hand.Length / 3;
        var worstShanten = setCountTarget * 2;
        var meldCount = hand.Melds.Count;

        var setBaseCount = meldCount +
            _shantenSuitDic[hand.GetCharacterKey()].SetCount + _shantenSuitDic[hand.GetDotKey()].SetCount +
            _shantenSuitDic[hand.GetBamboosKey()].SetCount + _shantenHonorDic[hand.GetHonorKey()].SetCount;

        var partialSetBaseCount = _shantenSuitDic[hand.GetCharacterKey()].PartialSetCount + _shantenSuitDic[hand.GetDotKey()].PartialSetCount +
            _shantenSuitDic[hand.GetBamboosKey()].PartialSetCount + _shantenHonorDic[hand.GetHonorKey()].PartialSetCount;

        var max = setBaseCount * 2 + Math.Min(setCountTarget - setBaseCount, partialSetBaseCount);

        if (_shantenSuitDic[hand.GetCharacterKey()].IsHeadExist)
        {
            var setCount =
                setBaseCount
                - _shantenSuitDic[hand.GetCharacterKey()].SetCount
                + _shantenSuitDic[hand.GetCharacterKey()].SetWithHeadCount;

            var partialSetCount =
                partialSetBaseCount
                - _shantenSuitDic[hand.GetCharacterKey()].PartialSetCount
                + _shantenSuitDic[hand.GetCharacterKey()].PartialSetWithHeadCount;

            max = Math.Max(max, (setCount * 2) + Math.Min(setCountTarget - setCount, partialSetCount) + 1);
        }

        if (_shantenSuitDic[hand.GetDotKey()].IsHeadExist)
        {
            var setCount =
                setBaseCount
                - _shantenSuitDic[hand.GetDotKey()].SetCount
                + _shantenSuitDic[hand.GetDotKey()].SetWithHeadCount;

            var partialSetCount =
                partialSetBaseCount
                - _shantenSuitDic[hand.GetDotKey()].PartialSetCount
                + _shantenSuitDic[hand.GetDotKey()].PartialSetWithHeadCount;

            max = Math.Max(max, (setCount * 2) + Math.Min(setCountTarget - setCount, partialSetCount) + 1);
        }

        if (_shantenSuitDic[hand.GetBamboosKey()].IsHeadExist)
        {
            var setCount =
                setBaseCount
                - _shantenSuitDic[hand.GetBamboosKey()].SetCount
                + _shantenSuitDic[hand.GetBamboosKey()].SetWithHeadCount;

            var partialSetCount =
                partialSetBaseCount
                - _shantenSuitDic[hand.GetBamboosKey()].PartialSetCount
                + _shantenSuitDic[hand.GetBamboosKey()].PartialSetWithHeadCount;

            max = Math.Max(max, (setCount * 2) + Math.Min(setCountTarget - setCount, partialSetCount) + 1);
        }

        if (_shantenHonorDic[hand.GetHonorKey()].IsHeadExist)
        {
            var setCount =
                setBaseCount
                - _shantenHonorDic[hand.GetHonorKey()].SetCount
                + _shantenHonorDic[hand.GetHonorKey()].SetWithHeadCount;

            var partialSetCount =
                partialSetBaseCount
                - _shantenHonorDic[hand.GetHonorKey()].PartialSetCount
                + _shantenHonorDic[hand.GetHonorKey()].PartialSetWithHeadCount;

            max = Math.Max(max, (setCount * 2) + Math.Min(setCountTarget - setCount, partialSetCount) + 1);
        }

        return worstShanten - max;
    }
}