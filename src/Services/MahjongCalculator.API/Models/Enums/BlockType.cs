namespace MahjongCalculator_TW.Models.Enums;

public enum BlockType
{
    Null = -1,

    /// <summary>
    /// 暗刻子
    /// </summary>
    ConcealedTriplet,

    /// <summary>
    /// 明刻子
    /// </summary>
    ExposedTriplet,

    /// <summary>
    /// 暗順子
    /// </summary>
    ConcealedSequence,

    /// <summary>
    /// 明順子
    /// </summary>
    ExposedSequence,

    /// <summary>
    /// 暗槓子
    /// </summary>
    ConcealedKong,

    /// <summary>
    /// 明槓子
    /// </summary>
    ExposedKong,

    /// <summary>
    /// 暗對子
    /// </summary>
    ConcealedPair,

    /// <summary>
    /// 明對子
    /// </summary>
    ExposedPair,

    Length

    /* 二進位版本
    Null = 0,

    /// <summary>
    /// 刻子
    /// </summary>
    Triplet = 1,

    /// <summary>
    /// 順子
    /// </summary>
    Sequence = 2,

    /// <summary>
    /// 槓子
    /// </summary>
    Kong = 4,

    /// <summary>
    /// 對子
    /// </summary>
    Pair = 8,

    /// <summary>
    /// 是否為副露
    /// </summary>
    Open = 16,

    Length = 6
    */
}