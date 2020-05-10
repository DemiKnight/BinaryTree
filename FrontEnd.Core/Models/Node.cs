using System;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace BinaryTreeFinal
{
    public class Node <T, X> where T:IComparable<T> where X:Node<T, X>, new()
    {
        public Node(T comparable)
        {
            this.Data = comparable;
        }

        public Node()
        {

        }

        public Node(T newData, X newLeft, X newRight)
        {
            this.Data = newData;
            this._left = newLeft;
            this._right = newRight;
        }

        private X _right, _left;

        /**
         * @brief Reference to the Right node, could be null.
         */
        public ref X Right => ref _right;

        /**
         * @brief Reference to the Left node, could be null.
         */
        public ref X Left => ref _left;

        /**
         * @brief Stores the value for this particular node.
         */
        public T Data { get; set; }

        /**
         * @brief Abstract value to be used within a algorithm to sort.
         */
        public int BalanceFactor { get; set; } = 0;

        protected bool Equals(X other)
        {
            return EqualityComparer<T>.Default.Equals(Data, other.Data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((X) obj);
        }

        /**
         * @brief Hash code of the value, depends on the numeric value being unique.
         */
        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Data);
        }

        /**
         * @brief Will print the entire tree, Left to Right
         */
        public override string ToString()
        {
            return (_left?.ToString() ?? "") + " " + Data.ToString() + " " + (_right?.ToString() ?? "");
        }

        /**
         * @brief Check if the Node is childless.
         */
        public bool Childless => _left == null && _right == null;

        /**
         * @brief Can either be 0, 1 or 2
         */
        private int _numberOfChildren()
        {
            int returnVal = 0;

            if (_left != null) returnVal++;
            if (_right != null) returnVal++;

            return returnVal;
        }

        /**
         * @brief Get the number of child nodes, not recursively. 
         */
        public int NumberOfChildren => _numberOfChildren();

        /**
         * @brief Set the input reference to the lowest value node.
         * @depreciated 
         */
        private void _lowestValue(ref X smallestNode)
        {
            if (Data.CompareTo(smallestNode.Data) == -1) smallestNode = (X) this;

            _left?._lowestValue(ref smallestNode);
            _right?._lowestValue(ref smallestNode);
        }

        /**
         * @brief Set the input reference to the greatest value node.
         * @depreciated 
         */
        private void _highestValue(ref X largestNode)
        {
            if (Data.CompareTo(largestNode.Data) == 1) largestNode = (X) this;

            _left?._highestValue(ref largestNode);
            _right?._highestValue(ref largestNode);
        }


        private void _equalsValue(ref X smallestNode, short checkAgainst)
        {
            if (Data.CompareTo(smallestNode.Data) == checkAgainst) smallestNode = (X) this;

            _left?._equalsValue(ref smallestNode, checkAgainst);
            _right?._equalsValue(ref smallestNode, checkAgainst);
        }

        public static void GetHighestValue(ref X startNode)
        {
            startNode._equalsValue(ref startNode, 1);
            
        }
        public static void GetLowestValue(ref X startNode)
        {
            startNode._equalsValue(ref startNode, -1);
        }

        /**
         * @brief Shallow clone of the tree
         *
         */
        internal X Clone()
        {
            return new X() {Data = Data, Left = _left, Right = _right};
        }


        /**
         * @brief Recursively check child node for the furthest path.
         *
         */
        private void _height(ref int returnVal)
        {
            returnVal++;

            int rightHeight = 0;
            int leftHeight = 0;

            _left?._height(ref leftHeight);
            _right?._height(ref rightHeight);

            returnVal += (leftHeight > rightHeight ? leftHeight : rightHeight);
        }

        /**
         * @brief Calculate the Depth of the subtree
         */
        public int Height()
        {
            int returnVal = 0;

            _height(ref returnVal);

            return returnVal;
        }

        private void _count(ref X selectedNode, ref int returnCounter)
        {
            returnCounter++;

            selectedNode._left?._count(ref selectedNode._left, ref returnCounter);
            selectedNode._right?._count(ref selectedNode._right, ref returnCounter);
        }

        /**
         * @brief Will count the number of 
         */
        public int Count(ref X startNode)
        {
            int returnCount = 0;

            _count(ref startNode, ref returnCount);

            return returnCount;
        }

    }
}