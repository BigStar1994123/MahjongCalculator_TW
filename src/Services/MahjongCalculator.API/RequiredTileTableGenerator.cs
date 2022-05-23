namespace MahjongCalculator_TW;

public class RequiredTileTableGenerator
{
    public class Product
    {
        private List<List<int>> Keys { get; set; } = new List<List<int>>();
        private int _n_keys;

        public List<List<int>> Generate(int n_keys)
        {
            Keys.Clear();
            _n_keys = n_keys;
            var key = Enumerable.Repeat(0, n_keys).ToList();

            Exec(key);

            return Keys;
        }

        private void Exec(List<int> key, int i = 0, int cnt = 0)
        {
            Console.WriteLine(string.Join(",", key));

            if (i == _n_keys)
            {
                if (cnt <= 14)
                    Keys.Add(key.ToList());
                return;
            }

            for (int n = 0; n < 5; ++n)
            {
                key[i] = n;
                Exec(key, i + 1, cnt + n);
            }
        }
    }

    public class Generator
    {
        private int _maxPair;
        private int _maxMentu;
        private int _maxKouho;

        public List<int> CalcPairWithHead(List<int> _key)
        {
            var key = new List<int>(_key);
            _maxPair = _maxMentu = _maxKouho = 0;
            int head = 0;

            for (var i = 0; i < key.Count; ++i)
            {
                if (key[i] >= 2)
                {
                    key[i] -= 2;
                    cut_mentu(key);
                    key[i] += 2;

                    head = 1;
                }
            }

            return new List<int> { head, _maxMentu, _maxKouho };
        }

        public List<int> CalcPair(List<int> _key)
        {
            System.Diagnostics.Debug.WriteLine("This is start of CalcPair() method.");

            var key = new List<int>(_key);

            _maxPair = _maxMentu = _maxKouho = 0;
            cut_mentu(key);

            System.Diagnostics.Debug.WriteLine($"This is start of CalcPair() method. _maxMentu:{_maxMentu} _maxKouho:{_maxKouho}");

            return new List<int> { _maxMentu, _maxKouho };
        }

        public List<int> Count(List<int> key)
        {
            int n_ge1 = 0;
            int n_ge2 = 0;
            int n_ge3 = 0;
            int n_ge4 = 0;

            foreach (var n in key)
            {
                n_ge1 += n >= 1 ? 1 : 0;
                n_ge2 += n >= 2 ? 1 : 0;
                n_ge3 += n >= 3 ? 1 : 0;
                n_ge4 += n >= 4 ? 1 : 0;
            }

            return new List<int> { n_ge1, n_ge2, n_ge3, n_ge4 };
        }

        private void cut_mentu(List<int> key, int n_mentu = 0, int n_kouho = 0, int i = 0)
        {
            if (i == key.Count)
            {
                cut_kouho(key, n_mentu, n_kouho);
                return;
            }

            if (key[i] >= 3)
            {
                key[i] -= 3;
                cut_mentu(key, n_mentu + 1, n_kouho, i);
                key[i] += 3;
            }

            if (key.Count == 9 && i < key.Count - 2 && key[i] >= 1 && key[i + 1] >= 1 && key[i + 2] >= 1)
            {
                key[i] -= 1;
                key[i + 1] -= 1;
                key[i + 2] -= 1;
                cut_mentu(key, n_mentu + 1, n_kouho, i);
                key[i] += 1;
                key[i + 1] += 1;
                key[i + 2] += 1;
            }

            cut_mentu(key, n_mentu, n_kouho, i + 1);
        }

        private void cut_kouho(List<int> key, int n_mentu, int n_kouho, int i = 0)
        {
            if (i == key.Count)
            {
                aggregate(n_mentu, n_kouho);
                return;
            }

            if (key[i] >= 2)
            {
                key[i] -= 2;
                cut_kouho(key, n_mentu, n_kouho + 1, i);
                key[i] += 2;
            }

            if (key.Count == 9 && i < key.Count - 1 && key[i] >= 1 && key[i + 1] >= 1)
            {
                key[i] -= 1;
                key[i + 1] -= 1;
                cut_kouho(key, n_mentu, n_kouho + 1, i);
                key[i] += 1;
                key[i + 1] += 1;
            }

            if (key.Count == 9 && i < key.Count - 2 && key[i] >= 1 && key[i + 2] >= 1)
            {
                key[i] -= 1;
                key[i + 2] -= 1;
                cut_kouho(key, n_mentu, n_kouho + 1, i);
                key[i] += 1;
                key[i + 2] += 1;
            }

            cut_kouho(key, n_mentu, n_kouho, i + 1);
        }

        private void aggregate(int n_mentu, int n_kouho)
        {
            int pair = n_mentu * 2 + n_kouho;

            if (pair > _maxPair || (pair == _maxPair && n_mentu > _maxMentu))
            {
                _maxPair = pair;
                _maxMentu = n_mentu;
                _maxKouho = n_kouho;
            }
        }
    }

    public void Execute()
    {
        System.Diagnostics.Debug.WriteLine("Test");
        Product product = new Product();
        Generator gen = new Generator();

        {
            // 数牌のテーブルを作成する。
            var keys = product.Generate(9);

            using StreamWriter file = new("csharp_gen9.txt", append: true);

            //foreach (var key in keys)
            //{
            //    foreach (var t in key)
            //    {
            //        file.Write(t);
            //    }
            //    file.WriteLine();
            //}

            foreach (var key in keys)
            {
                var v1 = gen.CalcPair(key);
                var v2 = gen.CalcPairWithHead(key);
                var v3 = gen.Count(key);

                for (var i = 0; i < 9; i++)
                {
                    file.Write(i < key.Count ? key[i] : 0);
                }
                file.Write(" ");

                foreach (var x in v1)
                {
                    file.Write(x);
                }
                foreach (var x in v2)
                {
                    file.Write(x);
                }
                foreach (var x in v3)
                {
                    file.Write(x);
                }
                file.WriteLine();
            }
        }
    }
}