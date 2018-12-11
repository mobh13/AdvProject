namespace Desktop
{
    partial class Instructors
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
            this.buttonAddInstructor = new System.Windows.Forms.Button();
            this.buttonEditInstructor = new System.Windows.Forms.Button();
            this.labelInstructor = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDeleteInstructor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddInstructor
            // 
            this.buttonAddInstructor.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddInstructor.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddInstructor.FlatAppearance.BorderSize = 0;
            this.buttonAddInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddInstructor.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonAddInstructor.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonAddInstructor.Location = new System.Drawing.Point(17, 87);
            this.buttonAddInstructor.Name = "buttonAddInstructor";
            this.buttonAddInstructor.Size = new System.Drawing.Size(176, 35);
            this.buttonAddInstructor.TabIndex = 4;
            this.buttonAddInstructor.Text = "Add Instructor";
            this.buttonAddInstructor.UseVisualStyleBackColor = false;
            this.buttonAddInstructor.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonEditInstructor
            // 
            this.buttonEditInstructor.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditInstructor.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditInstructor.FlatAppearance.BorderSize = 0;
            this.buttonEditInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditInstructor.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonEditInstructor.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonEditInstructor.Location = new System.Drawing.Point(241, 87);
            this.buttonEditInstructor.Name = "buttonEditInstructor";
            this.buttonEditInstructor.Size = new System.Drawing.Size(176, 35);
            this.buttonEditInstructor.TabIndex = 5;
            this.buttonEditInstructor.Text = "Edit Instructor";
            this.buttonEditInstructor.UseVisualStyleBackColor = false;
            this.buttonEditInstructor.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelInstructor
            // 
            this.labelInstructor.AutoSize = true;
            this.labelInstructor.BackColor = System.Drawing.Color.Transparent;
            this.labelInstructor.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelInstructor.ForeColor = System.Drawing.Color.DarkRed;
            this.labelInstructor.Location = new System.Drawing.Point(12, 27);
            this.labelInstructor.Name = "labelInstructor";
            this.labelInstructor.Size = new System.Drawing.Size(153, 33);
            this.labelInstructor.TabIndex = 6;
            this.labelInstructor.Text = "Instructor";
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
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonDeleteInstructor
            // 
            this.buttonDeleteInstructor.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDeleteInstructor.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDeleteInstructor.FlatAppearance.BorderSize = 0;
            this.buttonDeleteInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteInstructor.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonDeleteInstructor.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonDeleteInstructor.Location = new System.Drawing.Point(17, 168);
            this.buttonDeleteInstructor.Name = "buttonDeleteInstructor";
            this.buttonDeleteInstructor.Size = new System.Drawing.Size(176, 35);
            this.buttonDeleteInstructor.TabIndex = 8;
            this.buttonDeleteInstructor.Text = "Delete Instructor";
            this.buttonDeleteInstructor.UseVisualStyleBackColor = false;
            this.buttonDeleteInstructor.Click += new System.EventHandler(this.button4_Click);
            // 
            // Instructors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 255);
            this.Controls.Add(this.buttonDeleteInstructor);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelInstructor);
            this.Controls.Add(this.buttonEditInstructor);
            this.Controls.Add(this.buttonAddInstructor);
            this.Name = "Instructors";
            this.Text = "Instructors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddInstructor;
        private System.Windows.Forms.Button buttonEditInstructor;
        private System.Windows.Forms.Label labelInstructor;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonDeleteInstructor;
    }
}