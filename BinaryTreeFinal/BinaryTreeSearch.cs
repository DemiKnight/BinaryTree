using System;

namespace BinaryTreeFinal
{
    public class BinaryTreeSearch <T> : BinaryTree<T> where T:IComparable<T>, IComparable
    {
        public BinaryTreeSearch(Node<T> root) : base(root)
        {
            
        }

        public BinaryTreeSearch(T data) : base(data)
        {
        }    
    }
}