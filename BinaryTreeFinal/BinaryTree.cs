using System;

namespace BinaryTreeFinal
{
    public class BinaryTree <T> where T:IComparable<T>, IComparable
    {
        protected Node<T> root;

        protected void AddToNode(ref Node<T> newNode, T data)
        {
            if (newNode == null)
            {
                newNode = new Node<T>(data);
            }
            else
            {
                newNode.Data = data;
            }
        }
        
        public BinaryTree(Node<T> root)
        {
            this.root = root;
        }

        public BinaryTree(T data)
        {
            this.root = new Node<T>(data);
        }

        public virtual void AddItem(T newData)
        {
            AddItem(ref root, newData);
        }

        protected virtual void AddItem(ref Node<T> selectedNode,T newData)
        {
            if(selectedNode.Left == null) selectedNode.Left = new Node<T>(newData); 
            else if(selectedNode.Right == null) selectedNode.Right = new Node<T>(newData);
            else
            {
                AddItem(ref selectedNode.Left,newData);
            }
        }

        public int NUmOfBranches
        { //TODO
            get => 0;
        }
        
        
    }
    
}