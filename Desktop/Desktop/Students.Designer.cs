namespace Desktop
{
    partial class Students
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
            this.labelStudent = new System.Windows.Forms.Label();
            this.buttonEditStudent = new System.Windows.Forms.Button();
            this.buttonAddStudent = new System.Windows.Forms.Button();
            this.buttonDeleteStudent = new System.Windows.Forms.Button();
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
            this.buttonExit.Location = new System.Drawing.Point(241, 168);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(176, 35);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelStudent
            // 
            this.labelStudent.AutoSize = true;
            this.labelStudent.BackColor = System.Drawing.Color.Transparent;
            this.labelStudent.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelStudent.ForeColor = System.Drawing.Color.DarkRed;
            this.labelStudent.Location = new System.Drawing.Point(12, 27);
            this.labelStudent.Name = "labelStudent";
            this.labelStudent.Size = new System.Drawing.Size(121, 33);
            this.labelStudent.TabIndex = 18;
            this.labelStudent.Text = "Student";
            // 
            // buttonEditStudent
            // 
            this.buttonEditStudent.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditStudent.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditStudent.FlatAppearance.BorderSize = 0;
            this.buttonEditStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditStudent.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonEditStudent.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonEditStudent.Location = new System.Drawing.Point(241, 87);
            this.buttonEditStudent.Name = "buttonEditStudent";
            this.buttonEditStudent.Size = new System.Drawing.Size(176, 35);
            this.buttonEditStudent.TabIndex = 17;
            this.buttonEditStudent.Text = "Edit Student";
            this.buttonEditStudent.UseVisualStyleBackColor = false;
            this.buttonEditStudent.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAddStudent
            // 
            this.buttonAddStudent.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddStudent.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddStudent.FlatAppearance.BorderSize = 0;
            this.buttonAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddStudent.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonAddStudent.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonAddStudent.Location = new System.Drawing.Point(17, 87);
            this.buttonAddStudent.Name = "buttonAddStudent";
            this.buttonAddStudent.Size = new System.Drawing.Size(176, 35);
            this.buttonAddStudent.TabIndex = 16;
            this.buttonAddStudent.Text = "Add Student";
            this.buttonAddStudent.UseVisualStyleBackColor = false;
            this.buttonAddStudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDeleteStudent
            // 
            this.buttonDeleteStudent.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDeleteStudent.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDeleteStudent.FlatAppearance.BorderSize = 0;
            this.buttonDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteStudent.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonDeleteStudent.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonDeleteStudent.Location = new System.Drawing.Point(17, 168);
            this.buttonDeleteStudent.Name = "buttonDeleteStudent";
            this.buttonDeleteStudent.Size = new System.Drawing.Size(176, 35);
            this.buttonDeleteStudent.TabIndex = 20;
            this.buttonDeleteStudent.Text = "Delete Student";
            this.buttonDeleteStudent.UseVisualStyleBackColor = false;
            this.buttonDeleteStudent.Click += new System.EventHandler(this.button4_Click);
            // 
            // Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 255);
            this.Controls.Add(this.buttonDeleteStudent);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelStudent);
            this.Controls.Add(this.buttonEditStudent);
            this.Controls.Add(this.buttonAddStudent);
            this.Name = "Students";
            this.Text = "Students";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelStudent;
        private System.Windows.Forms.Button buttonEditStudent;
        private System.Windows.Forms.Button buttonAddStudent;
        private System.Windows.Forms.Button buttonDeleteStudent;
    }
}