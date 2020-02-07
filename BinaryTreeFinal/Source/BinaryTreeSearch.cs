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
        
        /**
         * @param lhs This should have null data.
         */
        public virtual Node<T> MergeTrees(ref Node<T> lhs, ref Node<T> rhs )
        {
        
            

            return null;
        }
        

        public override RETURN_Code InsertItem(T item)
        {
            return _insertItem(item, ref root);
        }

        protected override RETURN_Code _insertItem(T item, ref Node<T> tree)
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
                    return RETURN_Code.ValueAlreadyPresent;
            }
            // base._insertItem(item, ref tree);

            return RETURN_Code.OtherError;
        }

        protected virtual RETURN_Code _attemptRemoval(ref Node<T> nodeToRemove)
        {
            if (nodeToRemove.Childless)
            {
                //Case 1
                nodeToRemove = null;
                return RETURN_Code.Sucessful;
            }
            if (nodeToRemove.NumberOfChildren == 1)
            {
                // Case 2 
                if (nodeToRemove.Left == null)
                {
                    nodeToRemove = nodeToRemove.Right;
                    return RETURN_Code.Sucessful;
                }
                else
                {
                    nodeToRemove = nodeToRemove.Left;
                    return RETURN_Code.Sucessful;
                }

                
            }
            else
            {
                //Case 3 :  Two children

                nodeToRemove = MergeTrees(ref nodeToRemove.Left, ref nodeToRemove.Right);

                return RETURN_Code.Sucessful;
            }
        }
        
        protected override RETURN_Code _removeItem(T item, ref Node<T> tree)
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

            return RETURN_Code.OtherError;
        }

        public override RETURN_Code RemoveItem(T item)
        {
            return _removeItem(item, ref root);
        }
    }
    
    
}