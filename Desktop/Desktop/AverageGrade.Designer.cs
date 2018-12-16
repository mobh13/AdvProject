namespace Desktop
{
    partial class AverageGrade
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
            this.txtAvgGrade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbListFor = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbListBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAvgGrade
            // 
            this.txtAvgGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgGrade.Location = new System.Drawing.Point(294, 254);
            this.txtAvgGrade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAvgGrade.Name = "txtAvgGrade";
            this.txtAvgGrade.Size = new System.Drawing.Size(354, 33);
            this.txtAvgGrade.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(19, 244);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 39);
            this.label3.TabIndex = 102;
            this.label3.Text = "Average Grade:";
            // 
            // cmbListFor
            // 
            this.cmbListFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListFor.FormattingEnabled = true;
            this.cmbListFor.Location = new System.Drawing.Point(296, 189);
            this.cmbListFor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbListFor.Name = "cmbListFor";
            this.cmbListFor.Size = new System.Drawing.Size(354, 37);
            this.cmbListFor.TabIndex = 101;
            this.cmbListFor.SelectedIndexChanged += new System.EventHandler(this.cmbListFor_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnExit.ForeColor = System.Drawing.Color.LightCyan;
            this.btnExit.Location = new System.Drawing.Point(220, 340);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(264, 54);
            this.btnExit.TabIndex = 100;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(19, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 39);
            this.label2.TabIndex = 98;
            this.label2.Text = "For:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 48);
            this.label1.TabIndex = 97;
            this.label1.Text = "Average grade for the college";
            // 
            // cmbListBy
            // 
            this.cmbListBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListBy.FormattingEnabled = true;
            this.cmbListBy.Location = new System.Drawing.Point(296, 119);
            this.cmbListBy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbListBy.Name = "cmbListBy";
            this.cmbListBy.Size = new System.Drawing.Size(354, 37);
            this.cmbListBy.TabIndex = 105;
            this.cmbListBy.SelectedIndexChanged += new System.EventHandler(this.cmbListBy_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(19, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 39);
            this.label4.TabIndex = 104;
            this.label4.Text = "By:";
            // 
            // AverageGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 426);
            this.Controls.Add(this.cmbListBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAvgGrade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbListFor);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AverageGrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AverageGrade";
            this.Load += new System.EventHandler(this.AverageGrade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAvgGrade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbListFor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbListBy;
        private System.Windows.Forms.Label label4;
    }
}