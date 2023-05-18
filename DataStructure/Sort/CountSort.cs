namespace DataStructure.Sort;

/// <summary>
/// 计数排序
/// 适合计数范围比较小的数列
/// </summary>
public class CountSort
{
    public static void Sort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;


        //1.通过最大值减去最小值，确定data的取值范围
        int max = GetMax(data);

        //使用下标来保存，元素出现的次数
        //2.计数数组
        int[] count = new int[max + 1];
        for (int i = 0; i < data.Length; i++)
        {
            count[data[i]]++;
        }

        //计算前缀和 元素+下标为下一个下标的元素值
        //通过前缀和来确定每个元素在排序数组中的最终位置
        //3.累计数组

        for (int i = 1; i < count.Length; i++)
        {
            //从1开始
            count[i] = count[i] + count[i - 1];
        }

        //排序过程
        //4.结果数组
        int[] output = new int[data.Length];
        for (int i = data.Length - 1; i >= 0; i--)
        {//因为数组下标是从0开始的，所以当我们要把一个元素放到排序后的数组中时，
         //需要将其下标减1，才能得到正确的位置
            output[count[data[i]] - 1] = data[i];
            count[data[i]]--;
        }

        //复制数组回原数组

        for (int i = 0; i < data.Length; i++)
        {
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