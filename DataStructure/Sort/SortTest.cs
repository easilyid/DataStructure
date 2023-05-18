using DataStructure.Tools;

namespace DataStructure.Sort;

public class SortTest
{
    public static void BubbleSortTest()
    {
        var p = new Prints();
        int[] arr = new RandomGenerator().RandomNum(8, 0, 10);
        p.Print(arr);
        BubbleSort.bubbleSort(arr);
        p.Print(arr);
    }

    public static void SelectSortTest()
    {
        var p = new Prints();
        int[] arr = new RandomGenerator().RandomNum(8, 0, 10);
        p.Print(arr);
        SelectSort.Sort(arr);
        p.Print(arr);
    }

    public static void InSertSortTest()
    {
        var p = new Prints();
        int[] arr = new RandomGenerator().RandomNum(8, 0, 10);
        p.Print(arr);
        InSertSort.Sort(arr);
        p.Print(arr);
    }

    public static void ShellSortTest()
    {
        var p = new Prints();
        int[] arr = { 8, 3, 6, 1, 5, 9, 7, 2 };
        p.Print(arr);
        ShellSort.Sort(arr);
        p.Print(arr);
    }

    public static void MergeSortTest()
    {
        var p = new Prints();
        int[] arr = { 8, 3, 6, 1, 5, 9, 7, 2 };
        p.Print(arr);
        MergeSort.Sort(arr);
        p.Print(arr);
    }
    
    public static void QuickSortTest()
    {
        var p = new Prints();
        int[] arr = { 8, 3, 6, 1, 5, 9, 7, 2 };
        p.Print(arr);
        QuickSort.quickSort(arr);
        p.Print(arr);
    }
    
    public static void BucketSortTest()
    {
        var p = new Prints();
        int[] arr =  new RandomGenerator().RandomNum(15, 0,30);
        p.Print(arr);
        BucketSort.Sort(arr);
        p.Print(arr);
    }

    public static void CountSortTest()
    {
        var p = new Prints();
        int[] arr = { 2,11,18,11,15,13,3,3,4,4 };
        p.Print(arr);
        CountSort.Sort(arr);
        p.Print(arr);
    }
    
    public static void RadixSortTest()
    {
        var p = new Prints();
        int[] arr = new RandomGenerator().RandomNum(20, 0, 100);
        p.Print(arr);
        RadixSort.Sort(arr);
        p.Print(arr);
    }
}