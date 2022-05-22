using MahjongCalculator_TW.src.Models;
using System.Linq;

namespace MahjongCalculator_TW;

/// <summary>
/// 進聽數計算
/// </summary>
public class RequiredTileCountCalculator
{
    public static int Calculate(Hand hand)
    {
        //var n_nelds = hand.Melds.Count();

        // TODO: Get memory cache data from some tables

        return 1;

        //// 制約条件「面子 + 候補 <= 4」で「面子数 * 2 + 候補」の最大値を計算する。
        //int n_melds = int(hand.melds.size());
        //int n_mentu_base = n_melds + s_tbl_[hand.manzu].n_mentu +
        //                   s_tbl_[hand.pinzu].n_mentu + s_tbl_[hand.sozu].n_mentu +
        //                   z_tbl_[hand.zihai].n_mentu;
        //int n_kouho_base = s_tbl_[hand.manzu].n_kouho + s_tbl_[hand.pinzu].n_kouho +
        //                   s_tbl_[hand.sozu].n_kouho + z_tbl_[hand.zihai].n_kouho;

        //// 雀頭なし
        //int max = n_mentu_base * 2 + std::min(4 - n_mentu_base, n_kouho_base);

        //if (s_tbl_[hand.manzu].head)
        //{
        //    // 萬子の雀頭有り
        //    int n_mentu = n_mentu_base + s_tbl_[hand.manzu].n_mentu_diff;
        //    int n_kouho = n_kouho_base + s_tbl_[hand.manzu].n_kouho_diff;
        //    max = std::max(max, n_mentu * 2 + std::min(4 - n_mentu, n_kouho) + 1);
        //}

        //if (s_tbl_[hand.pinzu].head)
        //{
        //    // 筒子の雀頭有り
        //    int n_mentu = n_mentu_base + s_tbl_[hand.pinzu].n_mentu_diff;
        //    int n_kouho = n_kouho_base + s_tbl_[hand.pinzu].n_kouho_diff;
        //    max = std::max(max, n_mentu * 2 + std::min(4 - n_mentu, n_kouho) + 1);
        //}

        //if (s_tbl_[hand.sozu].head)
        //{
        //    // 索子の雀頭有り
        //    int n_mentu = n_mentu_base + s_tbl_[hand.sozu].n_mentu_diff;
        //    int n_kouho = n_kouho_base + s_tbl_[hand.sozu].n_kouho_diff;
        //    max = std::max(max, n_mentu * 2 + std::min(4 - n_mentu, n_kouho) + 1);
        //}

        //if (z_tbl_[hand.zihai].head)
        //{
        //    // 字牌の雀頭有り
        //    int n_mentu = n_mentu_base + z_tbl_[hand.zihai].n_mentu_diff;
        //    int n_kouho = n_kouho_base + z_tbl_[hand.zihai].n_kouho_diff;
        //    max = std::max(max, n_mentu * 2 + std::min(4 - n_mentu, n_kouho) + 1);
        //}

        //return 8 - max;
    }

    /**
 * @brief テーブルの情報
 */

    private struct Pattern
    {
        /*! 面子の数 */
        private sbyte n_mentu;
        /*! 面子候補の数 */
        private sbyte n_kouho;
        /*! 頭あり */
        private sbyte head;
        /*! 頭ありの場合の面子の数の変化数 */
        private sbyte n_mentu_diff;
        /*! 頭ありの場合の面子候補の数の変化数 */
        private sbyte n_kouho_diff;
        /*! 1枚以上の数 */
        private sbyte n_ge1;
        /*! 2枚以上の数 */
        private sbyte n_ge2;
        /*! 3枚以上の数 */
        private sbyte n_ge3;
        /*! 4枚以上の数 */
        private sbyte n_ge4;
        /*! 合計数 */
        private sbyte n;
    };
}