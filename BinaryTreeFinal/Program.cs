using System;

namespace BinaryTreeFinal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree<int> TestTree = new BinaryTree<int>(1);
            TestTree.AddItem(2);
            TestTree.AddItem(3);
            
            Console.WriteLine("Hello");
        }
    }
}