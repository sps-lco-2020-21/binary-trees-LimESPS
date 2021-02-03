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
            Assert.AreEqual(true, tree.check(5));
            Assert.AreEqual(false, tree.check(40));
            tree.delete(20);
            Assert.AreEqual(false, tree.check(20));
            Assert.AreEqual(true, tree.check(10));
        }
    }
}
