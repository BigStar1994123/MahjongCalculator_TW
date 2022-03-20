namespace mahjong.BlockType
{
    public static class Globals
    {
        internal SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Kotu, "暗刻子"},
        {Kotu | Open, "明刻子"},
        {Syuntu, "暗順子"},
        {Syuntu | Open, "明順子"},
        {Kantu, "暗槓子"},
        {Kantu | Open, "明槓子"},
        {Toitu, "暗対子"},
        {Toitu | Open, "明対子"}
    };
    }
}

namespace mahjong.WaitType
{
    public static class Globals
    {
        internal SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Null, "Null"},
        {Ryanmen, "両面待ち"},
        {Pentyan, "辺張待ち"},
        {Kantyan, "嵌張待ち"},
        {Syanpon, "双ポン待ち"},
        {Tanki, "単騎待ち"}
    };
    }
}

namespace mahjong.MeldType
{
    public static class Globals
    {
        internal SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Null, "Null"},
        {Pon, "ポン"},
        {Ti, "チー"},
        {Ankan, "暗槓"},
        {Minkan, "明槓"},
        {Kakan, "加槓"}
    };
    }
}

namespace mahjong.PlayerType
{
    public static class Globals
    {
        internal SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Null, "Null"},
        {Player0, "プレイヤー1"},
        {Player1, "プレイヤー2"},
        {Player2, "プレイヤー3"},
        {Player3, "プレイヤー4"}
    };
    }
}

namespace mahjong.SeatType
{
    public static class Globals
    {
        internal SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Null, "Null"},
        {Zitya, "自家"},
        {Kamitya, "上家"},
        {Toimen, "対面"},
        {Simotya, "下家"}
    };
    }
}

namespace mahjong.HandFlag
{
    public static class Globals
    {
        internal SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Null, "Null"},
        {Tumo, "自摸和了"},
        {Reach, "立直成立"},
        {Ippatu, "一発成立"},
        {Tyankan, "搶槓成立"},
        {Rinsyankaiho, "嶺上開花成立"},
        {Haiteitumo, "海底撈月成立"},
        {Hoteiron, "河底撈魚成立"},
        {DoubleReach, "ダブル立直成立"},
        {NagasiMangan, "流し満貫成立"},
        {Tenho, "天和成立"},
        {Tiho, "地和成立"},
        {Renho, "人和成立"}
    };
    }
}

namespace mahjong.Hu
{
    public static class Globals
    {
        internal static SortedDictionary<int, int> Values = new SortedDictionary<int, int>()
    {
        {Null, -1},
        {Hu20, 20},
        {Hu25, 25},
        {Hu30, 30},
        {Hu40, 40},
        {Hu50, 50},
        {Hu60, 60},
        {Hu70, 70},
        {Hu80, 80},
        {Hu90, 90},
        {Hu100, 100},
        {Hu110, 110}
    };

        internal static SortedDictionary<int, int> Keys = new SortedDictionary<int, int>()
    {
        {-1, Null},
        {20, Hu20},
        {25, Hu25},
        {30, Hu30},
        {40, Hu40},
        {50, Hu50},
        {60, Hu60},
        {70, Hu70},
        {80, Hu80},
        {90, Hu90},
        {100, Hu100},
        {110, Hu110}
    };

        internal static SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Null, "Null"},
        {Hu20, "20符"},
        {Hu25, "25符"},
        {Hu30, "30符"},
        {Hu40, "40符"},
        {Hu50, "50符"},
        {Hu60, "60符"},
        {Hu70, "70符"},
        {Hu80, "80符"},
        {Hu90, "90符"},
        {Hu100, "100符"},
        {Hu110, "110符"}
    };

        /**
         * @brief 符を切り上げる。
         *
         * @param[in] hu 符
         * @return int 切り上げた符
         */

        internal static int round_up_fu(int hu)
        {
            hu = (int)Math.Ceiling(hu / 10.0) * 10;

            switch (hu)
            {
                case 20:
                    return Hu20;

                case 25:
                    return Hu25;

                case 30:
                    return Hu30;

                case 40:
                    return Hu40;

                case 50:
                    return Hu50;

                case 60:
                    return Hu60;

                case 70:
                    return Hu70;

                case 80:
                    return Hu80;

                case 90:
                    return Hu90;

                case 100:
                    return Hu100;

                case 110:
                    return Hu110;
            }

            return Null;
        }
    }
}

