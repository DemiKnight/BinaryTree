using System;

namespace BinaryTreeFinal
{
    public class BinaryTreeAVL<T> : BinaryTreeSearch<T> where T:IComparable, IComparable<T>
    {
        public BinaryTreeAVL(Node<T> root) : base(root)
        {
        }

        public BinaryTreeAVL(T data) : base(data)
        {
        }

        public override RETURN_Code RemoveItem(T item)
        {
            throw new NotImplementedException();
            base.RemoveItem(item);
        }

        public override RETURN_Code InsertItem(T item)
        {
            throw new NotImplementedException();
            base.InsertItem(item);
        }

        protected override void _insertItem(T item, ref Node<T> tree)
        {
            throw new NotImplementedException();
            base._insertItem(item, ref tree);
        }

        protected override void _copy(ref Node<T> tree, Node<T> tree2)
        {
            throw new NotImplementedException();
            base._copy(ref tree, tree2);
        }
    }
}