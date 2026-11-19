using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (string.IsNullOrWhiteSpace(title))
                return;

            Data.Tasks.Add(new TaskItem
            {
                Title = title.Trim(),
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

        public void ClearCompletedTasks()
        {
            Data.Tasks.RemoveAll(t => t.IsCompleted);
            SaveData();
        }

        public IEnumerable<TaskItem> GetFilteredTasks(TaskOwner owner, TaskFilterState filter)
        {
            var query = Data.Tasks.Where(t => t.Owner == owner || t.Owner == TaskOwner.Shared);
            return filter switch
            {
                TaskFilterState.ActiveOnly => query.Where(t => !t.IsCompleted),
                TaskFilterState.CompletedOnly => query.Where(t => t.IsCompleted),
                _ => query
            };
        }

        public TaskStatistics GetStatistics()
        {
            var stats = new TaskStatistics
            {
                TotalTasks = Data.Tasks.Count,
                CompletedTasks = Data.Tasks.Count(t => t.IsCompleted),
                User1Total = Data.Tasks.Count(t => t.Owner == TaskOwner.User1),
                User1Completed = Data.Tasks.Count(t => t.Owner == TaskOwner.User1 && t.IsCompleted),
                User2Total = Data.Tasks.Count(t => t.Owner == TaskOwner.User2),
                User2Completed = Data.Tasks.Count(t => t.Owner == TaskOwner.User2 && t.IsCompleted),
                SharedTotal = Data.Tasks.Count(t => t.Owner == TaskOwner.Shared),
                SharedCompleted = Data.Tasks.Count(t => t.Owner == TaskOwner.Shared && t.IsCompleted)
            };
            return stats;
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
