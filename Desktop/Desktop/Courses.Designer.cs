namespace Desktop
{
    partial class Courses
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
            this.labelCourse = new System.Windows.Forms.Label();
            this.buttonEditCourse = new System.Windows.Forms.Button();
            this.buttonAddCourse = new System.Windows.Forms.Button();
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
            this.buttonExit.Location = new System.Drawing.Point(229, 199);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(264, 54);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.BackColor = System.Drawing.Color.Transparent;
            this.labelCourse.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelCourse.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCourse.Location = new System.Drawing.Point(15, 35);
            this.labelCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(160, 48);
            this.labelCourse.TabIndex = 10;
            this.labelCourse.Text = "Course";
            // 
            // buttonEditCourse
            // 
            this.buttonEditCourse.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditCourse.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditCourse.FlatAppearance.BorderSize = 0;
            this.buttonEditCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditCourse.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonEditCourse.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonEditCourse.Location = new System.Drawing.Point(417, 111);
            this.buttonEditCourse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEditCourse.Name = "buttonEditCourse";
            this.buttonEditCourse.Size = new System.Drawing.Size(264, 54);
            this.buttonEditCourse.TabIndex = 9;
            this.buttonEditCourse.Text = "Edit Course";
            this.buttonEditCourse.UseVisualStyleBackColor = false;
            this.buttonEditCourse.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAddCourse
            // 
            this.buttonAddCourse.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddCourse.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddCourse.FlatAppearance.BorderSize = 0;
            this.buttonAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCourse.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonAddCourse.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonAddCourse.Location = new System.Drawing.Point(65, 111);
            this.buttonAddCourse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddCourse.Name = "buttonAddCourse";
            this.buttonAddCourse.Size = new System.Drawing.Size(264, 54);
            this.buttonAddCourse.TabIndex = 8;
            this.buttonAddCourse.Text = "Add Course";
            this.buttonAddCourse.UseVisualStyleBackColor = false;
            this.buttonAddCourse.Click += new System.EventHandler(this.button1_Click);
            // 
            // Courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 281);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelCourse);
            this.Controls.Add(this.buttonEditCourse);
            this.Controls.Add(this.buttonAddCourse);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Courses";
            this.Text = "Courses";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Button buttonEditCourse;
        private System.Windows.Forms.Button buttonAddCourse;
    }
}