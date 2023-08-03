﻿using MahjongCalculator_TW.src.Models.Enums;

namespace MahjongCalculator_TW.src.Models;

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
        { TileType.RedDragon, "中" },
        { TileType.Plum, "梅" },
        { TileType.Orchid, "蘭" },
        { TileType.Bamboo, "竹" },
        { TileType.Chrysanthemum, "菊" },
        { TileType.Sprint, "春" },
        { TileType.Summor, "夏" },
        { TileType.Fall, "秋" },
        { TileType.Winter, "東" }
    };

    /// <summary>
    /// 是否為萬牌
    /// </summary>
    /// <returns></returns>
    public bool IsCharacter()
    {
        return this.Value >= TileType.Character1 && this.Value <= TileType.Character9;
    }

    /// <summary>
    /// 是否為筒牌
    /// </summary>
    /// <returns></returns>
    public bool IsDot()
    {
        return this.Value >= TileType.Dot1 && this.Value <= TileType.Dot9;
    }

    /// <summary>
    /// 是否為條牌
    /// </summary>
    /// <returns></returns>
    public bool IsBamboo()
    {
        return this.Value >= TileType.Bamboo1 && this.Value <= TileType.Bamboo9;
    }

    /// <summary>
    /// 是否為數牌
    /// </summary>
    /// <returns></returns>
    public bool IsNumber()
    {
        return this.Value < TileType.EastWind && this.Value != TileType.Null;
    }

    /// <summary>
    /// 是否為字牌
    /// </summary>
    /// <returns></returns>
    public bool IsHonor()
    {
        return this.Value >= TileType.EastWind && this.Value <= TileType.RedDragon;
    }

    /// <summary>
    /// 是否為花牌
    /// </summary>
    /// <returns></returns>
    public bool IsFlowerSeason()
    {
        return this.Value >= TileType.Plum && this.Value <= TileType.Winter;
    }
}