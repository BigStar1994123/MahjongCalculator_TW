namespace MahjongCalculator_TW.Models.Enums;

public enum MeldedBlockType
{
    Null = -1,

    /// <summary>
    /// 碰
    /// </summary>
    Pong,

    /// <summary>
    /// 吃
    /// </summary>
    Chi,

    /// <summary>
    /// 暗槓
    /// </summary>
    ConcealedKong,

    /// <summary>
    /// 明槓
    /// </summary>
    ExposedKong,

    /// <summary>
    /// 加槓
    /// </summary>
    AdditionalKong,

    Length
}