namespace mahjong.ScoreTitle
{
    public static class Globals
    {
        internal static SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Null, "Null"},
        {Mangan, "満貫"},
        {Haneman, "跳満"},
        {Baiman, "倍満"},
        {Sanbaiman, "三倍満"},
        {KazoeYakuman, "数え役満"},
        {Yakuman, "役満"},
        {TwoYakuman, "ダブル役満"},
        {ThreeYakuman, "トリプル役満"},
        {FourYakuman, "4倍役満"},
        {FiveYakuman, "5倍役満"},
        {SixYakuman, "6倍役満"}
    };

        /**
         * @brief 役満でない点数のタイトルを取得する。
         *
         * @param[in] hu 符
         * @param[in] han 飜
         * @return int タイトル
         */

        internal static int get_score_title(int fu, int han)
        {
            if (han < 5)
            {
                return ScoringTable.IsMangan[fu][han - 1] ? Mangan : Null;
            }
            if (han == 5)
            {
                return Mangan;
            }
            else if (han <= 7)
            {
                return Haneman;
            }
            else if (han <= 10)
            {
                return Baiman;
            }
            else if (han <= 12)
            {
                return Sanbaiman;
            }
            else
            {
                return KazoeYakuman;
            }
        }

        /**
         * @brief 役満のタイトルを取得する。
         *
         * @param[in] n 何倍役満かを指定する
         * @return int タイトル
         */

        internal static int get_score_title(int n)
        {
            if (n == 1)
            {
                return Yakuman;
            }
            else if (n == 2)
            {
                return TwoYakuman;
            }
            else if (n == 3)
            {
                return ThreeYakuman;
            }
            else if (n == 4)
            {
                return FourYakuman;
            }
            else if (n == 5)
            {
                return FiveYakuman;
            }
            else if (n == 6)
            {
                return SixYakuman;
            }

            return Null;
        }
    }
}

namespace mahjong
{
    public static class Globals
    {
        /**
         * @brief 赤なしの牌を赤牌に変換する。
         *
         * @param tile 赤牌
         * @return int 赤なしの牌
         */

        public static int normal2aka(int tile)
        {
            if (tile == Tile.AkaManzu5)
            {
                return Tile.Manzu5;
            }
            else if (tile == Tile.AkaPinzu5)
            {
                return Tile.Pinzu5;
            }
            else if (tile == Tile.AkaSozu5)
            {
                return Tile.Sozu5;
            }
            else
            {
                return tile;
            }
        }

        /**
         * @brief 赤牌を赤なしの牌に変換する。
         *
         * @param tile 赤牌
         * @return int 赤なしの牌
         */

        public static int aka2normal(int tile)
        {
            if (tile <= Tile.Tyun)
            {
                return tile;
            }
            else if (tile == Tile.AkaManzu5)
            {
                return Tile.Manzu5;
            }
            else if (tile == Tile.AkaPinzu5)
            {
                return Tile.Pinzu5;
            }
            else
            {
                return Tile.Sozu5;
            }
        }

        /**
         * @brief 赤牌かどうかを判定する。
         *
         * @param tile 牌
         * @return bool 赤牌かどうか
         */

        public static bool is_akahai(int tile)
        {
            return tile >= Tile.AkaManzu5;
        }

        /**
         * @brief 萬子かどうかを判定する。
         *
         * @param tile 牌
         * @return bool 萬子かどうか
         */

        public static bool is_manzu(int tile)
        {
            return (Tile.Manzu1 <= tile && tile <= Tile.Manzu9) || tile == Tile.AkaManzu5;
        }

        /**
         * @brief 筒子かどうかを判定する。
         *
         * @param tile 牌
         * @return bool 筒子かどうか
         */

        public static bool is_pinzu(int tile)
        {
            return (Tile.Pinzu1 <= tile && tile <= Tile.Pinzu9) || tile == Tile.AkaPinzu5;
        }

        /**
         * @brief 索子かどうかを判定する。
         *
         * @param tile 牌
         * @return bool 索子かどうか
         */

        public static bool is_sozu(int tile)
        {
            return (Tile.Sozu1 <= tile && tile <= Tile.Sozu9) || tile == Tile.AkaSozu5;
        }

        /**
         * @brief 数牌かどうかを判定する。
         *
         * @param tile 牌
         * @return bool 数牌かどうか
         */

        public static bool is_syuhai(int tile)
        {
            return tile < Tile.Ton || tile > Tile.Tyun;
        }

        /**
         * @brief 字牌かどうかを判定する。
         *
         * @param tile 牌
         * @return bool 字牌かどうか
         */

        public static bool is_zihai(int tile)
        {
            return Tile.Ton <= tile && tile <= Tile.Tyun;
        }
    }
}