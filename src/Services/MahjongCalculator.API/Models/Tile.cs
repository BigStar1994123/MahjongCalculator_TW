using TaiwaneseMahjongCalculator.src.Models.Enums;

namespace TaiwaneseMahjongCalculator.src.Models;

/// <summary>
/// 牌面
/// </summary>
public class Tile
{
    public TileType Value { get; set; }

    public SortedDictionary<TileType, string> Name = new()
    {
        { TileType.Null, "Null" },
        { TileType.Character1, "一萬" },
        { TileType.Character2, "二萬" },
        { TileType.Character3, "三萬" },
        { TileType.Character4, "四萬" },
        { TileType.Character5, "五萬" },
        { TileType.Character6, "六萬" },
        { TileType.Character7, "七萬" },
        { TileType.Character8, "八萬" },
        { TileType.Character9, "九萬" },
        { TileType.Dot1, "一筒" },
        { TileType.Dot2, "二筒" },
        { TileType.Dot3, "三筒" },
        { TileType.Dot4, "四筒" },
        { TileType.Dot5, "五筒" },
        { TileType.Dot6, "六筒" },
        { TileType.Dot7, "七筒" },
        { TileType.Dot8, "八筒" },
        { TileType.Dot9, "九筒" },
        { TileType.Bamboo1, "一索" },
        { TileType.Bamboo2, "二索" },
        { TileType.Bamboo3, "三索" },
        { TileType.Bamboo4, "四索" },
        { TileType.Bamboo5, "五索" },
        { TileType.Bamboo6, "六索" },
        { TileType.Bamboo7, "七索" },
        { TileType.Bamboo8, "八索" },
        { TileType.Bamboo9, "九索" },
        { TileType.EastWind, "東" },
        { TileType.SouthWind, "南" },
        { TileType.WestWind, "西" },
        { TileType.NorthWind, "北" },
        { TileType.WhiteDragon, "白" },
        { TileType.GreenDragon, "發" },
        { TileType.RedDragon, "中" }
    };

    public bool IsCharacter()
    {
        return TileType.Character1 <= this.Value && this.Value <= TileType.Character9;
    }

    public bool IsDot()
    {
        return TileType.Dot1 <= this.Value && this.Value <= TileType.Dot9;
    }

    public bool IsBamboo()
    {
        return TileType.Bamboo1 <= this.Value && this.Value <= TileType.Bamboo9;
    }

    /// <summary>
    /// 是否為數牌
    /// </summary>
    /// <returns></returns>
    public bool IsNumber()
    {
        return this.Value < TileType.EastWind || this.Value > TileType.RedDragon;
    }

    /// <summary>
    /// 是否為字牌
    /// </summary>
    /// <returns></returns>
    public bool IsHonor()
    {
        return TileType.EastWind <= this.Value && this.Value <= TileType.RedDragon;
    }
}