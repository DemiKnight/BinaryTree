using System;
using NUnit.Framework;

namespace BinaryTreeFinal.Tests
{
    [TestFixture]
    public class NodeDataTest
    {
        private static Random rnd = new Random();

        private int testInt = rnd.Next(10000);
        private string testStr = "TestString2";
        private dynamic testObj = new
        {
            infoInt = 120
        };
        
        [Test]
        public void Constructor()
        {
            // int testInt = rnd.Next(10000);
            // string testStr = "TestString2";
            // var testObj = new
            // {
            //     infoInt = 120
            // };
            
            Node<int> testNodeInt = new Node<int>(testInt);
            Assert.Equals(testNodeInt.Data, testInt);

            Node<string> testNodeStr = new Node<string>(testStr);
            Assert.Equals(testNodeInt.Data, testStr);
            
            Node<dynamic> testNodeObj = new Node<dynamic>(testObj);
            Assert.Equals(testNodeObj.Data, testNodeObj);
            Assert.Equals(testNodeObj.Data.infoInt, testObj.infoInt);
        }

        [Test]
        public void EqualityCheck()
        {
            Node<int> testNode1 = new Node<int>(1);
            Node<int> testNode2 = new Node<int>(2);
            Node<int> testNode3 = new Node<int>(3);
            Node<int> testNode4 = new Node<int>(4);

            testNode1.Left = testNode2;
            testNode1.Right = testNode3;
            testNode1.Left.Left = testNode4;
            
        }
        
        
        [Test]
        public void ChildNodeData()
        {
            
        }
        
    }
}