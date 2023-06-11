namespace DataStructure.DataStructure.Tree;

public class TreeTest
{
    /// <summary>
    /// 二叉树
    /// </summary>
    public static void BinaryTreeTest()
    {
        var tree = new BinaryTree<int>();
        var traversal = new Traversal<int>();
        tree.InSert(8);
        tree.InSert(3);
        tree.InSert(10);
        tree.InSert(1);
        tree.InSert(6);
        tree.InSert(14);
        tree.InSert(4);
        tree.InSert(7);
        tree.InSert(13);
       
        Console.WriteLine("Print tree:");
        tree.Print();
        
        tree.Delete(7);
        tree.Delete(14); 
        
        Console.WriteLine("Print Delete tree:");
        tree.Print();
        Console.WriteLine("123");

        var res = tree.LevelOrder();
        // tree.InOrder();
        // tree.PostOrder();
        // tree.LevelOrder();

        foreach (var i in res)
        {
            Console.Write(i+" ");
        }

        Console.WriteLine();

        //     8
        //    / \
        //   3   10
        //  / \    \
        // 1   6    14
        // / \     /
        // 4   7  13
    }


    public static void BinarySearchTreeTest()
    {
        var Bst = new BinarySearchTree<int>();
        Bst.InSert(5);
        Bst.InSert(3);
        Bst.InSert(7);
        Bst.InSert(1);
        Bst.InSert(9);
        Bst.InSert(4);
        Bst.InSert(6);

        Bst.Delete(7);
        
    }
    
    public static void AVLTest()
    {
        var avlTree = new AVLTree<int>();
        avlTree.InSert(10);
        avlTree.InSert(20);
        avlTree.InSert(30);
        avlTree.InSert(40);
        avlTree.InSert(50);
        avlTree.InSert(25);
    }

    public static void RBTreeTest()
    {
        var rbTree = new RBTree<int>(); 
        rbTree.InSert(5);
        rbTree.InSert(3);
        rbTree.InSert(7);
        rbTree.InSert(1);
        rbTree.InSert(9);
        rbTree.InSert(4);
        rbTree.InSert(8);
        rbTree.InSert(6);
        rbTree.Print();
        
        Console.WriteLine("删除值后的:");
        rbTree.Delete(4);
        rbTree.Print();
        
        //      5B
        //     /   \
        //    3B     7B
        //   / \      \
        // 1B   4R    9R
        //       \     
        //       6R   
        //      / \
        //    8B   NIL

    }
   

}