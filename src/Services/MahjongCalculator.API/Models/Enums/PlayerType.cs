namespace MahjongCalculator_TW.Models.Enums;

public enum PlayerType
{
    Null = -1,

    /// <summary>
    /// 本家
    /// </summary>
    MySelf,

    /// <summary>
    /// 下家
    /// </summary>
    NextPlayer,

    /// <summary>
    /// 對家
    /// </summary>
    OppositePlayer,

    /// <summary>
    /// 上家
    /// </summary>
    PreviousPlayer,

    Length
}