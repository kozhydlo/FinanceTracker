using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FinanceTracker.Models;

namespace FinanceTracker.Helpers
{
    public static class FileManager
    {
        private static readonly string _filePath = "transactions.json";

        public static void SaveToFile(List<Transaction> transactions)
        {
            var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public static List<Transaction> LoadFromFile()
        {
            if (!File.Exists(_filePath)) return new List<Transaction>();

            try
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return new List<Transaction>();
            }
        }
    }
}
