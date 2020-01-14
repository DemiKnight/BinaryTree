using System.Collections;
using System.Linq;
using BinaryTreeFinal;
using NUnit.Framework;

namespace UniqueWordCoursework.Tests
{

    [TestFixture]
    public class CoreDataStructure
    {
        private BinaryTree<int> test = new BinaryTree<int>(1);

        [Test]
        public void BTInsertValues()
        {
            test.InsertItem(2);
            test.InsertItem(3);
            test.InsertItem(4);
            test.InsertItem(5);
            
            // Assert.Contains();
        }

        [Test]
        public void BSContainsBasic()
        {
            Assert.Contains(test.GetValues(), new int[] {2,3, 4, 5});
        }

        [Test]
        public void BSRemoveItemAnyOrder()
        {
            
        }

        [Test]
        public void BSRemoveItemSpecificOrder()
        {
            
        }
    }
}