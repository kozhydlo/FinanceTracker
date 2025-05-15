using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceTracker.Models;
using FinanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Transactions;
using Transaction = FinanceTracker.Models.Transaction;


namespace Testing
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void AddTransaction_ShouldIncreaseCount()
        {
            var manager = new FinanceManager();
            var transaction = new Transaction
            {
                Amount = 100,
                Category = "Salary",
                Type = TransactionType.Income,
                Date = DateTime.Now
            };

            manager.AddTransaction(transaction);

            Assert.AreEqual(1, manager.GetAllTransactions().Count);
        }

        [TestMethod]
        public void GetBalance_ShouldReturnCorrectAmount()
        {
            var manager = new FinanceManager();
            manager.AddTransaction(new Transaction { Amount = 1000, Category = "Salary", Type = TransactionType.Income });
            manager.AddTransaction(new Transaction { Amount = 300, Category = "Food", Type = TransactionType.Expense });

            var balance = manager.GetBalance();

            Assert.AreEqual(700, balance);
        }

        [TestMethod]
        public void FilterByCategory_ShouldReturnCorrectTransactions()
        {
            var manager = new FinanceManager();
            manager.AddTransaction(new Transaction { Amount = 100, Category = "Food", Type = TransactionType.Expense });
            manager.AddTransaction(new Transaction { Amount = 200, Category = "Transport", Type = TransactionType.Expense });

            var result = manager.FilterByCategory("Food");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Food", result[0].Category);
        }

        [TestMethod]
        public void FilterByDateRange_ShouldReturnCorrectTransactions()
        {
            var manager = new FinanceManager();
            var today = DateTime.Today;
            manager.AddTransaction(new Transaction { Amount = 100, Category = "Test", Date = today.AddDays(-1), Type = TransactionType.Income });
            manager.AddTransaction(new Transaction { Amount = 200, Category = "Test", Date = today, Type = TransactionType.Income });

            var result = manager.FilterByDateRange(today, today);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(200, result[0].Amount);
        }
    }
}
