namespace DataStructure.Sort;

/// <summary>
/// 希尔排序
/// </summary>
public class ShellSort
{
    //1.间隔排序 通常为长度的一半
    //2.组内排序
    //3.重新设置间隔分组,为前一次分组的一半
    //4、插入排序
    public static void Sort(int[] data)
    {
        if (data.Length == null || data.Length < 2) return;

        int n = data.Length;
        int h, j,temp; //h为步长 

        for (h = n / 2; h > 0; h /= 2)
        {//按照增量式子 改变步数h

            //组内排序
            for (int i = h; i < n; i++)
            {
                //临时保存 步长的值
                temp = data[i];

                for (j = i - h; j >= 0 && temp < data[j]; j = j - h)
                {//从0开始到步长 比较步长和开头的值, 通过j=j-h 改变0位置指针j的位置
                    data[j + h] = data[j];
                }
                data[j + h] = temp;
            }
        }

    }
}