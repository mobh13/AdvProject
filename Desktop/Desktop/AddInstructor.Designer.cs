namespace Desktop
{
    partial class AddInstructor
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
            this.labelAddInstructor = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelFName = new System.Windows.Forms.Label();
            this.labelLName = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxFname = new System.Windows.Forms.TextBox();
            this.textBoxlName = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxHdate = new System.Windows.Forms.TextBox();
            this.textBoxPasswd = new System.Windows.Forms.TextBox();
            this.labelHDate = new System.Windows.Forms.Label();
            this.labelPasswd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAddInstructor
            // 
            this.labelAddInstructor.AutoSize = true;
            this.labelAddInstructor.BackColor = System.Drawing.Color.Transparent;
            this.labelAddInstructor.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelAddInstructor.ForeColor = System.Drawing.Color.DarkRed;
            this.labelAddInstructor.Location = new System.Drawing.Point(12, 9);
            this.labelAddInstructor.Name = "labelAddInstructor";
            this.labelAddInstructor.Size = new System.Drawing.Size(213, 33);
            this.labelAddInstructor.TabIndex = 7;
            this.labelAddInstructor.Text = "Add Instructor";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Teal;
            this.labelID.Location = new System.Drawing.Point(12, 55);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(159, 25);
            this.labelID.TabIndex = 8;
            this.labelID.Text = "Instructor ID:";
            // 
            // labelFName
            // 
            this.labelFName.AutoSize = true;
            this.labelFName.BackColor = System.Drawing.Color.Transparent;
            this.labelFName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFName.ForeColor = System.Drawing.Color.Teal;
            this.labelFName.Location = new System.Drawing.Point(13, 93);
            this.labelFName.Name = "labelFName";
            this.labelFName.Size = new System.Drawing.Size(134, 25);
            this.labelFName.TabIndex = 9;
            this.labelFName.Text = "First Name:";
            // 
            // labelLName
            // 
            this.labelLName.AutoSize = true;
            this.labelLName.BackColor = System.Drawing.Color.Transparent;
            this.labelLName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLName.ForeColor = System.Drawing.Color.Teal;
            this.labelLName.Location = new System.Drawing.Point(12, 129);
            this.labelLName.Name = "labelLName";
            this.labelLName.Size = new System.Drawing.Size(132, 25);
            this.labelLName.TabIndex = 10;
            this.labelLName.Text = "Last Name:";
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(177, 55);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(237, 24);
            this.textBoxID.TabIndex = 13;
            // 
            // textBoxFname
            // 
            this.textBoxFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFname.Location = new System.Drawing.Point(177, 93);
            this.textBoxFname.Name = "textBoxFname";
            this.textBoxFname.Size = new System.Drawing.Size(237, 24);
            this.textBoxFname.TabIndex = 14;
            // 
            // textBoxlName
            // 
            this.textBoxlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxlName.Location = new System.Drawing.Point(177, 130);
            this.textBoxlName.Name = "textBoxlName";
            this.textBoxlName.Size = new System.Drawing.Size(237, 24);
            this.textBoxlName.TabIndex = 15;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonSubmit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonSubmit.FlatAppearance.BorderSize = 0;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonSubmit.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonSubmit.Location = new System.Drawing.Point(438, 55);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(176, 36);
            this.buttonSubmit.TabIndex = 18;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonClear.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonClear.Location = new System.Drawing.Point(438, 108);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(176, 35);
            this.buttonClear.TabIndex = 19;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonExit.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonExit.Location = new System.Drawing.Point(438, 159);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(176, 35);
            this.buttonExit.TabIndex = 20;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxHdate
            // 
            this.textBoxHdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHdate.Location = new System.Drawing.Point(177, 169);
            this.textBoxHdate.Name = "textBoxHdate";
            this.textBoxHdate.Size = new System.Drawing.Size(237, 24);
            this.textBoxHdate.TabIndex = 16;
            // 
            // textBoxPasswd
            // 
            this.textBoxPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswd.Location = new System.Drawing.Point(177, 208);
            this.textBoxPasswd.Name = "textBoxPasswd";
            this.textBoxPasswd.Size = new System.Drawing.Size(237, 24);
            this.textBoxPasswd.TabIndex = 17;
            // 
            // labelHDate
            // 
            this.labelHDate.AutoSize = true;
            this.labelHDate.BackColor = System.Drawing.Color.Transparent;
            this.labelHDate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHDate.ForeColor = System.Drawing.Color.Teal;
            this.labelHDate.Location = new System.Drawing.Point(13, 169);
            this.labelHDate.Name = "labelHDate";
            this.labelHDate.Size = new System.Drawing.Size(119, 25);
            this.labelHDate.TabIndex = 11;
            this.labelHDate.Text = "Hire Date:";
            // 
            // labelPasswd
            // 
            this.labelPasswd.AutoSize = true;
            this.labelPasswd.BackColor = System.Drawing.Color.Transparent;
            this.labelPasswd.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswd.ForeColor = System.Drawing.Color.Teal;
            this.labelPasswd.Location = new System.Drawing.Point(13, 208);
            this.labelPasswd.Name = "labelPasswd";
            this.labelPasswd.Size = new System.Drawing.Size(123, 25);
            this.labelPasswd.TabIndex = 12;
            this.labelPasswd.Text = "Password:";
            // 
            // AddInstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 243);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxPasswd);
            this.Controls.Add(this.textBoxHdate);
            this.Controls.Add(this.textBoxlName);
            this.Controls.Add(this.textBoxFname);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelPasswd);
            this.Controls.Add(this.labelHDate);
            this.Controls.Add(this.labelLName);
            this.Controls.Add(this.labelFName);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelAddInstructor);
            this.Name = "AddInstructor";
            this.Text = "Add Instructor";
            this.Load += new System.EventHandler(this.AddInstructor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddInstructor;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelFName;
        private System.Windows.Forms.Label labelLName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxFname;
        private System.Windows.Forms.TextBox textBoxlName;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxHdate;
        private System.Windows.Forms.TextBox textBoxPasswd;
        private System.Windows.Forms.Label labelHDate;
        private System.Windows.Forms.Label labelPasswd;
    }
}