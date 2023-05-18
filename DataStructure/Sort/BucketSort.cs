using System.Collections;

namespace DataStructure.Sort;

/// <summary>
/// 桶排序
/// </summary>
public class BucketSort
{
    public static void Sort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;

        //得到最大值 确定桶的个数
        int maxValue = data[0];
        foreach (var i in data)
        {
            maxValue = Math.Max(maxValue, i);
        }

        //这里需要注意的是：bucketNum 的计算是根据场景确定的，不同的场景 bucketNum 的计算方式是不同的
        //所以 bucketNum 的计算之前，需要确定桶排序使用的场景 maxValue / 10 + 1; // 39 / 10 + 1 = 4

        //这里使用动态计算，即数组长度的平方根向下取整
        int bucketNum = (int)Math.Floor(Math.Sqrt(data.Length));
        List<int>[] buckets = new List<int>[bucketNum];

        for (int i = 0; i < bucketNum; i++)
        {
            buckets[i] = new List<int>(); //初始化桶
        }

        for (int i = 0; i < data.Length; i++)
        {
            int bucketIndex = (int)Math.Floor(data[i] * (bucketNum - 1) / (double)maxValue);
            buckets[bucketIndex].Add(data[i]);
        }

        int index = 0;
        for (int i = 0; i < bucketNum; i++)
        {
            //将每过桶里的值转数组，然后插入排序
            int[] temp = buckets[i].ToArray();

            InsertSort(temp);
            for (int j = 0; j < temp.Length; j++)
            {//将排序后的值存会data里
                data[index++] = temp[j];
            }
        }
    }

    private static void InsertSort(int[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            for (int j = i - 1; j >= 0 && data[j + 1] < data[j]; j--)
            {
                (data[j], data[j + 1]) = (data[j + 1], data[j]);
            }
        }
    }
}