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




        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right?.BalanceFactor > 0)  //double rotate
                rotateRight(ref tree.Right);

            Node<T> pivot = tree;

            tree = tree.Right;
            pivot.Right = tree.Left;
            tree.Left = pivot;

        }

        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left?.BalanceFactor < 0)  //double rotate
                rotateLeft(ref tree.Left);

            Node<T> pivot = tree;

            tree = tree.Left;
            pivot.Left = tree.Right;
            tree.Right = pivot;

        }

        public override ReturnCode RemoveItem(T item)
        {
            base.RemoveItem(item);
            return ReturnCode.Successful;
        }

        public override ReturnCode InsertItem(T item)
        {
            _insertItem(item, ref root);
            return ReturnCode.Successful;
        }

        protected override ReturnCode _insertItem(T item, ref Node<T> tree)
        {
            int leftChange = tree?.Left?.Height() ?? 0;
            int rightChange = tree?.Right?.Height() ?? 0;

            if (tree == null) tree = new Node<T>(item);
            else
            {

                switch (item.CompareTo(tree.Data))
                {
                    case -1:
                        _insertItem(item, ref tree.Left);
                        leftChange++;
                        break;
                    case 1:
                        _insertItem(item, ref tree.Right);
                        rightChange++;
                        break;
                    case 0:
                        return ReturnCode.ValueAlreadyPresent;
                }
            }

            tree.BalanceFactor = leftChange - rightChange;

            switch (tree.BalanceFactor)
            {
                case 0:
                case -1:
                case 1:
                    return ReturnCode.Successful;
            }

            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);

            return ReturnCode.OtherError;
        }

        protected override void _copy(ref Node<T> tree, Node<T> tree2)
        {
            base._copy(ref tree, tree2);
        }
    }
}