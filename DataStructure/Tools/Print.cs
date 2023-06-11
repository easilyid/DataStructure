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
    
    
    
    // public void PrintTree()
    // {
    //     if (root==null)
    //     {
    //         Console.WriteLine("该树为空");
    //         return;
    //     }
    //
    //     int height = GetHeight(root);
    //     for (int i = 0; i < height; i++)
    //     {
    //         PrintLevel(root, i, height - i - 1);
    //         Console.WriteLine();
    //     }
    // }
    //
    // private void PrintLevel(TreeNode<T> node, int level, int space)
    // {
    //     
    //     if (node == null)
    //     {
    //         PrintSpace(space);
    //         Console.Write(" ");
    //         return;
    //     }
    //
    //     if (level == 0)
    //     {
    //         PrintSpace(space);
    //         Console.Write(node.Data);
    //         PrintSpace(space);
    //     }
    //     else
    //     {
    //         PrintLevel(node.Left, level - 1, space);
    //         PrintLevel(node.Right, level - 1, space);
    //     }
    // }
    //
    // private void PrintSpace(int count)
    // {
    //     for (int i = 0; i < count; i++)
    //     {
    //         Console.Write(" ");
    //     }
    // }
}