namespace DataStructure.Sort;

/// <summary>
/// 选择排序
/// 第一趟从所有的n个记录中选择最小的记录放在第一位，
/// 第二趟从n-1个记录中选择最小的记录放到第二位。以此类推，经过n-1趟排序之后，整个待排序序列就成为有序序列了。
/// </summary>
public class SelectSort
{
    //两个指针一个0一个1开始
    //比较两个索引下元素大小，然后交换位置
    //每次选择最小或者最大的放在已经排序集合的后面
    public static void Sort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;

        for (int i = 0; i < data.Length; i++)
        {
            
            int minIndex = i;
            //将i之后的值与对比
            for (int j = i + 1; j < data.Length; j++)
            {
                //存储j的索引
                minIndex = data[j] < data[minIndex] ? j : minIndex;
            }
            //将找到的小于i的值进行交换
            (data[i], data[minIndex]) = (data[minIndex], data[i]);
        }
    }
}