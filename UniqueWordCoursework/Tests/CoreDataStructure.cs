using System.Collections;
using BinaryTreeFinal;
using NUnit.Framework;

namespace UniqueWordCoursework.Tests
{

    [TestFixture]
    public class CoreDataStructure
    {
        private BinaryTree<int> test;

        public CoreDataStructure()
        {
            test.InsertItem(2);
            test.InsertItem(3);
            test.InsertItem(4);
            test.InsertItem(5);
        }

        // [TestCaseSource(typeof(TestData), "AddData")]
        public bool checkAdd()
        {
            BinaryTree<int> test = new BinaryTree<int>(1);
            // Assert.That(test, Equals() );
            
            
            return true;
        }
        
    }

    public class TestData
    {
        public static IEnumerable AddData
        {
            get
            {
                yield return new TestCaseData(2).Returns(2);
            }
        }
    }
    
    
}