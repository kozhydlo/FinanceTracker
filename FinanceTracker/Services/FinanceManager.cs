using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Models;

namespace FinanceTracker.Services
{
    public class FinanceManager
    {
        private List<Transaction> _transactions = new();

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public decimal GetBalance()
        {
            return _transactions.Sum(t => t.Type == TransactionType.Income ? t.Amount : -t.Amount);
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions.OrderByDescending(t => t.Date).ToList();
        }

        public List<Transaction> FilterByCategory(string category)
        {
            return _transactions
                .Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Transaction> FilterByDateRange(DateTime from, DateTime to)
        {
            return _transactions
                .Where(t => t.Date >= from && t.Date <= to)
                .ToList();
        }

        public void Load(List<Transaction> transactions)
        {
            _transactions = transactions;
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}
