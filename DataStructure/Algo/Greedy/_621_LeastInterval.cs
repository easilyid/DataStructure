namespace DataStructure.Algo.Greedy;

public class _621_LeastInterval
{
    public int LeastInterval(char[] tasks, int n)
    {
        var couter = new int[26];
        int countMaxTask = 0, MaxCountTask = 0; // 出现次数最多的任务,出现次数最多的任务出现的次数
        foreach (var task in tasks)
        {
            int index = task - 'A';
            couter[index]++; //记录次数
            if (couter[index] == MaxCountTask)
            {
                countMaxTask++;
            }
            else if (couter[index] > MaxCountTask)
            {
                MaxCountTask = couter[index];
                countMaxTask = 1;
            }
        }

        int partCount = MaxCountTask - 1; //（冷却时间）最大次数任务之间的间隔
        int partLength = n - (countMaxTask - 1); //每个间隔之间的长度
        int emptySlots = partCount * partLength; //空闲的间隔位
        int availableTasks = tasks.Length - MaxCountTask * countMaxTask; //剩下的任务数
        int idle = Math.Max(0, emptySlots - availableTasks); //需要插入的空闲时间
        return tasks.Length + idle; //总任务=总时间 = 任务数 + 空闲时间
    }

    public int LeastInterval1(char[] tasks, int n)
    {
        int[] counter = new int[26];
        int len = tasks.Length;
        int maxtask = 0, countMax = 0;//最多次数的任务，次数最多的任务的次数
        foreach (var t in tasks)
        {
            int index = t - 'A';
            counter[index]++;
            if (counter[index]==maxtask)
            {
                countMax++;
            }else if (counter[index] > maxtask)
            {
                maxtask = counter[index];
                countMax = 1;
            }
        }

        int partCount = maxtask - 1;//间隔 AAA 就有两个间隔
        int partLength = n - (countMax - 1);
        int emptyslots = partCount * partLength;
        int availableTask = tasks.Length - maxtask * countMax;//
        int idle = Math.Max(0, emptyslots - availableTask);
        return tasks.Length + idle;
    }

    public static void Test()
    {
        char[] tasks = new[] { 'A', 'A', 'A', 'B', 'B', 'B' };
        int n = 0;
        var leastInterval = new _621_LeastInterval().LeastInterval(tasks,n);
        Console.WriteLine(leastInterval);
    }
}