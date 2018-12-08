namespace Desktop
{
    partial class DeleteInstructor
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
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.labelID = new System.Windows.Forms.Label();
            this.labelDeleteInstructor = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
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
            this.buttonExit.Location = new System.Drawing.Point(291, 174);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(212, 35);
            this.buttonExit.TabIndex = 128;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBoxID
            // 
            this.comboBoxID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(243, 101);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(237, 26);
            this.comboBoxID.TabIndex = 127;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Teal;
            this.labelID.Location = new System.Drawing.Point(85, 96);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(159, 25);
            this.labelID.TabIndex = 126;
            this.labelID.Text = "Instructor ID:";
            // 
            // labelDeleteInstructor
            // 
            this.labelDeleteInstructor.AutoSize = true;
            this.labelDeleteInstructor.BackColor = System.Drawing.Color.Transparent;
            this.labelDeleteInstructor.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelDeleteInstructor.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDeleteInstructor.Location = new System.Drawing.Point(12, 9);
            this.labelDeleteInstructor.Name = "labelDeleteInstructor";
            this.labelDeleteInstructor.Size = new System.Drawing.Size(248, 33);
            this.labelDeleteInstructor.TabIndex = 125;
            this.labelDeleteInstructor.Text = "Delete Instructor";
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonDelete.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonDelete.Location = new System.Drawing.Point(74, 175);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(212, 35);
            this.buttonDelete.TabIndex = 129;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // DeleteInstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 242);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.comboBoxID);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelDeleteInstructor);
            this.Name = "DeleteInstructor";
            this.Text = "Delete Instructor";
            this.Load += new System.EventHandler(this.DeleteInstructor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelDeleteInstructor;
        private System.Windows.Forms.Button buttonDelete;
    }
}