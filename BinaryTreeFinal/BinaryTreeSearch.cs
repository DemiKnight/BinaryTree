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

        public override void InsertItem(T item)
        {
            base.InsertItem(item);
        }

        protected override void _insertItem(T item, ref Node<T> tree)
        {
            base._insertItem(item, ref tree);
        }
        
        
        
        
    }
}