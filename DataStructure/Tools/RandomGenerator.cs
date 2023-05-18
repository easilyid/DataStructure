namespace DataStructure.Tools;

public class RandomGenerator
{
    public  int RandomNum(int min,int max)
    {
        Random r = new Random();
        return r.Next(min, max);
    }

    public int[] RandomNum(int n,int min, int max)
    {
        Random random = new Random();

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = random.Next(min, max);
        }

        return arr;
    }       
}