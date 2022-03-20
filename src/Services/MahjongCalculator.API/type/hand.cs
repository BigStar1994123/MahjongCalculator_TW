//====================================================================================================
//The Free Edition of C++ to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-cplus-to-csharp.html
//====================================================================================================

//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include <spdlog/spdlog.h>

namespace mahjong
{
    /**
     * @brief 手牌
     */

    public class Hand
    {
        /**
         * @brief 手牌を作成する。
         */

        public Hand()
        {
            this.manzu = 0;
            this.pinzu = 0;
            this.sozu = 0;
            this.zihai = 0;
            this.aka_manzu5 = false;
            this.aka_pinzu5 = false;
            this.aka_sozu5 = false;
        }

        /**
         * @brief 手牌を作成する。
         *
         * @param[in] tiles 牌の一覧
         */

        public Hand(in List<int> tiles)
        {
#if CHECK_ARGUMENT
		if (!check_arguments(tiles, melds))
		{
			return;
		}
#endif

            convert_from_tile34(tiles);
        }

        /**
         * @brief 手牌を作成する。
         *
         * @param[in] tiles 牌の一覧
         * @param[in] melds 副露ブロックの一覧
         */

        public Hand(in List<int> tiles, in List<MeldedBlock> melds)
        {
            this.melds = new List<MeldedBlock>(melds);
#if CHECK_ARGUMENT
		if (!check_arguments(tiles, melds))
		{
			return;
		}
#endif

            convert_from_tile34(tiles);
        }

        /**
         * @brief 門前かどうかを取得する。
         *
         * @return 門前の場合は true、そうでない場合は false を返す。
         */

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline bool is_menzen() const
        public bool is_menzen()
        {
            foreach (var meld in melds)
            {
                if (meld.type != MeldType.Ankan)
                {
                    return false; // 暗槓以外の副露ブロックがある場合
                }
            }

            return true;
        }

        /**
         * @brief 副露しているかどうかを取得する。
         *
         * @return 副露している場合は true、そうでない場合は false を返す。
         */

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline bool is_melded() const
        public bool is_melded()
        {
            return melds.Count > 0;
        }

        /**
         * @brief 指定した牌が手牌に含まれるかどうかを調べる。赤牌は通常の牌は区別しません。
         *
         * @param[in] tile 牌
         * @return 指定した牌が手牌に含まれる場合は true、そうでない場合は false を返す。
         */

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline bool contains(int tile) const
        public bool contains(int tile)
        {
            if (tile <= Tile.Manzu9 || tile == Tile.AkaManzu5)
            {
                return manzu & Bit.mask[tile] != null;
            }
            else if (tile <= Tile.Pinzu9 || tile == Tile.AkaPinzu5)
            {
                return pinzu & Bit.mask[tile] != null;
            }
            else if (tile <= Tile.Sozu9 || tile == Tile.AkaSozu5)
            {
                return sozu & Bit.mask[tile] != null;
            }
            else
            {
                return zihai & Bit.mask[tile] != null;
            }
        }

        /**
         * @brief 手牌にある指定した牌の枚数を取得する。赤牌は通常の牌は区別しません。
         *
         * @param[in] tile 牌
         * @return int 牌の枚数
         */

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline int num_tiles(int tile) const
        public int num_tiles(int tile)
        {
            tile = mahjong.Globals.aka2normal(tile);

            if (tile <= Tile.Manzu9)
            {
                return Bit.num_tiles(new key_type(manzu), tile);
            }
            else if (tile <= Tile.Pinzu9)
            {
                return Bit.num_tiles(new key_type(pinzu), tile - 9);
            }
            else if (tile <= Tile.Sozu9)
            {
                return Bit.num_tiles(new key_type(sozu), tile - 18);
            }
            else
            {
                return Bit.num_tiles(new key_type(zihai), tile - 27);
            }
        }

        /**
         * @brief 手牌にある牌の合計枚数を取得する。
         *
         * @return int 牌の合計枚数
         */

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline int num_tiles() const
        public int num_tiles()
        {
            return Bit.sum(new key_type(manzu)) + Bit.sum(new key_type(pinzu)) + Bit.sum(new key_type(sozu)) + Bit.sum(new key_type(zihai));
        }

        /**
         * @brief 手牌を表す MPS 表記の文字列を取得する。
         *        例: 1112r56789m1122p
         *
         * @return std::string 文字列
         */

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline string to_string() const
        public string to_string()
        {
            string s;

            // 萬子
            for (int i = 0; i < 9; ++i)
            {
                int n = Bit.num_tiles(new key_type(manzu), i);

                s += aka_manzu5 && i == 4 ? "r" : "";
                for (int j = 0; j < n; ++j)
                {
                    s += Convert.ToString(i + 1);
                }
            }
            if (manzu != null)
            {
                s += "m";
            }

            // 筒子
            for (int i = 0; i < 9; ++i)
            {
                int n = Bit.num_tiles(new key_type(pinzu), i);

                s += aka_pinzu5 && i == 4 ? "r" : "";
                for (int j = 0; j < n; ++j)
                {
                    s += Convert.ToString(i + 1);
                }
            }
            if (pinzu != null)
            {
                s += "p";
            }

            // 索子
            for (int i = 0; i < 9; ++i)
            {
                int n = Bit.num_tiles(new key_type(sozu), i);

                s += aka_sozu5 && i == 4 ? "r" : "";
                for (int j = 0; j < n; ++j)
                {
                    s += Convert.ToString(i + 1);
                }
            }
            if (sozu != null)
            {
                s += "s";
            }

            // 字牌
            for (int i = 0; i < 9; ++i)
            {
                int n = Bit.num_tiles(new key_type(zihai), i);
                for (int j = 0; j < n; ++j)
                {
                    s += Tile.Name.at(27 + i);
                }
            }

            // 副露ブロック
            if (!string.IsNullOrEmpty(s) && melds.Count > 0)
            {
                s += " ";
            }
            foreach (var block in melds)
            {
                s += block.to_string();
            }

            return s;
        }

        /**
         * @brief 牌の一覧からビット列を作成する。
         *
         * @param[in] tiles 牌の一覧
         */

        private void convert_from_tile34(in List<int> tiles)
        {
            manzu = pinzu = sozu = zihai = 0;
            aka_manzu5 = aka_pinzu5 = aka_sozu5 = false;

            foreach (var tile in tiles)
            {
                aka_manzu5 |= tile == Tile.AkaManzu5;
                aka_pinzu5 |= tile == Tile.AkaPinzu5;
                aka_sozu5 |= tile == Tile.AkaSozu5;

                if (tile <= Tile.Manzu9 || tile == Tile.AkaManzu5)
                {
                    manzu += Bit.tile1[tile];
                }
                else if (tile <= Tile.Pinzu9 || tile == Tile.AkaPinzu5)
                {
                    pinzu += Bit.tile1[tile];
                }
                else if (tile <= Tile.Sozu9 || tile == Tile.AkaSozu5)
                {
                    sozu += Bit.tile1[tile];
                }
                else
                {
                    zihai += Bit.tile1[tile];
                }
            }
        }


    /**
	 * @brief 引数が問題ないかどうかを調べる。
	 *
	 * @param[in] tiles 牌の一覧
	 * @param melds 副露ブロックの一覧
	 * @return 引数が問題ない場合は true、そうでない場合は false を返す。
	 */

//====================================================================================================
//End of the allowed output for the Free Edition of C++ to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-cplus-to-csharp.html
//====================================================================================================