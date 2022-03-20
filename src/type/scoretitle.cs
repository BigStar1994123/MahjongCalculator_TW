namespace mahjong
{

    /**
     * @brief 符の種類
     */
    namespace Hu
    {

        public enum Type
        {
            Null = -1,
            Hu20, // 20符
            Hu25, // 25符
            Hu30, // 30符
            Hu40, // 40符
            Hu50, // 50符
            Hu60, // 60符
            Hu70, // 70符
            Hu80, // 80符
            Hu90, // 90符
            Hu100, // 100符
            Hu110 // 110符
        }

    } // namespace Hu

    namespace ScoreTitle
    {

        public enum Type
        {
            Null = -1,
            Mangan, // 満貫
            Haneman, // 跳満
            Baiman, // 倍満
            Sanbaiman, // 三倍満
            KazoeYakuman, // 数え役満
            Yakuman, // 役満
            TwoYakuman, // ダブル役満
            ThreeYakuman, // トリプル役満
            FourYakuman, // 四倍役満
            FiveYakuman, // 五倍役満
            SixYakuman, // 六倍役満
            Length
        }

    } // namespace ScoreTitle

} // namespace mahjong

