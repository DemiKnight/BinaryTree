using System;

namespace BinaryTreeFinal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree<int> TestTree = new BinaryTree<int>(1);
            TestTree.InsertItem(2);
            TestTree.InsertItem(3);
            
            Console.WriteLine("Hello");
        }
    }
}