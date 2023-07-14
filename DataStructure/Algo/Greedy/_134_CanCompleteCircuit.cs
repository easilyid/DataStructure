namespace DataStructure.Algo.Greedy;

public class _134_CanCompleteCircuit
{
    public int CanCompleteCircuit1(int[] gas, int[] cost)
    {
        for (int i = 0; i < gas.Length; i++)
        {
            if (gas[i] < cost[i]) continue; // 如果当前加油站的油量小于消耗量，则无法作为起点，继续下一个加油站
            var index = i; // 记录当前加油站的索引
            var needGas = gas[i] - cost[i]; // 计算从当前加油站出发所需的油量
            while (needGas >= 0)
            {
                // 当油量足够时，继续前进
                index = (index + 1) % gas.Length; // 更新索引，循环遍历加油站数组
                if (index == i) return i; // 如果回到起点，则找到了满足条件的起点
                needGas = needGas - cost[index] + gas[index]; // 更新剩余油量
            }
        }

        return -1; // 如果无法找到满足条件的起点，则返回-1
    }

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int len = gas.Length;
        int starindex = 0;//开始时的油箱
        int totalgas = 0;//总油
        int currgas = 0;//当前
        for (int i = 0; i < len; i++)
        {
            totalgas += gas[i] - cost[i];
            currgas += gas[i] - cost[i];
            if (currgas < 0)
            {
                starindex = i + 1;
                currgas = 0;
            }
        }
        return totalgas >= 0 ? starindex : -1;
    }


    public static void Test()
    {
        int[] gas = { 1, 2, 3, 4, 5 };
        int[] cost = { 3, 4, 5, 1, 2 };
        var canCompleteCircuit = new _134_CanCompleteCircuit().CanCompleteCircuit(gas, cost);
        Console.WriteLine(canCompleteCircuit);
    }
}