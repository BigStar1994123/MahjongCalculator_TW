using TaiwaneseMahjongCalculator.src.Models.Enums;

namespace TaiwaneseMahjongCalculator.src.Models;

public class Tile
{
    public TileType Value { get; set; }

    public SortedDictionary<TileType, string> Name = new()
    {
        { TileType.Null, "Null" },
        { TileType.Manzu1, "一萬" },
        { TileType.Manzu2, "二萬" },
        { TileType.Manzu3, "三萬" },
        { TileType.Manzu4, "四萬" },
        { TileType.Manzu5, "五萬" },
        { TileType.Manzu6, "六萬" },
        { TileType.Manzu7, "七萬" },
        { TileType.Manzu8, "八萬" },
        { TileType.Manzu9, "九萬" },
        { TileType.Pinzu1, "一筒" },
        { TileType.Pinzu2, "二筒" },
        { TileType.Pinzu3, "三筒" },
        { TileType.Pinzu4, "四筒" },
        { TileType.Pinzu5, "五筒" },
        { TileType.Pinzu6, "六筒" },
        { TileType.Pinzu7, "七筒" },
        { TileType.Pinzu8, "八筒" },
        { TileType.Pinzu9, "九筒" },
        { TileType.Sozu1, "一索" },
        { TileType.Sozu2, "二索" },
        { TileType.Sozu3, "三索" },
        { TileType.Sozu4, "四索" },
        { TileType.Sozu5, "五索" },
        { TileType.Sozu6, "六索" },
        { TileType.Sozu7, "七索" },
        { TileType.Sozu8, "八索" },
        { TileType.Sozu9, "九索" },
        { TileType.Ton, "東" },
        { TileType.Nan, "南" },
        { TileType.Sya, "西" },
        { TileType.Pe, "北" },
        { TileType.Haku, "白" },
        { TileType.Hatu, "發" },
        { TileType.Tyun, "中" }
    };

    public bool IsManzu()
    {
        return TileType.Manzu1 <= this.Value && this.Value <= TileType.Manzu9;
    }

    public bool IsPinzu()
    {
        return TileType.Pinzu1 <= this.Value && this.Value <= TileType.Pinzu9;
    }

    public bool IsSozu()
    {
        return TileType.Sozu1 <= this.Value && this.Value <= TileType.Sozu9;
    }

    /// <summary>
    /// 是否為數牌
    /// </summary>
    /// <returns></returns>
    public bool IsSyuhai()
    {
        return this.Value < TileType.Ton || this.Value > TileType.Tyun;
    }

    /// <summary>
    /// 是否為字牌
    /// </summary>
    /// <returns></returns>
    public bool IsZihai()
    {
        return TileType.Ton <= this.Value && this.Value <= TileType.Tyun;
    }
}