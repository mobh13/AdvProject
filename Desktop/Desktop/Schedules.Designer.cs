namespace Desktop
{
    partial class Schedules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEditSchedule = new System.Windows.Forms.Button();
            this.buttonAddSchedule = new System.Windows.Forms.Button();
            this.buttonDeleteSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonExit.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonExit.Location = new System.Drawing.Point(259, 143);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(176, 35);
            this.buttonExit.TabIndex = 23;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 33);
            this.label1.TabIndex = 22;
            this.label1.Text = "Schedule";
            // 
            // buttonEditSchedule
            // 
            this.buttonEditSchedule.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditSchedule.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditSchedule.FlatAppearance.BorderSize = 0;
            this.buttonEditSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditSchedule.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonEditSchedule.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonEditSchedule.Location = new System.Drawing.Point(259, 71);
            this.buttonEditSchedule.Name = "buttonEditSchedule";
            this.buttonEditSchedule.Size = new System.Drawing.Size(176, 35);
            this.buttonEditSchedule.TabIndex = 21;
            this.buttonEditSchedule.Text = "Edit Schedule";
            this.buttonEditSchedule.UseVisualStyleBackColor = false;
            this.buttonEditSchedule.Click += new System.EventHandler(this.ButtonEditSchedule_Click);
            // 
            // buttonAddSchedule
            // 
            this.buttonAddSchedule.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddSchedule.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddSchedule.FlatAppearance.BorderSize = 0;
            this.buttonAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSchedule.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonAddSchedule.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonAddSchedule.Location = new System.Drawing.Point(43, 71);
            this.buttonAddSchedule.Name = "buttonAddSchedule";
            this.buttonAddSchedule.Size = new System.Drawing.Size(176, 35);
            this.buttonAddSchedule.TabIndex = 20;
            this.buttonAddSchedule.Text = "Add Schedule";
            this.buttonAddSchedule.UseVisualStyleBackColor = false;
            this.buttonAddSchedule.Click += new System.EventHandler(this.ButtonAddSchedule_Click);
            // 
            // buttonDeleteSchedule
            // 
            this.buttonDeleteSchedule.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDeleteSchedule.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDeleteSchedule.FlatAppearance.BorderSize = 0;
            this.buttonDeleteSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteSchedule.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonDeleteSchedule.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonDeleteSchedule.Location = new System.Drawing.Point(43, 143);
            this.buttonDeleteSchedule.Name = "buttonDeleteSchedule";
            this.buttonDeleteSchedule.Size = new System.Drawing.Size(176, 35);
            this.buttonDeleteSchedule.TabIndex = 24;
            this.buttonDeleteSchedule.Text = "Delete Schedule";
            this.buttonDeleteSchedule.UseVisualStyleBackColor = false;
            this.buttonDeleteSchedule.Click += new System.EventHandler(this.ButtonDeleteSchedule_Click);
            // 
            // Schedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 210);
            this.Controls.Add(this.buttonDeleteSchedule);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditSchedule);
            this.Controls.Add(this.buttonAddSchedule);
            this.Name = "Schedules";
            this.Text = "Schedules";
            this.Load += new System.EventHandler(this.Schedules_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditSchedule;
        private System.Windows.Forms.Button buttonAddSchedule;
        private System.Windows.Forms.Button buttonDeleteSchedule;
    }
}