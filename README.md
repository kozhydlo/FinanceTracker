# Finance Tracker

A simple console-based finance tracker built with C#. Track your income, expenses, and get insights into your financial activity.

---

## Features

* Add transactions (Income or Expense)
* View current balance
* View all transactions
* Filter transactions by category
* Filter transactions by date range
* Auto-save and manual save to a file
* Error logging to `log.txt`

---

## Installation

1. Make sure you have [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Clone the repository:

```bash
git clone https://github.com/kozhydlo/FinanceTracker.git
```

3. Navigate to the project folder:

```bash
cd FinanceTracker
```

4. Build the project:

```bash
dotnet build
```

5. Run the app:

```bash
dotnet run
```

---

## Usage

When you run the application, you'll see a menu like this:

```
== Finance Tracker ==
1. Add transaction
2. View balance
3. View all transactions
4. Filter by category
5. Filter by date
6. Save to file
0. Exit
```

* **Add transaction:** Input the amount, category, and type (Income or Expense). The transaction is auto-saved.
* **View balance:** Shows your current balance.
* **View all transactions:** Lists all transactions with date, type, category, and amount.
* **Filter by category:** Show only transactions of a specific category.
* **Filter by date:** Filter transactions between two dates.
* **Save to file:** Manually save all transactions to a file.
* **Exit:** Auto-saves and exits the app.

---

## File Structure

* `Program.cs` – Main application logic and menu system
* `Models/Transaction.cs` – Transaction model
* `Services/FinanceManager.cs` – Handles transactions, balance, and filters
* `Helpers/FileManager.cs` – Handles saving/loading transactions from file
* `Helpers/Logger.cs` – Logs errors to `log.txt`

---

## Transaction Example

```csharp
var transaction = new Transaction
{
    Amount = 500m,
    Category = "Salary",
    Type = TransactionType.Income,
    Date = DateTime.Now
};
```

---

## Contributing

Feel free to fork this project, add features, or fix bugs. Pull requests are welcome!

---

## License

This project is open-source and available under the MIT License.
