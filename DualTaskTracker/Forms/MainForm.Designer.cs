namespace DualTaskTracker.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.grpProgress = new System.Windows.Forms.GroupBox();
            this.lblUser1Progress = new System.Windows.Forms.Label();
            this.pbUser1 = new System.Windows.Forms.ProgressBar();
            this.lblUser2Progress = new System.Windows.Forms.Label();
            this.pbUser2 = new System.Windows.Forms.ProgressBar();
            this.grpUser1 = new System.Windows.Forms.GroupBox();
            this.flpUser1Tasks = new System.Windows.Forms.FlowLayoutPanel();
            this.grpUser2 = new System.Windows.Forms.GroupBox();
            this.flpUser2Tasks = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.grpProgress.SuspendLayout();
            this.grpUser1.SuspendLayout();
            this.grpUser2.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlHeader.Controls.Add(this.btnAddTask);
            this.pnlHeader.Controls.Add(this.lblCurrentDate);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(860, 75);
            this.pnlHeader.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Щоденний трекер завдань";

            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurrentDate.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblCurrentDate.Location = new System.Drawing.Point(22, 44);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(150, 19);
            this.lblCurrentDate.TabIndex = 1;
            this.lblCurrentDate.Text = "Дата: 01.01.2026";

            this.btnAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnAddTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.Location = new System.Drawing.Point(650, 18);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(190, 40);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "+ Додати завдання";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            this.grpProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProgress.BackColor = System.Drawing.Color.White;
            this.grpProgress.Controls.Add(this.lblUser1Progress);
            this.grpProgress.Controls.Add(this.pbUser1);
            this.grpProgress.Controls.Add(this.lblUser2Progress);
            this.grpProgress.Controls.Add(this.pbUser2);
            this.grpProgress.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpProgress.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpProgress.Location = new System.Drawing.Point(20, 90);
            this.grpProgress.Name = "grpProgress";
            this.grpProgress.Size = new System.Drawing.Size(820, 100);
            this.grpProgress.TabIndex = 1;
            this.grpProgress.TabStop = false;
            this.grpProgress.Text = "🏆 Прогрес дня (Змагання)";

            this.lblUser1Progress.AutoSize = true;
            this.lblUser1Progress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblUser1Progress.Location = new System.Drawing.Point(20, 30);
            this.lblUser1Progress.Name = "lblUser1Progress";
            this.lblUser1Progress.Size = new System.Drawing.Size(130, 19);
            this.lblUser1Progress.TabIndex = 0;
            this.lblUser1Progress.Text = "Олександр: 0%";

            this.pbUser1.Location = new System.Drawing.Point(20, 53);
            this.pbUser1.Name = "pbUser1";
            this.pbUser1.Size = new System.Drawing.Size(375, 26);
            this.pbUser1.TabIndex = 1;

            this.lblUser2Progress.AutoSize = true;
            this.lblUser2Progress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblUser2Progress.Location = new System.Drawing.Point(425, 30);
            this.lblUser2Progress.Name = "lblUser2Progress";
            this.lblUser2Progress.Size = new System.Drawing.Size(100, 19);
            this.lblUser2Progress.TabIndex = 2;
            this.lblUser2Progress.Text = "Марія: 0%";

            this.pbUser2.Location = new System.Drawing.Point(425, 53);
            this.pbUser2.Name = "pbUser2";
            this.pbUser2.Size = new System.Drawing.Size(375, 26);
            this.pbUser2.TabIndex = 3;

            this.grpUser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpUser1.BackColor = System.Drawing.Color.White;
            this.grpUser1.Controls.Add(this.flpUser1Tasks);
            this.grpUser1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpUser1.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.grpUser1.Location = new System.Drawing.Point(20, 205);
            this.grpUser1.Name = "grpUser1";
            this.grpUser1.Size = new System.Drawing.Size(400, 355);
            this.grpUser1.TabIndex = 2;
            this.grpUser1.TabStop = false;
            this.grpUser1.Text = "👤 Олександр";

            this.flpUser1Tasks.AutoScroll = true;
            this.flpUser1Tasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpUser1Tasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpUser1Tasks.Location = new System.Drawing.Point(3, 23);
            this.flpUser1Tasks.Name = "flpUser1Tasks";
            this.flpUser1Tasks.Padding = new System.Windows.Forms.Padding(10);
            this.flpUser1Tasks.Size = new System.Drawing.Size(394, 329);
            this.flpUser1Tasks.TabIndex = 0;
            this.flpUser1Tasks.WrapContents = false;

            this.grpUser2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUser2.BackColor = System.Drawing.Color.White;
            this.grpUser2.Controls.Add(this.flpUser2Tasks);
            this.grpUser2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpUser2.ForeColor = System.Drawing.Color.FromArgb(219, 39, 119);
            this.grpUser2.Location = new System.Drawing.Point(440, 205);
            this.grpUser2.Name = "grpUser2";
            this.grpUser2.Size = new System.Drawing.Size(400, 355);
            this.grpUser2.TabIndex = 3;
            this.grpUser2.TabStop = false;
            this.grpUser2.Text = "👤 Марія";

            this.flpUser2Tasks.AutoScroll = true;
            this.flpUser2Tasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpUser2Tasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpUser2Tasks.Location = new System.Drawing.Point(3, 23);
            this.flpUser2Tasks.Name = "flpUser2Tasks";
            this.flpUser2Tasks.Padding = new System.Windows.Forms.Padding(10);
            this.flpUser2Tasks.Size = new System.Drawing.Size(394, 329);
            this.flpUser2Tasks.TabIndex = 0;
            this.flpUser2Tasks.WrapContents = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(860, 580);
            this.Controls.Add(this.grpUser2);
            this.Controls.Add(this.grpUser1);
            this.Controls.Add(this.grpProgress);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DualTaskTracker — Трекер щоденних завдань для двох";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpProgress.ResumeLayout(false);
            this.grpProgress.PerformLayout();
            this.grpUser1.ResumeLayout(false);
            this.grpUser2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.Label lblUser1Progress;
        private System.Windows.Forms.ProgressBar pbUser1;
        private System.Windows.Forms.Label lblUser2Progress;
        private System.Windows.Forms.ProgressBar pbUser2;
        private System.Windows.Forms.GroupBox grpUser1;
        private System.Windows.Forms.FlowLayoutPanel flpUser1Tasks;
        private System.Windows.Forms.GroupBox grpUser2;
        private System.Windows.Forms.FlowLayoutPanel flpUser2Tasks;
    }
}
