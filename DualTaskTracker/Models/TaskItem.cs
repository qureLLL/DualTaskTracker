using System;

namespace DualTaskTracker.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public TaskOwner Owner { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.Normal;
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
    }
}
