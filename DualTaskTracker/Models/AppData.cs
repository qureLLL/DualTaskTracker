using System;
using System.Collections.Generic;

namespace DualTaskTracker.Models
{
    public class AppData
    {
        public string User1Name { get; set; } = "Олександр";
        public string User2Name { get; set; } = "Марія";
        public DateTime LastOpenedDate { get; set; } = DateTime.Today;
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
