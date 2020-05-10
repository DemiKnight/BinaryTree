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

    public class BinaryTree <T, X> where T:IComparable<T> where X : Node<T, X>, new()
    {

        public BinaryTree(T data)
        {
            this.root = new X {Data = data};
        }

        public BinaryTree(X root)
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
        protected X root;

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

        protected bool _contains(T search, X rootElement)
        {
            return rootElement.Data.Equals(search) || (_contains(search, root.Left) || _contains(search, root.Right));
        }

        public bool Contains(T item)
        {
            return _contains(item, root);
        }

        protected virtual void _copy(ref X target, X source)
        {
            if (source == null) return; //TODO Evaluate my life choices and see if this will let me sleep.
            target = new X() {Data = source.Data };

            _copy(ref target.Left, source.Left);
            _copy(ref target.Right, source.Right);
        }

        public virtual void Copy(BinaryTree<T, X> tree)
        {
            _copy(ref root, tree.root);
        }

        /**
         * @brief Randomly assigns values within the binary tree.
         */
        protected virtual ReturnCode _insertItem(T item, ref X tree)
        {

            ref X selectNode = ref tree.Right;

            if (new Random(23).Next(11) % 2 == 0)
            {
                selectNode = ref tree.Left;
            }

            if (selectNode == null)
            {
                selectNode = new X() { Data = item };
                return ReturnCode.Successful;
            }

            return _insertItem(item, ref selectNode);
        }


        public virtual ReturnCode InsertItem(T item)
        {
            _insertItem(item, ref root);
            return ReturnCode.Successful;
        }

        protected virtual ReturnCode _returnItem(ref X selectedNode, T removalItem)
        {

            return ReturnCode.NotFound;
        }

        protected virtual ReturnCode _removeItem(T item, ref X tree)
        {
            
            return ReturnCode.NotFound;
        }
        
        public virtual ReturnCode RemoveItem(T item)
        {
            return _removeItem(item, ref root);
        }

        protected virtual bool _equals(ref X rhs, ref X lhs)
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
            if (!(obj is BinaryTree<T, X>) || ((BinaryTree<T, X>) obj).Count != this.Count) return false;

            BinaryTree<T, X> temp = obj as BinaryTree<T, X>;

            return (_equals(ref root, ref ((BinaryTree<T, X>) obj).root));
        }
        
        public bool Equals(BinaryTree<T, X> tree)
        {
            return Equals(tree);
        }

        public virtual void CopyTo(ref BinaryTree<T, X> tree)
        {
            throw new NotImplementedException();
        }

        public virtual bool SubTree(BinaryTree<T, X> tree)
        {
            throw new NotImplementedException();
        }

        public T[] GetValues()
        {
            List<T> returnList = new List<T>();

            if(root != null) _getValues(ref returnList, root);

            return returnList.ToArray();
        }

        private void _getValues(ref List<T> returnList, X rootNode) 
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


        public X GetRoot()
        {
            //TODO Change to deep clone
            return root.Clone();
        }
    }
    
}