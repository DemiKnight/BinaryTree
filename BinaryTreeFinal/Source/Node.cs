using System;
using System.Collections.Generic;

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

        public void test(TraversingMethod method, Delegate callBack)
        {
            // switch (method)
            // {
            //     case TraversingMethod.InOrder => callBack();
            // }   
        }
        
        
        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(data);
        }

        protected string _toString()
        {
            return left._toString() + " " + data.ToString() + Right._toString() + " ";
        }

        public override string ToString()
        {
            return _toString();
        }
    }
}