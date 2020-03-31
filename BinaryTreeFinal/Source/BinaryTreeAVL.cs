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


            Node<T> newRoot = tree;
            // ref Node<T> oldRoot = ref tree; 
            // ref Node<T> newRightForOld = ref newRoot.Left;


            tree = tree.Right;
            newRoot.Right = tree.Left;

            tree.Left = newRoot;

            // tree = newRoot;
            // tree.Right = oldRoot;
            // oldRoot.Right = newRightForOld;
            

            // tree.Right = newRoot.Left;




        }

        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left?.BalanceFactor < 0)  //double rotate
                rotateLeft(ref tree.Left);


            // (tree.Left, tree, tree.Right) = (tree.Left.Right,tree, tree.Right);

            /*
            Node<T> oldRoot = tree;
            Node<T> newRoot = tree.Left;*/
            Node<T> pivot = tree;

            // ref Node<T> oldRoot = ref tree;
            // ref Node<T> newRoot = ref tree.Left;
            // ref Node<T> newRightForOld = ref newRoot.Right;
            //
            //

            // tree.Right = 
            tree = tree.Left;

            pivot.Left = tree.Right;
            tree.Right = pivot;


            //
            // tree.Right = oldRoot;
            // tree.Left= newRightForOld;
        }

        public override ReturnCode RemoveItem(T item)
        {
            throw new NotImplementedException();
            base.RemoveItem(item);
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
            throw new NotImplementedException();
            base._copy(ref tree, tree2);
        }
    }
}