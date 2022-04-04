using MahjongCalculator_TW.Models.Enums;
using MahjongCalculator_TW.src.Models.Enums;

namespace MahjongCalculator_TW.Models;

public class MeldedBlock : Block
{
    /// <summary>
    /// 副露的種類
    /// </summary>
    public MeldedBlockType Type { get; set; }

    public List<TileType> Tiles { get; set; } = new List<TileType>();

    public TileType DiscardedTile { get; set; }

    public PlayerType FromPlayer { get; set; }
}