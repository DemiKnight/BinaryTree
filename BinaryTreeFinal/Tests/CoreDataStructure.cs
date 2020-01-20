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
            test.InsertItem(2);
            test.InsertItem(3);
            test.InsertItem(4);
            test.InsertItem(5);
        }

        [Test]
        public void BSContainsBasic()
        {
            Assert.Contains(test.GetValues(), new int[] {2, 3, 4, 5});
        }

        [Test]
        public void BSRemoveItemAnyOrder()
        {
            
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