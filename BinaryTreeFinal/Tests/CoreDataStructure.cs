using NUnit.Framework;

namespace BinaryTreeFinal.Tests
{

    [TestFixture]
    public class CoreDataStructure
    {
        private BinaryTree<int> test = new BinaryTree<int>(1);
        private Node<int> currentTestNode;


        [SetUp]
        public void PreTest()
        {
            currentTestNode = new Node<int>(1);
            currentTestNode.Left = new Node<int>(2);
            currentTestNode.Right = new Node<int>(3);
            currentTestNode.Left.Left = new Node<int>(4);
            test = new BinaryTree<int>(currentTestNode);
        }

        [Test]
        public void BTInsertValues()
        {
            
            // test.InsertItem(2);
            // test.InsertItem(3);
            // test.InsertItem(4);
            test.InsertItem(5);
            test.InsertItem(6);
            Assert.Contains(test.GetValues(), new int[] {1, 2, 3, 4, 5, 6 });
        }

        [Test]
        public void BSContainsBasic()
        {
            Assert.Contains(test.GetValues(), new int[] {2, 3, 4, 5});
        }

        [Test]
        public void BSRemoveChildlessChild()
        {
            test.RemoveItem(4);
            Assert.Contains(test.GetValues(), new int[] {1,2,3}, "Remove child without children");
            Assert.AreEqual(test.ToString(), "1 2 3", "Remove child without children, with correct order.");
            // test.RemoveItem(5);
        }
        
        [Test]
        public void BSRemoveChildWithChildren()
        {
            test.RemoveItem(2);
            Assert.Contains(test.GetValues(), new int[] {1,3,4,5}, "Remove child with children");
            Assert.AreEqual(test.ToString(),  "1 3 4", "Remove child with children, correct order");
        }

        [Test]
        public void BSRemoveRoot()
        {
            test.RemoveItem(1);
            Assert.Contains(test.GetValues(), new int[] {2,3,4,5}, "Remove Root Element");
            Assert.AreEqual(test.ToString(),  "2 3 4", "Remove root, correct order");
        }
        
        [Test]
        public void BSRemoveItemSpecificOrder()
        {
            
        }

        [Test]
        public void BSCountCheck()
        {
            Assert.AreEqual(4, test.Count, "Count()");
            test.InsertItem(5);
            Assert.AreEqual(5, test.Count, "Count() + adding new value");
        }

        [Test]
        public void BSHeightCheck()
        {
            Assert.AreEqual(test.Height, 3, "Height Test");
            test.InsertItem(5);
            Assert.AreEqual(test.Height, 3, "Height Test, after insertion");
            test.InsertItem(6);
            Assert.AreEqual(test.Height, 4, "Height Test, after insertion x2");
        }

        [Test]
        public void BSShallowCopyCheck()
        {
            
        }

        [Test]
        public void BSEqualityCheck()
        {
            
        }
    }
}