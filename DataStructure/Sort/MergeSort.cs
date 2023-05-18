namespace DataStructure.Sort;

/// <summary>
/// 归并排序
/// </summary>
public class MergeSort
{
    public static void Sort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;

        //1.拆分为左右两部
        Splitprocess(data, 0, data.Length - 1);
    }

    /// <summary>
    /// 拆分过程
    /// 分为左右两部分，然后对他进行排序
    /// </summary>
    private static void Splitprocess(int[] data, int left, int right)
    {//一直拆，拆到两个的元素就进行merge
        if (left == right) return;

        int mid = left + ((right - left) >> 1); //计算得到中间的位置
        Splitprocess(data, left, mid); //归并左边的
        Splitprocess(data, mid + 1, right); //归并右边的
        merge(data, left, mid, right); //将所有序列的归并
    }

    private static void merge(int[] data, int left, int mid, int right)
    {
        //临时空间，比原来数组大1，用来存储合并后的序列
        int[] result = new int[right - left + 1];
        int i = 0,
            L = left,
            M = mid + 1;//这个其实就是right
        while (L <= mid && M <= right)
        {//将data后一个位置排序到result上，使其有序 然后++ 改变值
            //如果L上的数小于M上的数
            //拷贝到i上 然后++ 下移开始下一个数的比较
            result[i++] = data[L] <= data[M] ? data[L++] : data[M++];
        }

        //越界情况 一般两个中一个
        while (L <= mid)
        {
            result[i++] = data[L++];
        }

        while (M <= right)
        {
            result[i++] = data[M++];
        }

        for (int t = 0; t < result.Length; t++)
        {
            data[left + t] = result[t];
        }
    }
}