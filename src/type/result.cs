//C++ TO C# CONVERTER WARNING: The following #include directive was ignored:
//#include <spdlog/spdlog.h>

namespace mahjong
{

    /**
     * @brief 手牌に関するフラグ
     *
     *    自摸和了の場合は門前かどうかに関わらず、Tumo を指定します。
     *    立直、ダブル立直はどれか1つのみ指定できます。
     *    搶槓、嶺上開花、海底撈月、河底撈魚はどれか1つのみ指定できます。
     *    天和、地和、人和はどれか1つのみ指定できます。
     */
    namespace HandFlag
    {
        //C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named by the converter:
        public enum AnonymousEnum
        {
            Null = 0,
            Tumo = 1 << 1, // 自摸和了
            Reach = 1 << 2, // 立直成立
            Ippatu = 1 << 3, // 一発成立
            Tyankan = 1 << 4, // 搶槓成立
            Rinsyankaiho = 1 << 5, // 嶺上開花成立
            Haiteitumo = 1 << 6, // 海底撈月成立
            Hoteiron = 1 << 7, // 河底撈魚成立
            DoubleReach = 1 << 8, // ダブル立直成立
            NagasiMangan = 1 << 9, // 流し満貫成立
            Tenho = 1 << 10, // 天和成立
            Tiho = 1 << 11, // 地和成立
            Renho = 1 << 12 // 人和成立
        }
    } // namespace HandFlag

    /**
     * @brief 結果
     */
    public class Result
    {
        /**
         * @brief 通常役の結果
         *
         * @param[in] hand 手牌
         * @param[in] win_tile 和了牌
         * @param[in] flag フラグ
         * @param[in] yaku_list (成立した役, 飜) の一覧
         * @param[in] han 翻
         * @param[in] hu 符
         * @param[in] score_title 点数のタイトル
         * @param[in] score 点数
         * @param[in] blocks 面子構成
         * @param[in] wait_type 待ちの種類
         */
        public Result(in Hand hand, int win_tile, int flag, in List<Tuple<YakuList, int>> yaku_list, int han, int hu, int score_title, in List<int> score, in List<Block> blocks, int wait_type)
        {
            this.success = true;
            this.hand = new mahjong.Hand(hand);
            this.win_tile = win_tile;
            this.flag = flag;
            this.yaku_list = new List<Tuple<YakuList, int>>(yaku_list);
            this.han = han;
            this.fu = mahjong.Hu.Globals.Values[hu];
            this.score_title = score_title;
            this.score = new List<int>(score);
            this.blocks = new List<Block>(blocks);
            this.wait_type = wait_type;
        }

        /**
         * @brief 役満、流し満貫の結果
         *
         * @param[in] hand 手牌
         * @param[in] win_tile 和了牌
         * @param[in] flag フラグ
         * @param[in] yaku_list (成立した役, 飜) の一覧
         * @param[in] score_title 点数のタイトル
         * @param[in] score 点数
         */
        public Result(in Hand hand, int win_tile, int flag, in List<Tuple<YakuList, int>> yaku_list, int score_title, in List<int> score)
        {
            this.success = true;
            this.hand = new mahjong.Hand(hand);
            this.win_tile = win_tile;
            this.flag = flag;
            this.yaku_list = new List<Tuple<YakuList, int>>(yaku_list);
            this.han = 0;
            this.fu = Hu.Null;
            this.score_title = score_title;
            this.score = new List<int>(score);
            this.wait_type = WaitType.Null;
        }

        /**
         * @brief エラーの結果
         *
         * @param[in] hand 手牌
         * @param[in] win_tile 和了牌
         * @param[in] flag フラグ
         * @param[in] err_msg エラーメッセージ
         */
        public Result(in Hand hand, int win_tile, int flag, in string err_msg)
        {
            this.success = false;
            this.err_msg = err_msg;
            this.hand = new mahjong.Hand(hand);
            this.win_tile = win_tile;
            this.flag = flag;
            this.yaku_list = Yaku.Null;
            this.han = 0;
            this.fu = Hu.Null;
            this.score_title = ScoreTitle.Null;
            this.wait_type = WaitType.Null;
        }

        /* 正常終了したかどうか */
        public bool success;

        /* 異常終了した場合のエラーメッセージ */
        public string err_msg = "";

        /**
         * 入力情報
         */

        /* 手牌 */
        public Hand hand = new Hand();

        /* 和了牌 */
        public int win_tile;

        /* フラグ */
        public int flag;

        /**
         * 結果情報
         */

        /* (成立した役, 飜) の一覧 */
        public List<Tuple<YakuList, int>> yaku_list = new List<Tuple<YakuList, int>>();

        /* 飜 */
        public int han;

        /* 符 */
        public int fu;

        /* 点数の種類 */
        public int score_title;

        /* 点数 */
        public List<int> score = new List<int>();

        /* 面子構成 */
        public List<Block> blocks = new List<Block>();

        /* 待ちの種類 */
        public int wait_type;

        public string to_string()
        {
            string s;

            if (!success)
            {
                s += fmt.format("エラー: {}", err_msg);
                return s;
            }

            s += "[結果]\n";
            s += fmt.format("手牌: {}, 和了牌: {}, {}\n", hand.to_string(), Tile.Name.at(win_tile), (flag & HandFlag.Tumo) != 0 ? "自摸" : "ロン");

            if (han > 0)
            {
                if (blocks.Count > 0)
                {
                    s += "面子構成:\n";
                    foreach (var block in blocks)
                    {
                        s += fmt.format("  {}\n", block.to_string());
                    }
                }
                s += fmt.format("待ち: {}\n", WaitType.Name.at(wait_type));

                // 役
                s += "役:\n";
                foreach (auto[yaku, n] in yaku_list)
                {
                    s += fmt.format(" {} {}翻\n", Yaku.Info[yaku].name, n);
                }

                // 飜、符
                s += fmt.format("{}符{}翻{}\n", fu, han, score_title != ScoreTitle.Null ? " " + mahjong.ScoreTitle.Globals.Name[score_title] : "");
            }
            else
            {
                // 流し満貫、役満
                s += "役:\n";
                foreach (auto[yaku, n] in yaku_list)
                {
                    s += fmt.format(" {}\n", Yaku.Info[yaku].name);
                }
                s += mahjong.ScoreTitle.Globals.Name[score_title] + "\n";
            }

            if (score.Count == 3)
            {
                s += fmt.format("和了者の獲得点数: {}点, 親の支払い点数: {}, 子の支払い点数: {}\n", score[0], score[1], score[2]);
            }
            else
            {
                s += fmt.format("和了者の獲得点数: {}点, 放銃者の支払い点数: {}\n", score[0], score[1]);
            }

            return s;
        }
    }

} // namespace mahjong

