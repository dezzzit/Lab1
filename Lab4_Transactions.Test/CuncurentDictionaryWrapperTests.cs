using System;
using Lab4_Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace Lab4_UsingTransactions
{
    [TestClass]
    public class CuncurentDictionaryWrapperTests
    {

        private CuncurentDictionaryWrapper<string, int> _dict; 
        [TestInitialize]
        public void TestInitialize()
        {
            
            _dict = new CuncurentDictionaryWrapper<string, int>();
        }

        [TestMethod]
        public void Add_UsingTransactions()
        {
            // Arrange
            _dict.BeginTransaction();

            // Act
            _dict.Add("3", 3);
            _dict.Commit();

            // Assert
            Assert.AreEqual(_dict.Get("3"),3);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Remove_UsingTransactions()
        {
            // Arrange
            _dict.Add("4", 4);
            _dict.BeginTransaction();

            // Act
            _dict.Remove("4");
            _dict.Commit();

            // Assert
            _dict.Get("4");
        }

        [TestMethod]
        public void Get_UsingUncommitedTransactions()
        {
            // Arrange
            
            _dict.BeginTransaction();

            // Act
            _dict.Add("4", 4);

            // Assert
            Assert.AreEqual(_dict.Get("4"),4);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Remove_UsingUncommitedTransactions()
        {
            // Arrange
            _dict.Add("4", 4);
            _dict.BeginTransaction();

            // Act
            _dict.Remove("4");

            // Assert
            _dict.Get("4");
        }

        [TestMethod]
        public void Get_UsingTransactions()
        {
            // Arrange

            _dict.BeginTransaction();

            // Act
            _dict.Add("4", 4);
            _dict.Commit();

            // Assert
            Assert.AreEqual(_dict.Get("4"), 4);
        }

        [TestMethod]
        public void Rollbacstring_UsingTransactions()
        {
            // Arrange
            _dict.Add("5", 5);
            _dict.BeginTransaction();

            // Act
            
            _dict.Remove("5");
            _dict.Rollback();

            // Assert
            Assert.AreEqual(_dict.Get("5"), 5);
        }

        
    }
}
