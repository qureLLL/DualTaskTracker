using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using DualTaskTracker.Models;

namespace DualTaskTracker.Services
{
    public class DataManager
    {
        private readonly string _filePath = "data.json";
        public AppData Data { get; private set; } = new AppData();

        public DataManager()
        {
            LoadData();
            CheckAndResetForNewDay();
        }

        public void LoadData()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    string json = File.ReadAllText(_filePath);
                    Data = JsonSerializer.Deserialize<AppData>(json) ?? new AppData();
                }
                catch
                {
                    Data = new AppData();
                }
            }
            else
            {
                Data = new AppData();
                SeedInitialData();
                SaveData();
            }
        }

        public void SaveData()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string json = JsonSerializer.Serialize(Data, options);
            File.WriteAllText(_filePath, json);
        }

        private void CheckAndResetForNewDay()
        {
            if (Data.LastOpenedDate.Date < DateTime.Today)
            {
                foreach (var task in Data.Tasks)
                {
                    task.IsCompleted = false;
                    task.Date = DateTime.Today;
                }
                Data.LastOpenedDate = DateTime.Today;
                SaveData();
            }
        }

        public void AddTask(string title, TaskOwner owner)
        {
            Data.Tasks.Add(new TaskItem
            {
                Title = title,
                Owner = owner,
                IsCompleted = false,
                Date = DateTime.Today
            });

            SaveData();
        }

        public void RemoveTask(Guid id)
        {
            Data.Tasks.RemoveAll(t => t.Id == id);
            SaveData();
        }

        private void SeedInitialData()
        {
            Data.Tasks.Add(new TaskItem { Title = "Ранкова зарядка 15 хв", Owner = TaskOwner.User1 });
            Data.Tasks.Add(new TaskItem { Title = "Закрити задачі по спринту", Owner = TaskOwner.User1 });
            Data.Tasks.Add(new TaskItem { Title = "Прочитати 20 сторінок книги", Owner = TaskOwner.User2 });
            Data.Tasks.Add(new TaskItem { Title = "Практика англійської мови", Owner = TaskOwner.User2 });
            Data.Tasks.Add(new TaskItem { Title = "Прибрати на кухні", Owner = TaskOwner.Shared });
            Data.Tasks.Add(new TaskItem { Title = "Вечірня прогулянка", Owner = TaskOwner.Shared });
        }
    }
}
