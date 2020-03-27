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
        

        public override ReturnCode InsertItem(T item)
        {
            return _insertItem(item, ref root);
        }

        protected override ReturnCode _insertItem(T item, ref Node<T> tree)
        {
            if (tree == null) tree = new Node<T>(item);

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
            // base._insertItem(item, ref tree);

            return ReturnCode.OtherError;
        }

        protected virtual ReturnCode _attemptRemoval(ref Node<T> nodeToRemove)
        {
            if (nodeToRemove.Childless)
            {
                //Case 1 - No children
                nodeToRemove = null;
                return ReturnCode.Successful;
            }
            if (nodeToRemove.NumberOfChildren == 1)
            {
                // Case 2 
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
            if (nodeToRemove.Right != null)
            {
                Node<T> tempNode = nodeToRemove.Right;
                nodeToRemove.Right.GetLowestValue(ref tempNode);

                nodeToRemove.Data = tempNode.Data;
                tempNode = null;


                // nodeToRemove.Data = nodeToRemove.Right.GetLowestValue().Data;
                // nodeToRemove.Right.LowestValue = null;  
            }
            else
            {
                Node<T> tempNode = nodeToRemove.Left;
                nodeToRemove.Left.GetLowestValue(ref tempNode);

                nodeToRemove.Data = tempNode.Data;
                tempNode = null;

            }
            return ReturnCode.Successful;
        }
        
        protected override ReturnCode _removeItem(T item, ref Node<T> tree)
        {
            if (tree.Data.CompareTo(item) == 0)
            {
                return _attemptRemoval(ref tree);
            }
            else
            {
                if (tree.Left != null) return _removeItem(item, ref tree.Left);
                else if (tree.Right != null) return _removeItem(item, ref tree.Right);
            }

            return ReturnCode.OtherError;
        }

        public override ReturnCode RemoveItem(T item)
        {
            return _removeItem(item, ref root);
        }
    }
    
    
}