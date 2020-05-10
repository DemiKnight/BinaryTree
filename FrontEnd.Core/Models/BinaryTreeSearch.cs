using System;

namespace BinaryTreeFinal
{
    public class BinaryTreeSearch <T, X> : BinaryTree<T, X> where T:IComparable<T> where X:Node<T, X>, new()
    {
        
        
        public BinaryTreeSearch(X root) : base(root) {}

        public BinaryTreeSearch(T data) : base(data) {}
        

        public override ReturnCode InsertItem(T item)
        {
            return _insertItem(item, ref root);
        }

        protected override ReturnCode _insertItem(T item, ref X tree)
        {
            if (tree == null) tree = new X() { Data = item };

            switch (item.CompareTo(tree.Data))
            {
                case -1:
                    _insertItem(item, ref tree.Left);
                    break;
                case 1:
                    _insertItem(item, ref tree.Right);
                    break;
                case 0:
                    return ReturnCode.ValueAlreadyPresent;
            }

            return ReturnCode.OtherError;
        }

        protected virtual ReturnCode _attemptRemoval(ref X nodeToRemove)
        {
            if (nodeToRemove.Childless)
            {
                //Case 1 - No children
                nodeToRemove = null;
                return ReturnCode.Successful;
            }
            if (nodeToRemove.NumberOfChildren == 1)
            {
                // Case 2 - 1 Child
                if (nodeToRemove.Left == null)
                {
                    nodeToRemove = nodeToRemove.Right;
                    return ReturnCode.Successful;
                }
                else
                {
                    nodeToRemove = nodeToRemove.Left;
                    return ReturnCode.Successful;
                }
            }

            //Case 3 :  Two children

            ref X tempNode = ref nodeToRemove.Right;
            Node<T, X>.GetLowestValue(ref tempNode);

            nodeToRemove.Data = tempNode.Data;
            tempNode = null;

            return ReturnCode.Successful;
        }
        
        protected override ReturnCode _removeItem(T item, ref X tree)
        { 
            if (tree.Data.CompareTo(item) == 0) return _attemptRemoval(ref tree);

            if (tree.Left != null) return _removeItem(item, ref tree.Left);
            if (tree.Right != null) return _removeItem(item, ref tree.Right);


            return ReturnCode.OtherError;
        }

        public override ReturnCode RemoveItem(T item)
        {
            return _removeItem(item, ref root);
        }
    }
    
    
}