namespace MahjongCalculator_TW;

public class ShantenTableGenerator
{
    /// <summary>
    /// 最大組合價值
    /// </summary>
    private int _maxCombinationValue;

    /// <summary>
    /// 最大成搭/面子的數量
    /// </summary>
    private int _maxSetCount;

    /// <summary>
    /// 最大散搭/搭子的數量
    /// </summary>
    private int _maxPartialSetCount;

    /// <summary>
    /// 把眼拿出來後做計算
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<int> CalculateWithHead(List<int> key)
    {
        var keyCopy = new List<int>(key);
        _maxCombinationValue = _maxSetCount = _maxPartialSetCount = 0;
        var pair = 0;

        for (var i = 0; i < keyCopy.Count; ++i)
        {
            if (keyCopy[i] >= 2)
            {
                keyCopy[i] -= 2;
                RemoveSet(keyCopy);
                keyCopy[i] += 2;

                pair = 1;
            }
        }

        return new List<int> { pair, _maxSetCount, _maxPartialSetCount };
    }

    /// <summary>
    /// 一般計算
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<int> Calculate(List<int> key)
    {
        var keyCopy = new List<int>(key);
        _maxCombinationValue = _maxSetCount = _maxPartialSetCount = 0;
        RemoveSet(keyCopy);

        return new List<int> { _maxSetCount, _maxPartialSetCount };
    }

    /// <summary>
    /// 計算手牌的數量，1張牌 - 4張牌
    /// 例如: 5432 表示，有5張牌數量大於等於1，有4張牌數量大於等於2，有3張牌數量大於等於3，有2張牌數量大於等於4
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<int> Count(List<int> key)
    {
        var n_ge1 = 0;
        var n_ge2 = 0;
        var n_ge3 = 0;
        var n_ge4 = 0;

        foreach (var n in key)
        {
            n_ge1 += n >= 1 ? 1 : 0;
            n_ge2 += n >= 2 ? 1 : 0;
            n_ge3 += n >= 3 ? 1 : 0;
            n_ge4 += n >= 4 ? 1 : 0;
        }

        return new List<int> { n_ge1, n_ge2, n_ge3, n_ge4 };
    }

    /// <summary>
    /// 移除成搭/面子，包含刻子和順子
    /// </summary>
    /// <param name="key"></param>
    /// <param name="setCount"></param>
    /// <param name="partialSetCount"></param>
    /// <param name="i"></param>
    private void RemoveSet(List<int> key, int setCount = 0, int partialSetCount = 0, int i = 0)
    {
        if (i == key.Count)
        {
            RemovePartialSet(key, setCount, partialSetCount);
            return;
        }

        if (key[i] >= 3)
        {
            key[i] -= 3;
            RemoveSet(key, setCount + 1, partialSetCount, i);
            key[i] += 3;
        }

        if (key.Count == 9 && i < key.Count - 2 && key[i] >= 1 && key[i + 1] >= 1 && key[i + 2] >= 1)
        {
            key[i] -= 1;
            key[i + 1] -= 1;
            key[i + 2] -= 1;
            RemoveSet(key, setCount + 1, partialSetCount, i);
            key[i] += 1;
            key[i + 1] += 1;
            key[i + 2] += 1;
        }

        RemoveSet(key, setCount, partialSetCount, i + 1);
    }

    /// <summary>
    /// 移除散搭/搭子
    /// </summary>
    /// <param name="key"></param>
    /// <param name="setCount"></param>
    /// <param name="partialSetCount"></param>
    /// <param name="i"></param>
    private void RemovePartialSet(List<int> key, int setCount, int partialSetCount, int i = 0)
    {
        if (i == key.Count)
        {
            Aggregate(setCount, partialSetCount);
            return;
        }

        if (key[i] >= 2)
        {
            key[i] -= 2;
            RemovePartialSet(key, setCount, partialSetCount + 1, i);
            key[i] += 2;
        }

        if (key.Count == 9 && i < key.Count - 1 && key[i] >= 1 && key[i + 1] >= 1)
        {
            key[i] -= 1;
            key[i + 1] -= 1;
            RemovePartialSet(key, setCount, partialSetCount + 1, i);
            key[i] += 1;
            key[i + 1] += 1;
        }

        if (key.Count == 9 && i < key.Count - 2 && key[i] >= 1 && key[i + 2] >= 1)
        {
            key[i] -= 1;
            key[i + 2] -= 1;
            RemovePartialSet(key, setCount, partialSetCount + 1, i);
            key[i] += 1;
            key[i + 2] += 1;
        }

        RemovePartialSet(key, setCount, partialSetCount, i + 1);
    }

    /// <summary>
    /// 整合計算整體組合的價值，若大於最大價值，則取代為max
    /// </summary>
    /// <param name="setCount"></param>
    /// <param name="partialSetCount"></param>
    private void Aggregate(int setCount, int partialSetCount)
    {
        int combinationValue = setCount * 2 + partialSetCount;

        if (combinationValue > _maxCombinationValue || (combinationValue == _maxCombinationValue && setCount > _maxSetCount))
        {
            _maxCombinationValue = combinationValue;
            _maxSetCount = setCount;
            _maxPartialSetCount = partialSetCount;
        }
    }

    public void Execute()
    {
        Product product = new Product();

        // 数牌のテーブルを作成する。
        var nineKeys = product.Generate(9);

        using StreamWriter nineKeysFile = new("csharp_gen9.txt", append: true);

        foreach (var key in nineKeys)
        {
            var v1 = Calculate(key);
            var v2 = CalculateWithHead(key);
            var v3 = Count(key);

            for (var i = 0; i < 9; i++)
                nineKeysFile.Write(i < key.Count ? key[i] : 0);

            nineKeysFile.Write(" ");

            foreach (var x in v1)
                nineKeysFile.Write(x);

            foreach (var x in v2)
                nineKeysFile.Write(x);

            foreach (var x in v3)
                nineKeysFile.Write(x);

            nineKeysFile.WriteLine();
        }

        // 字牌のテーブルを作成する。
        var sevenKeys = product.Generate(7);

        using StreamWriter sevenKeyFile = new("csharp_gen7.txt", append: true);

        foreach (var key in sevenKeys)
        {
            var v1 = Calculate(key);
            var v2 = CalculateWithHead(key);
            var v3 = Count(key);

            for (var i = 0; i < 9; i++)
                sevenKeyFile.Write(i < key.Count ? key[i] : 0);

            sevenKeyFile.Write(" ");

            foreach (var x in v1)
                sevenKeyFile.Write(x);

            foreach (var x in v2)
                sevenKeyFile.Write(x);

            foreach (var x in v3)
                sevenKeyFile.Write(x);

            sevenKeyFile.WriteLine();
        }
    }
}

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
            if (cnt <= 17)
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