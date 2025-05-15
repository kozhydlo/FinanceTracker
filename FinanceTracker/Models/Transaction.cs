using System;

namespace FinanceTracker.Models
{
    public enum TransactionType
    {
        Income,
        Expense
    }

    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
    }
}
