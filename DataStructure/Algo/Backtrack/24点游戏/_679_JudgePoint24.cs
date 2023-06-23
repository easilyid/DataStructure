namespace DataStructure.Algo.Backtrack._24点游戏;

public class _679_JudgePoint24
{
    public bool JudgePoint24(int[] cards)
    {
        var list = new List<double>();

        //将数组装载进list
        foreach (var num in cards)
        {
            list.Add(num);
        }

        return backtrack(list);
    }

    private bool backtrack(List<double> list)
    {
        if (list.Count == 1) return Math.Abs(list[0] - 24) < 1e-6;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (i == j) continue; //剪枝

                var next = new List<double>();
                for (int k = 0; k < list.Count; k++)
                {
                    if (k != i && k != j)
                    {
                        next.Add(list[k]);
                    }
                }

                for (int k = 0; k < 4; k++)
                {
                    if (k < 2 && j > i) continue; //第三位数,第二位如果第一位大的话，无法减
                    double res = 0; //结果
                    if (k == 0)
                    {
                        res = list[i] + list[j];
                    }
                    else if (k == 1)
                    {
                        res = list[i] * list[j];
                    }
                    else if (k == 2)
                    {
                        res = list[i] - list[j];
                    }
                    else if (k == 3)
                    {
                        if (list[j] != 0)
                        {
                            res = list[i] / list[j];
                        }
                        else
                            continue;
                    }

                    next.Add(res);
                    if (backtrack(next))
                    {
                        return true;
                    }

                    next.RemoveAt(next.Count - 1);
                }
            }
        }

        return false;
    }


    public static void Test()
    {
        int[] cards = { 4, 1, 8, 7 };
        var judgePoint24 = new _679_JudgePoint24().JudgePoint24(cards);
        Console.WriteLine(judgePoint24);
    }
}