using System;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace BinaryTreeFinal
{
    public class Node <T> where T:IComparable
    {
        private T data;
        private Node<T> right, left;

        public Node(T comparable)
        {
            this.data = comparable;
        }

        public Node(T newData, Node<T> newLeft, Node<T> newRight)
        {
            this.data = newData;
            this.left = newLeft;
            this.right = newRight;
        }

        public ref Node<T> Right => ref right;

        public ref Node<T> Left => ref left;

        public T Data
        {
            get => data;
            set => data = value;
        }

        public int BalanceFactor { get; set; } = 0;

        protected bool Equals(Node<T> other)
        {
            return EqualityComparer<T>.Default.Equals(data, other.data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(data);
        }

        public override string ToString()
        {
            // return (left?.ToString() ?? "") + " " + data.ToString() + " " + (right?.ToString() ?? "");

            // return (left != null ? left.ToString() : "") + " " + data.ToString() + " " + (right != null ? Right.ToString() : "");
            return "";
        }

        public bool Childless
        {
            get => left == null && right == null;
        }

        private int _numberOfChildren()
        {
            int returnVal = 0;

            if (left != null) returnVal++;
            if (right != null) returnVal++;

            return returnVal;
        }
        public int NumberOfChildren
        {
            get => _numberOfChildren();
        }

        private void _lowestValue(ref Node<T> smallestNode)
        {
            if (data.CompareTo(smallestNode.data) == -1) smallestNode = this;

            left?._lowestValue(ref smallestNode);
            right?._lowestValue(ref smallestNode);
        }
        public static void GetLowestValue(ref Node<T> startNode)
        {
            startNode._lowestValue(ref startNode);
        }

        private void _highestValue(ref Node<T> largestNode)
        {
            //TODO Improve this redundant code
            if (data.CompareTo(largestNode.data) == 1) largestNode = this;


            left?._highestValue(ref largestNode);
            right?._highestValue(ref largestNode);
        }

        public static void GetHighestValue(ref Node<T> startNode)
        {
            startNode._highestValue(ref startNode);
            
        }

        internal Node<T> Clone()
        {
            return new Node<T>(data, left, right);
        }

        private void _height(ref int returnVal)
        {
            returnVal++;

            int rightHeight = 0;
            int leftHeight = 0;

            left?._height(ref leftHeight);
            right?._height(ref rightHeight);

            returnVal += (leftHeight > rightHeight ? leftHeight : rightHeight);
        }

        public int Height()
        {
            int returnVal = 0;

            _height(ref returnVal);

            return returnVal;
        }

    }
}