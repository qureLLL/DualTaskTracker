using System;
using DualTaskTracker.Models;

namespace DualTaskTracker.Services
{
    public static class DataIntegrityTests
    {
        public static bool RunAllTests(DataManager dataManager)
        {
            bool t1 = TestAddTaskValidation(dataManager);
            bool t2 = TestPriorityAssignment(dataManager);
            bool t3 = TestStatisticsCalculation(dataManager);
            return t1 && t2 && t3;
        }

        private static bool TestAddTaskValidation(DataManager dm)
        {
            int before = dm.Data.Tasks.Count;
            dm.AddTask("   ", TaskOwner.User1);
            return dm.Data.Tasks.Count == before;
        }

        private static bool TestPriorityAssignment(DataManager dm)
        {
            string testTitle = $"Test_Priority_{Guid.NewGuid():N}";
            dm.AddTask(testTitle, TaskOwner.User1, TaskPriority.High);
            var task = dm.Data.Tasks.Find(t => t.Title == testTitle);
            bool passed = task != null && task.Priority == TaskPriority.High;
            if (task != null) dm.RemoveTask(task.Id);
            return passed;
        }

        private static bool TestStatisticsCalculation(DataManager dm)
        {
            var stats = dm.GetStatistics();
            return stats.TotalTasks >= 0 && stats.OverallPercent >= 0 && stats.OverallPercent <= 100;
        }
    }
}
