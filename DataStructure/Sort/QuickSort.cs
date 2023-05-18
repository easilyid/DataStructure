namespace DataStructure.Sort;

public class QuickSort
{
    public static void quickSort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;

        Sort(data, 0, data.Length - 1);
    }

    private static void Sort(int[] data, int left, int right)
    {
        int l = left, r = right;
        if (l >= r) return;

        //分区
        int k = Parttion(data, l, r);
        Sort(data, l, k - 1);
        Sort(data, k, r);
    }

    private static int Parttion(int[] data, int low, int hight)
    {
        //使用最右边的作为基点
        int pivot = data[hight];
        int less = low,
            great = low;

        for (; great <= hight - 1; great++)
        {
            if (data[great] < pivot)
            {
                (data[less], data[great]) = (data[great], data[less]);
                less++;
            }
        }

        (data[less], data[hight]) = (data[hight], data[less]);
        return less;
    }
}