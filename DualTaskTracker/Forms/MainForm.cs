using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DualTaskTracker.Models;
using DualTaskTracker.Services;

namespace DualTaskTracker.Forms
{
    public partial class MainForm : Form
    {
        private readonly DataManager _dataManager;
        private bool _isUpdatingUi = false;

        public MainForm()
        {
            InitializeComponent();
            _dataManager = new DataManager();

            InitializeCustomUi();
            RenderTasks();
        }

        private void InitializeCustomUi()
        {
            lblCurrentDate.Text = $"Поточна дата: {DateTime.Today:dd.MM.yyyy}";
            grpUser1.Text = $"👤 {_dataManager.Data.User1Name}";
            grpUser2.Text = $"👤 {_dataManager.Data.User2Name}";
            cmbTaskFilter.SelectedIndex = 0;
        }

        private TaskFilterState GetCurrentFilter()
        {
            if (cmbTaskFilter == null) return TaskFilterState.All;
            return cmbTaskFilter.SelectedIndex switch
            {
                1 => TaskFilterState.ActiveOnly,
                2 => TaskFilterState.CompletedOnly,
                _ => TaskFilterState.All
            };
        }

        private void cmbTaskFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingUi) return;
            RenderTasks();
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingUi) return;
            RenderTasks();
        }

        private void RenderTasks()
        {
            _isUpdatingUi = true;

            flpUser1Tasks.SuspendLayout();
            flpUser2Tasks.SuspendLayout();

            flpUser1Tasks.Controls.Clear();
            flpUser2Tasks.Controls.Clear();

            var filter = GetCurrentFilter();
            string query = txtSearch?.Text ?? string.Empty;
            var user1Tasks = _dataManager.SearchTasks(query, TaskOwner.User1, filter).ToList();
            var user2Tasks = _dataManager.SearchTasks(query, TaskOwner.User2, filter).ToList();

            foreach (var task in user1Tasks)
            {
                flpUser1Tasks.Controls.Add(CreateTaskCheckBox(task));
            }

            foreach (var task in user2Tasks)
            {
                flpUser2Tasks.Controls.Add(CreateTaskCheckBox(task));
            }

            flpUser1Tasks.ResumeLayout();
            flpUser2Tasks.ResumeLayout();

            UpdateProgressBars(user1Tasks, user2Tasks);

            _isUpdatingUi = false;
        }

        private CheckBox CreateTaskCheckBox(TaskItem task)
        {
            string priorityPrefix = task.Priority switch
            {
                TaskPriority.High => "[🔥 Високий] ",
                TaskPriority.Low => "[💤 Низький] ",
                _ => ""
            };

            string displayTitle = task.Owner == TaskOwner.Shared
                ? $"[Спільне] {priorityPrefix}{task.Title}"
                : $"{priorityPrefix}{task.Title}";

            Color taskColor;
            if (task.IsCompleted)
            {
                taskColor = Color.Gray;
            }
            else if (task.Priority == TaskPriority.High)
            {
                taskColor = Color.FromArgb(185, 28, 28);
            }
            else if (task.Owner == TaskOwner.Shared)
            {
                taskColor = Color.FromArgb(109, 40, 217);
            }
            else
            {
                taskColor = Color.FromArgb(30, 41, 59);
            }

            var cb = new CheckBox
            {
                Text = displayTitle,
                Checked = task.IsCompleted,
                Tag = task,
                AutoSize = true,
                MaximumSize = new Size(350, 0),
                Font = new Font("Segoe UI", 10.5F, task.IsCompleted ? FontStyle.Strikeout : FontStyle.Regular),
                ForeColor = taskColor,
                Margin = new Padding(4, 6, 4, 6),
                Cursor = Cursors.Hand
            };

            var contextMenu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("Видалити завдання");
            deleteItem.Click += (s, e) =>
            {
                _dataManager.RemoveTask(task.Id);
                RenderTasks();
            };
            contextMenu.Items.Add(deleteItem);
            cb.ContextMenuStrip = contextMenu;

            cb.CheckedChanged += TaskCheckBox_CheckedChanged;
            return cb;
        }

        private void TaskCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingUi) return;

            if (sender is CheckBox cb && cb.Tag is TaskItem task)
            {
                task.IsCompleted = cb.Checked;
                _dataManager.SaveData();
                RenderTasks();
            }
        }

        private void UpdateProgressBars(List<TaskItem> user1Tasks, List<TaskItem> user2Tasks)
        {
            int done1 = user1Tasks.Count(t => t.IsCompleted);
            int total1 = user1Tasks.Count;
            int percent1 = total1 > 0 ? (int)Math.Round((double)done1 / total1 * 100) : 0;

            pbUser1.Value = percent1;
            lblUser1Progress.Text = $"{_dataManager.Data.User1Name}: {percent1}% ({done1} з {total1} виконано)";

            int done2 = user2Tasks.Count(t => t.IsCompleted);
            int total2 = user2Tasks.Count;
            int percent2 = total2 > 0 ? (int)Math.Round((double)done2 / total2 * 100) : 0;

            pbUser2.Value = percent2;
            lblUser2Progress.Text = $"{_dataManager.Data.User2Name}: {percent2}% ({done2} з {total2} виконано)";

            var stats = _dataManager.GetStatistics();
            lblOverallStats.Text = $"📊 Загальний прогрес команди: {stats.CompletedTasks} з {stats.TotalTasks} ({stats.OverallPercent}%) | Спільних завдань: {stats.SharedCompleted}/{stats.SharedTotal}";
        }

        private void btnAddTask_Click(object? sender, EventArgs e)
        {
            using var addForm = new AddTaskForm(_dataManager.Data.User1Name, _dataManager.Data.User2Name);
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                _dataManager.AddTask(addForm.TaskTitle, addForm.SelectedOwner, addForm.SelectedPriority);
                RenderTasks();
            }
        }

        private void btnClearCompleted_Click(object? sender, EventArgs e)
        {
            var completedCount = _dataManager.Data.Tasks.Count(t => t.IsCompleted);
            if (completedCount == 0)
            {
                MessageBox.Show("Немає виконаних завдань для очищення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Видалити всі виконані завдання ({completedCount} шт.)?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _dataManager.ClearCompletedTasks();
                RenderTasks();
            }
        }

        private void btnExportReport_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Зберегти звіт завдань",
                Filter = "Текстовий файл (*.txt)|*.txt|Markdown документ (*.md)|*.md",
                FileName = $"DualTaskReport_{DateTime.Today:yyyyMMdd}.txt"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string report = _dataManager.ExportTasksToReport();
                    File.WriteAllText(sfd.FileName, report);
                    MessageBox.Show("Звіт успішно збережено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні звіту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
