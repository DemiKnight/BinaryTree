using System;

namespace BinaryTreeFinal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTreeSearch<int> testBS = new BinaryTreeSearch<int>(43);
            
            testBS.InsertItem(14);
            testBS.InsertItem(50);
            testBS.InsertItem(34);
            testBS.InsertItem(7);
            testBS.InsertItem(4);
            
            Console.WriteLine("Before" + testBS.ToString());
            testBS.RemoveItem(14);
            Console.WriteLine("After" + testBS.ToString());

            BinaryTreeAVL<int> testTree2 = new BinaryTreeAVL<int>(15);
            BinaryTreeSearch<int> avlControlGroup = new BinaryTreeSearch<int>(15);

            testTree2.InsertItem(25);
            testTree2.InsertItem(10);
            testTree2.InsertItem(23);
            testTree2.InsertItem(20);
            testTree2.InsertItem(17);

            avlControlGroup.InsertItem(25);
            avlControlGroup.InsertItem(10);
            avlControlGroup.InsertItem(23);
            avlControlGroup.InsertItem(20);
            avlControlGroup.InsertItem(17);

            Console.WriteLine("Control " + avlControlGroup.ToString());
            Console.WriteLine("avl " + testTree2.ToString());

        }



    }
}