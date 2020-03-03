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

        public ref Node<T> Right => ref right;

        public ref Node<T> Left => ref left;

        public T Data
        {
            get => data;
            set => data = value;
        }

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

        protected string _toString()
        {
            return (left != null ? left._toString() : "") + " " + data.ToString() + " " + (right != null ? Right._toString() : "");
        }

        public override string ToString()
        {
            return _toString();
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

        private ref Node<T> _lowestValue( out  Node<T> selNode, Node<T> smallest)
        {
            throw new NotImplementedException();
            //
            // T tempStore = (largest == null ? selNode.data : largest.data);
            //
            // if (tempStore.CompareTo(selNode.data) == -1)
            //     largest = selNode;
            //
            // if (selNode.right != null) _lowestValue(ref selNode.Right, ref largest);
            // if (selNode.left == null && selNode.right == null)
            // {
            //     return ref largest;
            // }
            //
            // return ref left;
        }

        private ref Node<T> _highestValue(ref Node<T> largest)
        {
            if (data.CompareTo(largest.data) == 1) largest = this;
                
            
            
            object testLeft = left?._highestValue( ref largest);
            dynamic testRight = right?._highestValue( ref largest);

            return ref testLeft;
        }

        protected ref Node<T> GetHighestValue()
        {
            ref Node<T> refLargest = this;

            _highestValue(ref refLargest);

            return ref refLargest;
        }
        
        protected ref Node<T> GetLowestValue()
        {
            throw new NotImplementedException();
            // ref Node<T> tempData;
            //
            // if (this.left != null) tempData = _lowestValue(out left);
            // if (this.right != null) _lowestValue(ref Right);
            //
            // //TODO Sort out this shit
            // return tempData;
        }
        
        public ref Node<T> LowestValue
        {
            get => ref GetLowestValue();
        }

        public ref Node<T> LargestValue
        {
            get => ref GetHighestValue();
        }
        
        
    }
}