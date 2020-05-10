using System;

namespace BinaryTreeFinal
{
    public class BinaryTreeAVL<T, X> : BinaryTreeSearch<T, X> where T:IComparable<T> where X:Node<T, X>, new()
    {


        public BinaryTreeAVL(T data) : base(data)
        {
        }

        /**
         * @brief Will rotate the parent and two siblings left, to/and maintain tree balance. 
         */
        private void RotateLeft(ref X tree)
        {
            if (tree.Right?.BalanceFactor > 0)  //double rotate
                RotateRight(ref tree.Right);

            X pivot = tree;

            tree = tree.Right;
            pivot.Right = tree.Left;
            tree.Left = pivot;

        }

        /**
         * @brief Will rotate the parent and two siblings right, to/and maintain tree balance. 
         */
        private void RotateRight(ref X tree)
        {
            if (tree.Left?.BalanceFactor < 0)  //double rotate
                RotateLeft(ref tree.Left);

            X pivot = tree;

            tree = tree.Left;
            pivot.Left = tree.Right;
            tree.Right = pivot;

        }


        protected override ReturnCode _insertItem(T item, ref X tree)
        {
            int leftChange = tree?.Left?.Height() ?? 0;
            int rightChange = tree?.Right?.Height() ?? 0;

            if (tree == null) tree = new X() {Data = item };
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
                RotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                RotateRight(ref tree);

            return ReturnCode.OtherError;
        }

        /**
         * @brief Insert a new unique item into the tree, whilst maintain tree balance and integrity.
         */
        public override ReturnCode InsertItem(T item)
        {
            _insertItem(item, ref root);
            return ReturnCode.Successful;
        }


        //
        // protected override void _copy(ref Node<T> tree, Node<T> tree2)
        // {
        //     base._copy(ref tree, tree2);
        // }
    }
}