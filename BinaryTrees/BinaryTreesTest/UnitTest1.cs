using System;
using BinaryTrees.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add()
        {
            TreeList tree = new TreeList();
            tree.Add(5);
            tree.Add(3);
            tree.Add(20);
            Assert.AreEqual(true, tree.check(5));
            Assert.AreEqual(false, tree.check(40));
        }
        [TestMethod]
        public void Delete()
        {
            TreeList tree = new TreeList();
            tree.Add(5);
            tree.Add(3);
            tree.Add(20);
            tree.Add(10);
            tree.Add(15);
            tree.Add(9);
            Assert.AreEqual(true, tree.check(5));
            Assert.AreEqual(false, tree.check(40));
            tree.delete(20);
            Assert.AreEqual(false, tree.check(20)); //checks that delete function for one child works (it works!), how do you delete pointer for deleted node?
            Assert.AreEqual(true, tree.check(10));
            Assert.AreEqual(true, tree.check(15));
            
        }
        [TestMethod]
        public void Delete_Two()
        {
            TreeList tree = new TreeList();
            tree.Add(5);
            tree.Add(3);
            tree.Add(20);
            tree.Add(10);
            tree.Add(15);
            tree.Add(9);
            tree.delete(10);
            Assert.AreEqual(false, tree.check(10));
            Assert.AreEqual(true, tree.check(15));
            Assert.AreEqual(true, tree.check(9));
        }
        [TestMethod]
        public void depth()
        {
            TreeList tree = new TreeList();
            tree.Add(5);
            tree.Add(3);
            tree.Add(20);
            tree.Add(10);
            tree.Add(15);
            tree.Add(9);
            int count = tree.depth();
            Assert.AreEqual(4, tree.depth()); //works but I still need to have the code go both ways every time 2 children are encountered
            
        }
        [TestMethod]
        public void sum()
        {
            TreeList tree = new TreeList();
            tree.Add(5);
            tree.Add(3);
            tree.Add(20);
            tree.Add(10);
            tree.Add(15);
            tree.Add(9);
        
            Assert.AreEqual(62, tree.sum()); //works but I still need to have the code go both ways every time 2 children are encountered

        }

    }
}
