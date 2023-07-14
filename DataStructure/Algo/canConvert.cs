namespace DataStructure.Algo;

public class canConvert
{
    public bool CanConvert(int[] needs, int[] targets, int[,] rule)
    {
        var pools = new Dictionary<int,int>();

        for (int i = 0; i < targets.Length; i++)
        {
            pools[i] = targets[i];
        }

        for (int i = 0; i < needs.Length; i++)
        {
            int need = needs[i];
            if (pools[i]>=need)
            {
                pools[i] -= need;
                continue;
            }

            for (int j = 0; j < rule.GetLength(0); j++)
            {
                int formAttribute = rule[j, 0];
                int toAtteibute = rule[j, 1];

                int ConverNum = need - pools[i];

                if (pools[formAttribute] >= ConverNum)
                {
                    pools[formAttribute] -= ConverNum;
                    pools[toAtteibute]+=ConverNum;
                    break;
                }
            }

            if (pools[i] < need)
                return false;
        }

        return true;
    }
    
    public static void Test()
    {
        int[] needs = { 6, 6, 2 };
        int[] targets = { 7, 7, 0 };
        int[,] rules = { { 1, 0 }, { 0, 2 } };
        var convert = new canConvert().CanConvert(needs, targets, rules);
        Console.WriteLine(convert);
        
    }
}