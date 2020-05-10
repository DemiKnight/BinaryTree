using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Security.Permissions;

namespace BinaryTreeFinal
{
    struct Utilites
    {
        /**
         * @brief Swap two variables around,
         */
        static void Swap<T>( ref T originalPlace, ref T targetPlace)
        {
            (originalPlace, targetPlace) = (targetPlace, originalPlace);
        }
    }

    public class BinaryTree <T> where T:IComparable<T>, IComparable
    {

        public BinaryTree(T data)
        {
            this.root = new Node<T>(data);
        }

        public BinaryTree(Node<T> root)
        {
            this.root = root;

            _numberOfNodes = Count;
        }


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

        /**
         * @brief Used as a cache, will be set to -1 if a node change has occured.
         * For inserting or removing a single item, the counter can be updated accordingly.
         * However if a tree merge or other complex change occurs, setting it to -1 will save future bugs.
         */
        protected int _numberOfNodes = -1;

        /**
         * @brief Used as a cache, will be set to -1 if a node change has occured.
         * If a change happens, this will be set to -1. Once re-calculated, this will be updated for future
         * reference.
         */
        protected int _heightOfNodes = -1;


        public int Count
        {
            get
            {
                if (_numberOfNodes == -1)
                {
                    _numberOfNodes = root.Count(ref root);
                }

                return _numberOfNodes;
            }
        }

        public int Height
        {
            get
            {
                if (_heightOfNodes == -1)
                {
                    _heightOfNodes = root.Height();
                }

                return _heightOfNodes;
            }
        }

        protected bool _contains(T search, Node<T> rootElement)
        {
            return rootElement.Data.Equals(search) || (_contains(search, root.Left) || _contains(search, root.Right));
        }

        public bool Contains(T item)
        {
            return _contains(item, root);
        }

        protected virtual void _copy(ref Node<T> target, Node<T> source)
        {
            if (source == null) return; //TODO Evaluate my life choices and see if this will let me sleep.
            target = new Node<T>(source.Data);

            _copy(ref target.Left, source.Left);
            _copy(ref target.Right, source.Right);
        }

        public virtual void Copy(BinaryTree<T> tree)
        {
            _copy(ref root, tree.root);
        }

        /**
         * @brief Randomly assigns values within the binary tree.
         */
        protected virtual ReturnCode _insertItem(T item, ref Node<T> tree)
        {

            ref Node<T> selectNode = ref tree.Right;

            if (new Random(23).Next(11) % 2 == 0)
            {
                selectNode = ref tree.Left;
            }

            if (selectNode == null)
            {
                selectNode = new Node<T>(item);
                return ReturnCode.Successful;
            }

            return _insertItem(item, ref selectNode);
        }


        public virtual ReturnCode InsertItem(T item)
        {
            _insertItem(item, ref root);
            return ReturnCode.Successful;
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

            if(root != null) _getValues(ref returnList, root);

            return returnList.ToArray();
        }

        private void _getValues(ref List<T> returnList, Node<T> rootNode) 
        {
            returnList.Add(rootNode.Data);
            if(rootNode.Left != null) _getValues(ref returnList, rootNode.Left);
            if (rootNode.Right != null)  _getValues(ref returnList, rootNode.Right);
        }

        /**
         * @brief, prints out the content of the tree, from left to right.
         * @see Node.ToString()
         */
        public override string ToString()
        {
            return root.ToString();
        }


        public Node<T> GetRoot()
        {
            //TODO Change to deep clone
            return root.Clone();
        }
    }
    
}