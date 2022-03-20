//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include <spdlog/spdlog.h>

namespace mahjong
{
    /**
     * @brief ブロックの種類
     */

    namespace BlockType
    {
        //C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named by the converter:
        public enum AnonymousEnum
        {
            Null = 0,
            Kotu = 1, // 刻子
            Syuntu = 2, // 順子
            Kantu = 4, // 槓子
            Toitu = 8, // 対子
            Open = 16, // 副露した牌が含まれるかどうか
            Length = 6
        }
    } // namespace BlockType

    /**
     * @brief 待ちの種類
     */

    namespace WaitType
    {
        //C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named by the converter:
        public enum AnonymousEnum2
        {
            Null = -1,
            Ryanmen, // 両面待ち
            Pentyan, // 辺張待ち
            Kantyan, // 嵌張待ち
            Syanpon, // 双ポン待ち
            Tanki // 単騎待ち
        }
    } // namespace WaitType

    /**
     * @brief ブロック
     */

    public class Block
    {
        public Block()
        {
            this.type = BlockType.Null;
            this.min_tile = Tile.Null;
        }

        public Block(int type, int min_tile)
        {
            this.type = type;
            this.min_tile = min_tile;
        }

        /*! ブロックの種類 */
        public int type;

        /*! 最小の構成牌 */
        public int min_tile;

        /**
         * @brief 文字列に変換する。
         *
         * @return std::string ブロックを表す文字列
         */

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline string to_string() const
        public string to_string()
        {
            List<int> tiles = new List<int>();
            if ((type & BlockType.Kotu) != 0)
            {
                for (int i = 0; i < 3; ++i)
                {
                    tiles.Add(min_tile);
                }
            }
            else if (type & BlockType.Syuntu)
            {
                for (int i = 0; i < 3; ++i)
                {
                    tiles.Add(min_tile + i);
                }
            }
            else if (type & BlockType.Kantu)
            {
                for (int i = 0; i < 4; ++i)
                {
                    tiles.Add(min_tile);
                }
            }
            else if (type & BlockType.Toitu)
            {
                for (int i = 0; i < 2; ++i)
                {
                    tiles.Add(min_tile);
                }
            }

            string s;

            s += "[";
            foreach (var tile in tiles)
            {
                if (mahjong.Globals.is_manzu(tile))
                {
                    s += Convert.ToString(tile + 1);
                }
                else if (mahjong.Globals.is_pinzu(tile))
                {
                    s += Convert.ToString(tile - 8);
                }
                else if (mahjong.Globals.is_sozu(tile))
                {
                    s += Convert.ToString(tile - 17);
                }
                else
                {
                    s += Tile.Name.at(tile);
                }
            }

            if (mahjong.Globals.is_manzu(new List<int>(tiles[0])))
            {
                s += "m";
            }
            else if (mahjong.Globals.is_pinzu(new List<int>(tiles[0])))
            {
                s += "p";
            }
            else if (mahjong.Globals.is_sozu(new List<int>(tiles[0])))
            {
                s += "s";
            }
            s += fmt.format(", {}]", mahjong.BlockType.Globals.Name[type]);

            return s;
        }
    }
} // namespace mahjong