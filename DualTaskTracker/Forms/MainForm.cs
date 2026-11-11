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
        }

        private void RenderTasks()
        {
            _isUpdatingUi = true;

            flpUser1Tasks.SuspendLayout();
            flpUser2Tasks.SuspendLayout();

            flpUser1Tasks.Controls.Clear();
            flpUser2Tasks.Controls.Clear();

            var user1Tasks = _dataManager.Data.Tasks
                .Where(t => t.Owner == TaskOwner.User1 || t.Owner == TaskOwner.Shared)
                .ToList();

            var user2Tasks = _dataManager.Data.Tasks
                .Where(t => t.Owner == TaskOwner.User2 || t.Owner == TaskOwner.Shared)
                .ToList();

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
            string displayTitle = task.Owner == TaskOwner.Shared
                ? $"[Спільне] {task.Title}"
                : task.Title;

            var cb = new CheckBox
            {
                Text = displayTitle,
                Checked = task.IsCompleted,
                Tag = task,
                AutoSize = true,
                MaximumSize = new Size(350, 0),
                Font = new Font("Segoe UI", 10.5F, task.IsCompleted ? FontStyle.Strikeout : FontStyle.Regular),
                ForeColor = task.IsCompleted
                    ? Color.Gray
                    : (task.Owner == TaskOwner.Shared ? Color.FromArgb(109, 40, 217) : Color.FromArgb(30, 41, 59)),
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
        }

        private void btnAddTask_Click(object? sender, EventArgs e)
        {
            using var addForm = new AddTaskForm(_dataManager.Data.User1Name, _dataManager.Data.User2Name);
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                _dataManager.AddTask(addForm.TaskTitle, addForm.SelectedOwner);
                RenderTasks();
            }
        }
    }
}
