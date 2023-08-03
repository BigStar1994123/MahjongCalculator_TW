namespace MahjongCalculator_TW.Models;

public class ShantenPattern
{
    /// <summary>
    /// 成搭/面子的數量
    /// </summary>
    public int SetCount { get; set; }

    /// <summary>
    /// 散搭/搭子的數量
    /// </summary>
    public int PartialSetCount { get; set; }

    /// <summary>
    /// 是否有將/眼/雀頭
    /// </summary>
    public bool IsHeadExist { get; set; }

    /// <summary>
    /// 有將的情況下，成搭/面子的數量
    /// </summary>
    public int SetWithHeadCount { get; set; }

    /// <summary>
    /// 有將的情況下，散搭/搭子的數量
    /// </summary>
    public int PartialSetWithHeadCount { get; set; }

    /// <summary>
    /// 一張牌以上的個數
    /// </summary>
    public int TileGreatEqual1Count { get; set; }

    /// <summary>
    /// 兩張牌以上的個數
    /// </summary>
    public int TileGreatEqual2Count { get; set; }

    /// <summary>
    /// 三張牌以上的個數
    /// </summary>
    public int TileGreatEqual3Count { get; set; }

    /// <summary>
    /// 四張牌以上的個數
    /// </summary>
    public int TileGreatEqual4Count { get; set; }

    /// <summary>
    /// 總數
    /// </summary>
    private int N { get; set; }
}