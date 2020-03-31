using System;

namespace BinaryTreeFinal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Node < int > root= new Node<int>(15);
            //
            // root.Left = new Node<int>(12);
            // root.Left.Left = new Node<int>(13);
            //
            // root.Right = new Node<int>(19);
            //
            // root.Right.Left = new Node<int>(16);
            // root.Right.Right = new Node<int>(24);
            //
            // root.Right.Right.Left = new Node<int>(23);
            // root.Right.Right.Right = new Node<int>(100);
            // BinaryTree<int> test = new BinaryTree<int>( root );


            // Console.WriteLine(root.ToString());
            // Console.WriteLine();
            //
            // BinaryTreeSearch<int> testBS = new BinaryTreeSearch<int>(43);
            //
            // testBS.InsertItem(14);
            // testBS.InsertItem(50);
            // testBS.InsertItem(34);
            // testBS.InsertItem(7);
            // testBS.InsertItem(4);
            //
            // testBS.RemoveItem(14);

            // Node<int> testNode = root;
            // Node<int>.GetLowestValue(ref testNode);
            // Console.WriteLine(testNode.ToString());


            BinaryTreeAVL<int> testTree = new BinaryTreeAVL<int>(43);
            testTree.ToString();

            testTree.InsertItem(10);
            testTree.ToString();
            testTree.InsertItem(11);
            testTree.ToString();
            // testTree.InsertItem(12);

            // BinaryTreeAVL<int> testTree2 = new BinaryTreeAVL<int>(15);
            // testTree.InsertItem(25);
            // testTree.InsertItem(10);
            // testTree.InsertItem(23);
            // testTree.InsertItem(20);
            // testTree.InsertItem(17);
        }



    }
}