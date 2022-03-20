namespace mahjong
{

    /**
     * @brief 副露の種類
     */
    namespace MeldType
    {

        //C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named by the converter:
        public enum AnonymousEnum
        {
            Null = -1,
            Pon, // ポン
            Ti, // チー
            Ankan, // 暗槓
            Minkan, // 明槓
            Kakan, // 加槓
            Length
        }

    } // namespace MeldType

    /**
     * @brief プレイヤーの種類
     */
    namespace PlayerType
    {

        //C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named by the converter:
        public enum AnonymousEnum2
        {
            Null = -1,
            Player0,
            Player1,
            Player2,
            Player3,
            Length
        }

    } // namespace PlayerType

    /**
     * @brief 座席の種類
     */
    namespace SeatType
    {

        //C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named by the converter:
        public enum AnonymousEnum3
        {
            Null = -1,
            Zitya, // 自家
            Kamitya, // 上家
            Toimen, // 対面
            Simotya, // 下家
            Length
        }

    } // namespace SeatType

    /**
     * @brief 副露ブロック
     */
    public class MeldedBlock
    {
        public MeldedBlock()
        {
            this.type = MeldType.Null;
            this.discarded_tile = Tile.Null;
            this.from = PlayerType.Null;
        }

        public MeldedBlock(int type, List<int> tiles)
        {
            this.type = type;
            this.tiles = new List<int>(tiles);
            this.discarded_tile = tiles.Count > 0 ? tiles[0] : Tile.Null;
            this.from = PlayerType.Player0;
        }

        public MeldedBlock(int type, List<int> tiles, int discarded_tile, int from)
        {
            this.type = type;
            this.tiles = new List<int>(tiles);
            this.discarded_tile = discarded_tile;
            this.from = from;
        }


        /**
         * @brief 文字列に変換する。
         *
         * @return std::string ブロックを表す文字列
         */
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline string to_string() const
        public string to_string()
        {
            string s;

            s += "[";
            foreach (var tile in tiles)
            {
                if (mahjong.Globals.is_akahai(tile))
                {
                    s += "r5";
                }
                else if (mahjong.Globals.is_manzu(tile))
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
            s += fmt.format(", {}]", mahjong.MeldType.Globals.Name[type]);

            return s;
        }

        /*! 副露の種類 */
        public int type;

        /*! 構成牌 */
        public List<int> tiles = new List<int>();

        /*! 鳴いた牌 */
        public int discarded_tile;

        /*! 鳴かれたプレイヤー */
        public int from;
    }

} // namespace mahjong

