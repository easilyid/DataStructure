namespace DataStructure.Sort;

/// <summary>
/// 基数排序
/// </summary>
public class RadixSort
{
    public static void Sort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;
        int max = GetMax(data);

        for (int exp = 1; max / exp > 0; exp *= 10)
        {
            //计算每一位 个位 十位 百位。。。
            countSort(data, exp);
        }
    }

    private static void countSort(int[] data, int exp)
    {
        //一个存储排序结果，一个存储数字出现的次数
        int[] output = new int[data.Length];
        int[] count = new int[10];

        for (int i = 0; i < data.Length; i++)
        {
            //取余计算每一位的数字 存储到次数数组对应的下标上加1
            count[(data[i] / exp) % 10]++;
        }

        for (int i = 1; i < 10; i++)
        {//前缀和算法 注意从1开始
            count[i] = count[i] + count[i - 1];
        }

        for (int i = data.Length - 1; i >= 0; i--)
        {//将数字按照位置存储到输出数组中
            output[count[(data[i] / exp) % 10] - 1] = data[i];
            count[(data[i] / exp) % 10]--;
        }

        for (int i = 0; i < data.Length; i++)
        {//复制回原数组
            data[i] = output[i];
        }
    }

    private static int GetMax(int[] data)
    {
        int max = data[0];
        foreach (var i in data)
        {
            max = Math.Max(max, i);
        }

        return max;
    }
}