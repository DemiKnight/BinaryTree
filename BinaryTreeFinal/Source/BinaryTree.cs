using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace BinaryTreeFinal
{
    public class BinaryTree <T> where T:IComparable<T>, IComparable
    {
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

        }

        public int Count
        {

            get => _numberOfNodes;
        }

        public int Height
        {
            get => 0;
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
            throw new NotImplementedException();
            _copy(ref root, tree.root);
        }

        protected virtual void _copy(ref Node<T> tree, Node<T> tree2)
        {
            throw new NotImplementedException();
        }
        
        public virtual void InsertItem(T item)
        {
            throw new NotImplementedException();
            _insertItem(item, ref root);
        }

        protected virtual void _insertItem(T item, ref Node<T> tree)
        {
            throw new NotImplementedException();
            
            
        }

        public virtual void RemoveItem(T item)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            //todo implement this.
            
            throw new NotImplementedException();
            return false;
        }
        
        public bool Equals(BinaryTree<T> tree)
        {
            throw new NotImplementedException();
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
        
        
    }
    
}