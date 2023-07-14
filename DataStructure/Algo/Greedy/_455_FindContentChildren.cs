namespace DataStructure.Algo.Greedy;

public class _455_FindContentChildren
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);
        int i = 0, j = 0; //两个指针分别指向 g s

        while (i < g.Length && j < s.Length)
        {
            //如果满足胃口就移动
            if (s[j] >= g[i]) i++;
            
            j++;// 不管如何这个指针都是要移动的
        }
        return i;
    }
}