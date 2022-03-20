namespace mahjong
{

    public class ScoringTable
    {
        // 満貫かどうかを判定するテーブル
        // clang-format off
        public List<List<int>> IsMangan = new List<List<int>>()
    {
        new List<int> {false, false, false, false},
        new List<int> {false, false, false, false},
        new List<int> {false, false, false, false},
        new List<int> {false, false, false, true},
        new List<int> {false, false, false, true},
        new List<int> {false, false, false, true},
        new List<int> {false, false, true, true},
        new List<int> {false, false, true, true},
        new List<int> {false, false, true, true},
        new List<int> {false, false, true, true},
        new List<int> {false, false, true, true}
    };
        // clang-format on

        /**
         * @brief 親がロンした場合に放銃者が支払う点数
         */
        // clang-format off
        public List<List<int>> ParentRon = new List<List<int>>()
    {
        new List<int> {0, 0, 0, 0},
        new List<int> {0, 2400, 4800, 9600},
        new List<int> {1500, 2900, 5800, 11600},
        new List<int> {2000, 3900, 7700, 0},
        new List<int> {2400, 4800, 9600, 0},
        new List<int> {2900, 5800, 11600, 0},
        new List<int> {3400, 6800, 0, 0},
        new List<int> {3900, 7700, 0, 0},
        new List<int> {4400, 8700, 0, 0},
        new List<int> {4800, 9600, 0, 0},
        new List<int> {5300, 10600, 0, 0}
    };
        // clang-format on

        /**
         * @brief 子がロンした場合に放銃者が支払う点数
         */
        // clang-format off
        public List<List<int>> ChildRon = new List<List<int>>()
    {
        new List<int> {0, 0, 0, 0},
        new List<int> {0, 1600, 3200, 6400},
        new List<int> {1000, 2000, 3900, 7700},
        new List<int> {1300, 2600, 5200, 0},
        new List<int> {1600, 3200, 6400, 0},
        new List<int> {2000, 3900, 7700, 0},
        new List<int> {2300, 4500, 0, 0},
        new List<int> {2600, 5200, 0, 0},
        new List<int> {2900, 5800, 0, 0},
        new List<int> {3200, 6400, 0, 0},
        new List<int> {3600, 7100, 0, 0}
    };
        // clang-format on

        /**
         * @brief 親が自摸した場合に子が支払う点数
         */
        // clang-format off
        public List<List<int>> ParentTumoChild = new List<List<int>>()
    {
        new List<int> {0, 700, 1300, 2600},
        new List<int> {0, 0, 1600, 3200},
        new List<int> {500, 1000, 2000, 3900},
        new List<int> {700, 1300, 2600, 0},
        new List<int> {800, 1600, 3200, 0},
        new List<int> {1000, 2000, 3900, 0},
        new List<int> {1200, 2300, 0, 0},
        new List<int> {1300, 2600, 0, 0},
        new List<int> {1500, 2900, 0, 0},
        new List<int> {1600, 3200, 0, 0},
        new List<int> {1800, 3600, 0, 0}
    };
        // clang-format on

        /**
         * @brief 子が自摸した場合に親が支払う点数
         */
        // clang-format off
        public List<List<int>> ChildTumoParent = new List<List<int>>()
    {
        new List<int> {0, 700, 1300, 2600},
        new List<int> {0, 0, 1600, 3200},
        new List<int> {500, 1000, 2000, 3900},
        new List<int> {700, 1300, 2600, 0},
        new List<int> {800, 1600, 3200, 0},
        new List<int> {1000, 2000, 3900, 0},
        new List<int> {1200, 2300, 0, 0},
        new List<int> {1300, 2600, 0, 0},
        new List<int> {1500, 2900, 0, 0},
        new List<int> {1600, 3200, 0, 0},
        new List<int> {1800, 3600, 0, 0}
    };
        // clang-format on

        /**
         * @brief 子が自摸した場合に子が支払う点数
         */
        // clang-format off
        public List<List<int>> ChildTumoChild = new List<List<int>>()
    {
        new List<int> {0, 400, 700, 1300},
        new List<int> {0, 0, 800, 1600},
        new List<int> {300, 500, 1000, 2000},
        new List<int> {400, 700, 1300, 0},
        new List<int> {400, 800, 1600, 0},
        new List<int> {500, 1000, 2000, 0},
        new List<int> {600, 1200, 0, 0},
        new List<int> {700, 1300, 0, 0},
        new List<int> {800, 1500, 0, 0},
        new List<int> {800, 1600, 0, 0},
        new List<int> {900, 1800, 0, 0}
    };
        // clang-format on

        /**
         * @brief 親がロンした場合に放銃者が支払う点数 (満貫以上)
         */
        public List<int> ParentRonOverMangan = new List<int>() { 12000, 18000, 24000, 36000, 48000, 48000, 96000, 144000, 192000, 240000, 288000 };

        /**
         * @brief 子がロンした場合に放銃者が支払う点数 (満貫以上)
         */
        public List<int> ChildRonOverMangan = new List<int>() { 8000, 12000, 16000, 24000, 32000, 32000, 64000, 96000, 128000, 160000, 192000 };

        /**
         * @brief 親が自摸した場合に子が支払う点数 (満貫以上)
         */
        public List<int> ParentTumoChildOverMangan = new List<int>() { 4000, 6000, 8000, 12000, 16000, 16000, 32000, 48000, 64000, 80000, 96000 };

        /**
         * @brief 子が自摸した場合に親が支払う点数 (満貫以上)
         */
        public List<int> ChildTumoParentOverMangan = new List<int>() { 4000, 6000, 8000, 12000, 16000, 16000, 32000, 48000, 64000, 80000, 96000 };

        /**
         * @brief 子が自摸した場合に子が支払う点数
         */
        public List<int> ChildTumoChildOverMangan = new List<int>() { 2000, 3000, 4000, 6000, 8000, 8000, 16000, 24000, 32000, 40000, 48000 };
    }
} // namespace mahjong

