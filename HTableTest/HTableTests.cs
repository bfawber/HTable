using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTable;

namespace HTableTest
{
    [TestClass]
    public class HTableTests
    {
        private HTbl<string, string> testTable;

        [TestInitialize]
        public void Initialize()
        {
            this.testTable = new HTbl<string, string>();
        }

        [TestMethod]
        public void Pushing_Popping_Adds_and_Removes()
        {
            Assert.AreEqual(default(string), testTable.Pop("one"), "Thinks there is a value!");
            this.testTable.Push("one", "1");
            this.testTable.Push("one", "one");
            Assert.AreNotEqual(default(string), testTable.Pop("one"), "Did not get value correctly!");
            Assert.AreNotEqual(default(string), testTable.Pop("one"), "Did not get value correctly!");
            Assert.AreEqual(default(string), testTable.Pop("one"), "Thinks there is still a value!");
        }

        [TestCleanup]
        public void CleanUp()
        {
            
        }
    }
}
