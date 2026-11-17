namespace DualTaskTracker.Models
{
    public class TaskStatistics
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int User1Total { get; set; }
        public int User1Completed { get; set; }
        public int User2Total { get; set; }
        public int User2Completed { get; set; }
        public int SharedTotal { get; set; }
        public int SharedCompleted { get; set; }
        public int OverallPercent => TotalTasks > 0 ? (int)System.Math.Round((double)CompletedTasks / TotalTasks * 100) : 0;
    }
}
