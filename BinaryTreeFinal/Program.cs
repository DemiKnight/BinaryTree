using System;

namespace BinaryTreeFinal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Node < int > root= new Node<int>(1);
            root.Left = new Node<int>(2);
            root.Right = new Node<int>(3);
            root.Left.Left = new Node<int>(4);
            root.Right.Right = new Node<int>(4);
            BinaryTree<int> test = new BinaryTree<int>( root );

            
               
            Console.WriteLine();
            
            Console.WriteLine("Hello");
        }



    }
}