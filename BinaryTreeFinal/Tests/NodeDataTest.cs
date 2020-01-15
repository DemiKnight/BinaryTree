using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BinaryTreeFinal.Tests
{
    class DummyObject : IComparable<int>, IComparable<DummyObject>
    {
        private int infoInt;
    
        public int InfoInt
        {
            get => infoInt;
            set => infoInt = value;
        }

        public int CompareTo(int other)
        {
            return ( infoInt == other ? 0 : (infoInt < other ? -1 : 1));
        }

        public int CompareTo(DummyObject other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return infoInt.CompareTo(other.infoInt);
        }
    }
    
    [TestFixture]
    public class NodeDataTest
    {
        private static Random rnd = new Random();

        private Node<int> currentTestNode;
        
        private int testInt = rnd.Next(10000);
        private string testStr = "TestString2";
        // private LinkedList<int> testObj = new LinkedList<int>();
        
        [Test]
        public void Constructor()
        {
            Node<int> testNodeInt = new Node<int>(testInt);
            Assert.AreEqual(testInt, testNodeInt.Data);

            Node<string> testNodeStr = new Node<string>(testStr);
            Assert.AreEqual(testStr, testNodeStr.Data);
            
            // Node<LinkedList<>> testNodeObj = new Node<LinkedList<>>(testObj);
            // Assert.AreEqual(testNodeObj, testNodeObj.Data);
            // Assert.AreEqual(testObj.InfoInt, testNodeObj.Data.InfoInt );
        }

        /**
         *       1
         *      / \ 
         *     2   3
         *    /
         *   4
         */
        [SetUp]
        public void PreTest()
        {
            currentTestNode = new Node<int>(1);
            currentTestNode.Left = new Node<int>(2);
            currentTestNode.Right = new Node<int>(3);
            currentTestNode.Left.Left = new Node<int>(4);
            
            // Node<int> testNode1 = new Node<int>(1);
            // Node<int> testNode2 = new Node<int>(2);
            // Node<int> testNode3 = new Node<int>(3);
            // Node<int> testNode4 = new Node<int>(4);
            // testNode1.Left = testNode2;
            // testNode1.Right = testNode3;
            // testNode1.Left.Left = testNode4;
        }

        /**
         * Checks toString and nesting nodes work.
         */
        [Test]
        public void ToStringCheck()
        {
            Assert.AreEqual(" 4 2 1 3 ", currentTestNode.ToString());
        }

        /**
         * Checks whether the Equals function works for comparison.
         */
        [Test]
        public void EqualityCheck()
        {
            Node<int> emptyNode = new Node<int>(1);
            Assert.IsFalse(emptyNode.Equals(currentTestNode), "Comparing empty/shallow (no children) node to target");
            
            Node<int> similarChildren = new Node<int>(1);
            similarChildren.Left = new Node<int>(2);
            similarChildren.Right = new Node<int>(3);
            Assert.IsFalse(similarChildren.Equals(currentTestNode), "Comparing Shallow (2 children) node to target");
            
            Node<int> sameNode = new Node<int>(1);
            sameNode.Left = new Node<int>(2);
            sameNode.Right = new Node<int>(3);
            sameNode.Left.Left = new Node<int>(4);
            Assert.IsTrue(sameNode.Equals(currentTestNode));
        }
        
        
        
        
        // [Test]
        // public void ChildNodeData()
        // {
        //     
        // }
        
    }
}