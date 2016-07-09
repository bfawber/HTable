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

        [TestMethod]
        public void Using_Contains_To_Check_Membership()
        {
            this.testTable.Push("1", "one");
            this.testTable.Push("1", "onetwo");
            this.testTable.Push("2", "one");
            this.testTable.Push("3", "three");
            this.testTable.Push("20", "twenty");

            Assert.IsTrue(testTable.Contains("one"));
            Assert.IsTrue(testTable.Contains("onetwo"));
            Assert.IsTrue(testTable.Contains("three"));
            Assert.IsTrue(testTable.Contains("twenty"));
            Assert.IsFalse(testTable.Contains("20"));
        }

        [TestMethod]
        public void Clear_Makes_List_Empty()
        {
            testTable.Clear();
            Assert.AreEqual(default(string), testTable.Pop("one"));
            Assert.IsTrue(testTable.IsEmpty());
        }

        [TestCleanup]
        public void CleanUp()
        {
            
        }
    }
}
