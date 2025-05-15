using System;
using FinanceTracker.Models;
using FinanceTracker.Services;
using FinanceTracker.Helpers;

class Program
{
    static void Main()
    {
        try
        {
            var manager = new FinanceManager();
            manager.Load(FileManager.LoadFromFile());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Finance Tracker ==");
                Console.WriteLine("1. Add transaction");
                Console.WriteLine("2. View balance");
                Console.WriteLine("3. View all transactions");
                Console.WriteLine("4. Filter by category");
                Console.WriteLine("5. Filter by date");
                Console.WriteLine("6. Save to file");
                Console.WriteLine("0. Exit");
                Console.Write("\nChoose option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": AddTransaction(manager); break;
                    case "2": ShowBalance(manager); break;
                    case "3": ShowTransactions(manager.GetAllTransactions()); break;
                    case "4": FilterByCategory(manager); break;
                    case "5": FilterByDate(manager); break;
                    case "6":
                        FileManager.SaveToFile(manager.GetTransactions());
                        Console.WriteLine("Saved successfully!");
                        Pause();
                        break;
                    case "0":
                        FileManager.SaveToFile(manager.GetTransactions());
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.ToString());
            Console.WriteLine("An error occurred. See log.txt for details.");
        }
    }

    static void AddTransaction(FinanceManager manager)
    {
        Console.Clear();
        Console.Write("Amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount.");
            Pause();
            return;
        }

        Console.Write("Category: ");
        var category = Console.ReadLine();

        Console.Write("Type (1 - Income, 2 - Expense): ");
        var typeInput = Console.ReadLine();
        TransactionType type = typeInput == "1" ? TransactionType.Income : TransactionType.Expense;

        var transaction = new Transaction
        {
            Amount = amount,
            Category = category,
            Type = type,
            Date = DateTime.Now
        };

        manager.AddTransaction(transaction);
        Console.WriteLine("Transaction added!");
        Pause();
    }

    static void ShowBalance(FinanceManager manager)
    {
        Console.Clear();
        Console.WriteLine($"Current balance: {manager.GetBalance():C}");
        Pause();
    }

    static void ShowTransactions(List<Transaction> transactions)
    {
        Console.Clear();
        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions found.");
        }
        else
        {
            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.Date:yyyy-MM-dd HH:mm} | {t.Type} | {t.Category} | {t.Amount:C}");
            }
        }
        Pause();
    }

    static void FilterByCategory(FinanceManager manager)
    {
        Console.Clear();
        Console.Write("Enter category: ");
        var category = Console.ReadLine();
        var filtered = manager.FilterByCategory(category);
        ShowTransactions(filtered);
    }

    static void FilterByDate(FinanceManager manager)
    {
        Console.Clear();
        Console.Write("From date (yyyy-mm-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var from))
        {
            Console.WriteLine("Invalid date.");
            Pause();
            return;
        }

        Console.Write("To date (yyyy-mm-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var to))
        {
            Console.WriteLine("Invalid date.");
            Pause();
            return;
        }

        var filtered = manager.FilterByDateRange(from, to);
        ShowTransactions(filtered);
    }

    static void Pause()
    {
        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
    }
}
