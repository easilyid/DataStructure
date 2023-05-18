namespace DataStructure.Sort;

/// <summary>
/// 插入排序
/// </summary>
public class InSertSort
{
    //第0个是有序的，依次往后遍历，比较大小然后交换位置
    public static void Sort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;

        //0~1是有序的从1开始
        for (int i = 1; i < data.Length; i++)
        {
            //0~i是想有序的
            // j从i-1开始向前遍历，找到第一个比当前元素大的位置
            // 并且j要大于等于0，避免越界
            // 如果找到了符合条件的位置，就将j+1到i-1的元素向右移动一位
            for (int j = i - 1; j >= 0 && data[j] > data[j + 1]; j--)
            {
                (data[j], data[j+1]) = (data[j+1], data[j]);
            }
        }
    }
}