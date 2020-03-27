using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Permissions;

namespace BinaryTreeFinal
{
    struct Utilites
    {
        static void Swap<T>( ref T originalPlace, ref T targetPlace)
        {
            (originalPlace, targetPlace) = (targetPlace, originalPlace);
        }
    }

    public class BinaryTree <T> where T:IComparable<T>, IComparable
    {
        /**
         * @brief Standard return for each function.
         */
        public enum ReturnCode
        {
            Successful,
            NotFound,
            UnableToInsert,
            OtherError,
            UnableToRemove,
            ValueAlreadyPresent
        }
        
        /**
         * 
         */
        protected Node<T> root;
        protected int _numberOfNodes = 0;
        protected int _heightOfNodes = 0;

        public BinaryTree(Node<T> root)
        {
            this.root = root;
            _count(ref _numberOfNodes, ref root);
        }

        public BinaryTree(T data)
        {
            this.root = new Node<T>(data);
        }

        private void _count(ref int returnVal, ref Node<T> nextNode)
        {
            returnVal += 1;

            if (nextNode.Left != null)  _count(ref returnVal, ref nextNode.Left);
            if (nextNode.Right != null) _count(ref returnVal, ref nextNode.Right);
        }

        private void _height(ref int returnVal, ref Node<T> nextNode)
        {
            returnVal++;
            
            int rightHeight = 0;
            int leftHeight = 0;
            
            if (nextNode.Left != null) _height(ref leftHeight, ref nextNode.Left);
            if (nextNode.Right != null) _height(ref rightHeight, ref nextNode.Right);

            returnVal += (leftHeight > rightHeight ? leftHeight : rightHeight);
        }

        public int Count
        {
            get => _numberOfNodes;
        }

        protected int _Height()
        {
            int returnVal = 0;
            
            _height(ref returnVal, ref root);
            
            return returnVal;
        }
        
        public int Height
        {
            get => _Height();
        }

        

        public bool Contains(T item)
        {
            return _contains(item, root);
        }

        protected bool _contains(T search, Node<T> rootElement)
        {
            return rootElement.Data.Equals(search) || (_contains(search, root.Left) || _contains(search, root.Right));
        }
        
        public virtual void Copy(BinaryTree<T> tree)
        {
            // throw new NotImplementedException();
            _copy(ref root, tree.root);
        }

        protected virtual void _copy(ref Node<T> target, Node<T> source)
        {
            if (source != null)
            {
                target = new Node<T>(source.Data);
                
                _copy(ref target.Left, source.Left);
                _copy(ref target.Right, source.Right);
            }
        }
        
        public virtual ReturnCode InsertItem(T item)
        {
            throw new NotImplementedException();
            _insertItem(item, ref root);
        }

        protected virtual ReturnCode _insertItem(T item, ref Node<T> tree)
        {
            throw new NotImplementedException();
            
            
        }


        protected virtual ReturnCode _returnItem(ref Node<T> selectedNode, T removalItem)
        {

            return ReturnCode.NotFound;
        }

        protected virtual ReturnCode _removeItem(T item, ref Node<T> tree)
        {
            
            return ReturnCode.NotFound;
        }
        
        public virtual ReturnCode RemoveItem(T item)
        {
            return _removeItem(item, ref root);
        }

        protected virtual bool _equals(ref Node<T> rhs, ref Node<T> lhs)
        {
            if (rhs.Data.Equals(lhs.Data))
            {
                if (rhs.Childless && lhs.Childless) return true;
                
                return _equals(ref lhs.Left, ref rhs.Left) && _equals(ref lhs.Right, ref rhs.Right) ;

            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BinaryTree<T>) || (obj as BinaryTree<T>).Count != this.Count) return false;

            BinaryTree<T> temp = obj as BinaryTree<T>;

            return (_equals(ref root, ref (obj as BinaryTree<T>).root));
        }
        
        public bool Equals(BinaryTree<T> tree)
        {
            return Equals(tree);
        }

        public virtual void CopyTo(ref BinaryTree<T> tree)
        {
            throw new NotImplementedException();
        }

        public virtual bool SubTree(BinaryTree<T> tree)
        {
            throw new NotImplementedException();
        }

        public T[] GetValues()
        {
            List<T> returnList = new List<T>();

            _getValues(ref returnList, root);

            return returnList.ToArray();
        }

        private void _getValues(ref List<T> returnList, Node<T> rootNode) 
        {
            returnList.Add(rootNode.Data);
            _getValues(ref returnList, rootNode.Left);
            _getValues(ref returnList, rootNode.Right);
        }

        /**
         * 
         */
        public override string ToString()
        {
            return GetValues().ToString();
        }


        public Node<T> GetRoot()
        {
            return root.Clone();
        }
    }
    
}