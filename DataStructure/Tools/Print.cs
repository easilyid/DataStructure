namespace DataStructure.Tools;

public class Prints
{
    public void Print(int[] data)
    {
        if (data.Length != 0)
        {
            string str = "";
            foreach (var i in data)
            {
                str = str + i + ",";
            }

            Console.WriteLine("[" + str.Substring(0, str.Length - 1) + "]");
        }

        if (data.Length==0)
        {
            Console.WriteLine("[]");
        }
    }
}