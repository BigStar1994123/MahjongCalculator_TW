//====================================================================================================
//The Free Edition of C++ to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-cplus-to-csharp.html
//====================================================================================================

namespace mahjong
{


    /**
     * @brief 役
     */
    public class Yaku
    {
        /**
         * @brief 役の種類
         */
        public enum Type : YakuList
        {
            Null = 0Ul,
            Tumo = 1Ul, // 門前清自摸和
            Reach = 1Ul << 1, // 立直
            Ippatu = 1Ul << 2, // 一発
            Tanyao = 1Ul << 3, // 断幺九
            Pinhu = 1Ul << 4, // 平和
            Ipeko = 1Ul << 5, // 一盃口
            Tyankan = 1Ul << 6, // 槍槓
            Rinsyankaiho = 1Ul << 7, // 嶺上開花
            Haiteitumo = 1Ul << 8, // 海底摸月
            Hoteiron = 1Ul << 9, // 河底撈魚
            Dora = 1Ul << 10, // ドラ
            UraDora = 1Ul << 11, // 裏ドラ
            AkaDora = 1Ul << 12, // 赤ドラ
            SangenhaiHaku = 1Ul << 13, // 三元牌 (白)
            SangenhaiHatu = 1Ul << 14, // 三元牌 (發)
            SangenhaiTyun = 1Ul << 15, // 三元牌 (中)
            ZikazeTon = 1Ul << 16, // 自風 (東)
            ZikazeNan = 1Ul << 17, // 自風 (南)
            ZikazeSya = 1Ul << 18, // 自風 (西)
            ZikazePe = 1Ul << 19, // 自風 (北)
            BakazeTon = 1Ul << 20, // 場風 (東)
            BakazeNan = 1Ul << 21, // 場風 (南)
            BakazeSya = 1Ul << 22, // 場風 (西)
            BakazePe = 1Ul << 23, // 場風 (北)
            DoubleReach = 1Ul << 24, // ダブル立直
            Tiitoitu = 1Ul << 25, // 七対子
            Toitoiho = 1Ul << 26, // 対々和
            Sananko = 1Ul << 27, // 三暗刻
            SansyokuDoko = 1Ul << 28, // 三色同刻
            SansyokuDozyun = 1Ul << 29, // 三色同順
            Honroto = 1Ul << 30, // 混老頭
            IkkiTukan = 1Ul << 31, // 一気通貫
            Tyanta = 1Ul << 32, // 混全帯幺九
            Syosangen = 1Ul << 33, // 小三元
            Sankantu = 1Ul << 34, // 三槓子
            Honiso = 1Ul << 35, // 混一色
            Zyuntyanta = 1Ul << 36, // 純全帯幺九
            Ryanpeko = 1Ul << 37, // 二盃口
            NagasiMangan = 1Ul << 38, // 流し満貫
            Tiniso = 1Ul << 39, // 清一色
            Tenho = 1Ul << 40, // 天和
            Tiho = 1Ul << 41, // 地和
            Renho = 1Ul << 42, // 人和
            Ryuiso = 1Ul << 43, // 緑一色
            Daisangen = 1Ul << 44, // 大三元
            Syosusi = 1Ul << 45, // 小四喜
            Tuiso = 1Ul << 46, // 字一色
            Kokusimuso = 1Ul << 47, // 国士無双
            Tyurenpoto = 1Ul << 48, // 九連宝燈
            Suanko = 1Ul << 49, // 四暗刻
            Tinroto = 1Ul << 50, // 清老頭
            Sukantu = 1Ul << 51, // 四槓子
            SuankoTanki = 1Ul << 52, // 四暗刻単騎
            Daisusi = 1Ul << 53, // 大四喜
            Tyurenpoto9 = 1Ul << 54, // 純正九連宝燈
            Kokusimuso13 = 1Ul << 55, // 国士無双13面待ち
            Length = 56Ul
        }

        public class YakuInfo
        {
            /* 名前 */
            public string name = "";
            /* 通常役: (門前の飜数, 非門前の飜数)、役満: (何倍役満か, 未使用) */
            public List<int> han = new List<int>(2);
        }

        public static List<YakuList> NormalYaku = new List<YakuList>() { Type.Tumo, Type.Reach, Type.Ippatu, Type.Tanyao, Type.Pinhu, Type.Ipeko, Type.Tyankan, Type.Rinsyankaiho, Type.Haiteitumo, Type.Hoteiron, Type.SangenhaiHaku, Type.SangenhaiHatu, Type.SangenhaiTyun, Type.ZikazeTon, Type.ZikazeNan, Type.ZikazeSya, Type.ZikazePe, Type.BakazeTon, Type.BakazeNan, Type.BakazeSya, Type.BakazePe, Type.DoubleReach, Type.Tiitoitu, Type.Toitoiho, Type.Sananko, Type.SansyokuDoko, Type.SansyokuDozyun, Type.Honroto, Type.IkkiTukan, Type.Tyanta, Type.Syosangen, Type.Sankantu, Type.Honiso, Type.Zyuntyanta, Type.Ryanpeko, Type.Tiniso };

        public static List<YakuList> Yakuman = new List<YakuList>() { Type.Tenho, Type.Tiho, Type.Renho, Type.Ryuiso, Type.Daisangen, Type.Syosusi, Type.Tuiso, Type.Kokusimuso, Type.Tyurenpoto, Type.Suanko, Type.Tinroto, Type.Sukantu, Type.SuankoTanki, Type.Daisusi, Type.Tyurenpoto9, Type.Kokusimuso13 };

        /**
         * @brief 役の情報
         */
        // clang-format off
        public static SortedDictionary<YakuList, YakuInfo> Info = new SortedDictionary<YakuList, YakuInfo>()
    {
        {
            Type.Null,
			{

                "役なし", {0, 0}
            }

        },
		{
			Type.Tumo,
			{
				"門前清自摸和", {1, 0}
			}
		},
		{
    Type.Reach,
			{
        "立直", { 1, 0}
    }
},
		{
    Type.Ippatu,
			{
        "一発", { 1, 0}
    }
},
		{
    Type.Tanyao,
			{
        "断幺九", { 1, 1}
    }
},
		{
    Type.Pinhu,
			{
        "平和", { 1, 0}
    }
},
		{
    Type.Ipeko,
			{
        "一盃口", { 1, 0}
    }
},
		{
    Type.Tyankan,
			{
        "槍槓", { 1, 1}
    }
},
		{
    Type.Rinsyankaiho,
			{
        "嶺上開花", { 1, 1}
    }
},
		{
    Type.Haiteitumo,
			{
        "海底摸月", { 1, 1}
    }
},
		{
    Type.Hoteiron,
			{

//====================================================================================================
//End of the allowed output for the Free Edition of C++ to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-cplus-to-csharp.html
//====================================================================================================
