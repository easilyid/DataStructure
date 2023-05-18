namespace DataStructure.Sort;

/// <summary>
/// 冒泡排序
/// 在运行时间方面，待排序的记录越接近有序，
/// 算法的执行效率就越高，反之，执行效率则越低，它的平均时间复杂度为O(n2)。
/// </summary>
public class BubbleSort
{
    public static void bubbleSort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;

        for (int i = data.Length - 1; i >= 0; i--)
        {//从尾部开始往左遍历 轮次
            for (int j = 0; j < i; j++)
            {//每一轮都在对比j和j+1的大小 大于交换位置
                if (data[j] > data[j + 1])
                {
                    (data[j], data[j + 1]) = (data[j + 1], data[j]);
                }
            }
        }
    }
}