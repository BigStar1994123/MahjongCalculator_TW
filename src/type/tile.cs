namespace mahjong
{
    public class Tile
    {
        /**
         * @brief 牌の種類
         */

        public enum Type
        {
            Null = -1,
            Manzu1, //! 一萬
            Manzu2, //! 二萬
            Manzu3, //! 三萬
            Manzu4, //! 四萬
            Manzu5, //! 五萬
            Manzu6, //! 六萬
            Manzu7, //! 七萬
            Manzu8, //! 八萬
            Manzu9, //! 九萬
            Pinzu1, //! 一筒
            Pinzu2, //! 二筒
            Pinzu3, //! 三筒
            Pinzu4, //! 四筒
            Pinzu5, //! 五筒
            Pinzu6, //! 六筒
            Pinzu7, //! 七筒
            Pinzu8, //! 八筒
            Pinzu9, //! 九筒
            Sozu1, //! 一索
            Sozu2, //! 二索
            Sozu3, //! 三索
            Sozu4, //! 四索
            Sozu5, //! 五索
            Sozu6, //! 六索
            Sozu7, //! 七索
            Sozu8, //! 八索
            Sozu9, //! 九索
            Ton, //! 東
            Nan, //! 南
            Sya, //! 西
            Pe, //! 北
            Haku, //! 白
            Hatu, //! 発
            Tyun, //! 中
            AkaManzu5, //! 赤五萬
            AkaPinzu5, //! 赤五筒
            AkaSozu5, //! 赤五索
            Length
        }

        public SortedDictionary<int, string> Name = new SortedDictionary<int, string>()
    {
        {Type.Null, "Null"},
        {Type.Manzu1, "一萬"},
        {Type.Manzu2, "二萬"},
        {Type.Manzu3, "三萬"},
        {Type.Manzu4, "四萬"},
        {Type.Manzu5, "五萬"},
        {Type.Manzu6, "六萬"},
        {Type.Manzu7, "七萬"},
        {Type.Manzu8, "八萬"},
        {Type.Manzu9, "九萬"},
        {Type.Pinzu1, "一筒"},
        {Type.Pinzu2, "二筒"},
        {Type.Pinzu3, "三筒"},
        {Type.Pinzu4, "四筒"},
        {Type.Pinzu5, "五筒"},
        {Type.Pinzu6, "六筒"},
        {Type.Pinzu7, "七筒"},
        {Type.Pinzu8, "八筒"},
        {Type.Pinzu9, "九筒"},
        {Type.Sozu1, "一索"},
        {Type.Sozu2, "二索"},
        {Type.Sozu3, "三索"},
        {Type.Sozu4, "四索"},
        {Type.Sozu5, "五索"},
        {Type.Sozu6, "六索"},
        {Type.Sozu7, "七索"},
        {Type.Sozu8, "八索"},
        {Type.Sozu9, "九索"},
        {Type.Ton, "東"},
        {Type.Nan, u8"南"},
        {Type.Sya, "西"},
        {Type.Pe, u8"北"},
        {Type.Haku, "白"},
        {Type.Hatu, u8"發"},
        {Type.Tyun, "中"},
        {Type.AkaManzu5, u8"赤五萬"},
        {Type.AkaPinzu5, "赤五筒"},
        {Type.AkaSozu5, "赤五索"}
    };
    }
} // namespace mahjong