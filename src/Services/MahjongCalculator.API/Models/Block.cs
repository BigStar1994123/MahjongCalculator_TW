using MahjongCalculator_TW.Models.Enums;

namespace MahjongCalculator_TW.Models;

public class Block
{
    public BlockType Value { get; set; }

    public SortedDictionary<BlockType, string> Name = new()
    {
        { BlockType.ConcealedTriplet, "暗刻子" },
        { BlockType.ExposedTriplet, "明刻子" },
        { BlockType.ConcealedSequence, "暗順子" },
        { BlockType.ExposedSequence, "明順子" },
        { BlockType.ConcealedKong, "暗槓子" },
        { BlockType.ExposedKong, "明槓子" },
        { BlockType.ConcealedPair, "暗對子" },
        { BlockType.ExposedPair, "明對子" },
    };
}