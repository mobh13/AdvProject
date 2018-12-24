namespace Desktop
{
    partial class TaughtCourses
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditCourse = new System.Windows.Forms.Button();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnExit.ForeColor = System.Drawing.Color.LightCyan;
            this.btnExit.Location = new System.Drawing.Point(293, 138);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(212, 35);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 33);
            this.label1.TabIndex = 14;
            this.label1.Text = "Taught Course";
            // 
            // btnEditCourse
            // 
            this.btnEditCourse.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEditCourse.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnEditCourse.FlatAppearance.BorderSize = 0;
            this.btnEditCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCourse.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnEditCourse.ForeColor = System.Drawing.Color.LightCyan;
            this.btnEditCourse.Location = new System.Drawing.Point(293, 70);
            this.btnEditCourse.Name = "btnEditCourse";
            this.btnEditCourse.Size = new System.Drawing.Size(212, 35);
            this.btnEditCourse.TabIndex = 13;
            this.btnEditCourse.Text = "Edit Taught Course";
            this.btnEditCourse.UseVisualStyleBackColor = false;
            this.btnEditCourse.Click += new System.EventHandler(this.EditTaughtCourse_Click);
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddCourse.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddCourse.FlatAppearance.BorderSize = 0;
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnAddCourse.ForeColor = System.Drawing.Color.LightCyan;
            this.btnAddCourse.Location = new System.Drawing.Point(37, 70);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(212, 35);
            this.btnAddCourse.TabIndex = 12;
            this.btnAddCourse.Text = "Add Taught Course";
            this.btnAddCourse.UseVisualStyleBackColor = false;
            this.btnAddCourse.Click += new System.EventHandler(this.AddTaughtCourse_Click);
            // 
            // btnDeleteCourse
            // 
            this.btnDeleteCourse.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDeleteCourse.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnDeleteCourse.FlatAppearance.BorderSize = 0;
            this.btnDeleteCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCourse.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnDeleteCourse.ForeColor = System.Drawing.Color.LightCyan;
            this.btnDeleteCourse.Location = new System.Drawing.Point(37, 138);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(215, 35);
            this.btnDeleteCourse.TabIndex = 16;
            this.btnDeleteCourse.Text = "Delete Taught Course";
            this.btnDeleteCourse.UseVisualStyleBackColor = false;
            this.btnDeleteCourse.Click += new System.EventHandler(this.DeleteTaughtCourse_Click);
            // 
            // TaughtCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 200);
            this.Controls.Add(this.btnDeleteCourse);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditCourse);
            this.Controls.Add(this.btnAddCourse);
            this.Name = "TaughtCourses";
            this.Text = "TaughtCourses";
            this.Load += new System.EventHandler(this.TaughtCourses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditCourse;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
    }
}