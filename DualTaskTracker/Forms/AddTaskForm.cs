using System;
using System.Windows.Forms;
using DualTaskTracker.Models;

namespace DualTaskTracker.Forms
{
    public partial class AddTaskForm : Form
    {
        public string TaskTitle { get; private set; } = string.Empty;
        public TaskOwner SelectedOwner { get; private set; }

        public AddTaskForm(string user1Name, string user2Name)
        {
            InitializeComponent();

            cmbOwner.Items.Add(user1Name);
            cmbOwner.Items.Add(user2Name);
            cmbOwner.Items.Add("Обидва (Спільне)");
            cmbOwner.SelectedIndex = 0;
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show(
                    "Будь ласка, введіть назву завдання!",
                    "Помилка вводу",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTaskTitle.Focus();
                return;
            }

            TaskTitle = txtTaskTitle.Text.Trim();

            SelectedOwner = cmbOwner.SelectedIndex switch
            {
                0 => TaskOwner.User1,
                1 => TaskOwner.User2,
                _ => TaskOwner.Shared
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
