namespace Desktop
{
    partial class Reports
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
            this.averageGradesBtn = new System.Windows.Forms.Button();
            this.totalScheduledHoursBtn = new System.Windows.Forms.Button();
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
            this.buttonExit.Location = new System.Drawing.Point(167, 123);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(217, 35);
            this.buttonExit.TabIndex = 28;
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
            this.label1.Size = new System.Drawing.Size(122, 33);
            this.label1.TabIndex = 27;
            this.label1.Text = "Reports";
            // 
            // averageGradesBtn
            // 
            this.averageGradesBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.averageGradesBtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.averageGradesBtn.FlatAppearance.BorderSize = 0;
            this.averageGradesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.averageGradesBtn.Font = new System.Drawing.Font("Tahoma", 15F);
            this.averageGradesBtn.ForeColor = System.Drawing.Color.LightCyan;
            this.averageGradesBtn.Location = new System.Drawing.Point(287, 63);
            this.averageGradesBtn.Name = "averageGradesBtn";
            this.averageGradesBtn.Size = new System.Drawing.Size(243, 35);
            this.averageGradesBtn.TabIndex = 26;
            this.averageGradesBtn.Text = "Average Grades";
            this.averageGradesBtn.UseVisualStyleBackColor = false;
            this.averageGradesBtn.Click += new System.EventHandler(this.AverageGradesBtn_Click);
            // 
            // totalScheduledHoursBtn
            // 
            this.totalScheduledHoursBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.totalScheduledHoursBtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.totalScheduledHoursBtn.FlatAppearance.BorderSize = 0;
            this.totalScheduledHoursBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalScheduledHoursBtn.Font = new System.Drawing.Font("Tahoma", 15F);
            this.totalScheduledHoursBtn.ForeColor = System.Drawing.Color.LightCyan;
            this.totalScheduledHoursBtn.Location = new System.Drawing.Point(17, 63);
            this.totalScheduledHoursBtn.Name = "totalScheduledHoursBtn";
            this.totalScheduledHoursBtn.Size = new System.Drawing.Size(243, 35);
            this.totalScheduledHoursBtn.TabIndex = 25;
            this.totalScheduledHoursBtn.Text = "Total Scheduled Hours";
            this.totalScheduledHoursBtn.UseVisualStyleBackColor = false;
            this.totalScheduledHoursBtn.Click += new System.EventHandler(this.TotalScheduledHoursBtn_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 177);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.averageGradesBtn);
            this.Controls.Add(this.totalScheduledHoursBtn);
            this.Name = "Reports";
            this.Text = "Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button averageGradesBtn;
        private System.Windows.Forms.Button totalScheduledHoursBtn;
    }
}