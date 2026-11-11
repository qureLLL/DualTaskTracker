namespace DualTaskTracker.Forms
{
    partial class AddTaskForm
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
            this.lblTitlePrompt = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblOwnerPrompt = new System.Windows.Forms.Label();
            this.cmbOwner = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitlePrompt.AutoSize = true;
            this.lblTitlePrompt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitlePrompt.Location = new System.Drawing.Point(20, 20);
            this.lblTitlePrompt.Name = "lblTitlePrompt";
            this.lblTitlePrompt.Size = new System.Drawing.Size(130, 19);
            this.lblTitlePrompt.TabIndex = 0;
            this.lblTitlePrompt.Text = "Назва завдання:";

            this.txtTaskTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTaskTitle.Location = new System.Drawing.Point(20, 45);
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.Size = new System.Drawing.Size(360, 26);
            this.txtTaskTitle.TabIndex = 1;

            this.lblOwnerPrompt.AutoSize = true;
            this.lblOwnerPrompt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOwnerPrompt.Location = new System.Drawing.Point(20, 90);
            this.lblOwnerPrompt.Name = "lblOwnerPrompt";
            this.lblOwnerPrompt.Size = new System.Drawing.Size(160, 19);
            this.lblOwnerPrompt.TabIndex = 2;
            this.lblOwnerPrompt.Text = "Чиє це завдання?";

            this.cmbOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOwner.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbOwner.FormattingEnabled = true;
            this.cmbOwner.Location = new System.Drawing.Point(20, 115);
            this.cmbOwner.Name = "cmbOwner";
            this.cmbOwner.Size = new System.Drawing.Size(360, 27);
            this.cmbOwner.TabIndex = 3;

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(195, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(185, 38);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(20, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 38);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;

            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbOwner);
            this.Controls.Add(this.lblOwnerPrompt);
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.lblTitlePrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Додати нове завдання";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitlePrompt;
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.Label lblOwnerPrompt;
        private System.Windows.Forms.ComboBox cmbOwner;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
