namespace Desktop
{
    partial class Locations
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
            this.buttonEditLocation = new System.Windows.Forms.Button();
            this.buttonAddLocation = new System.Windows.Forms.Button();
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
            this.buttonExit.Location = new System.Drawing.Point(149, 144);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(176, 35);
            this.buttonExit.TabIndex = 27;
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
            this.label1.Size = new System.Drawing.Size(130, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "Location";
            // 
            // buttonEditLocation
            // 
            this.buttonEditLocation.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditLocation.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonEditLocation.FlatAppearance.BorderSize = 0;
            this.buttonEditLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditLocation.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonEditLocation.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonEditLocation.Location = new System.Drawing.Point(255, 79);
            this.buttonEditLocation.Name = "buttonEditLocation";
            this.buttonEditLocation.Size = new System.Drawing.Size(176, 35);
            this.buttonEditLocation.TabIndex = 25;
            this.buttonEditLocation.Text = "Edit Location";
            this.buttonEditLocation.UseVisualStyleBackColor = false;
            this.buttonEditLocation.Click += new System.EventHandler(this.ButtonEditLocation_Click);
            // 
            // buttonAddLocation
            // 
            this.buttonAddLocation.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddLocation.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.buttonAddLocation.FlatAppearance.BorderSize = 0;
            this.buttonAddLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddLocation.Font = new System.Drawing.Font("Tahoma", 15F);
            this.buttonAddLocation.ForeColor = System.Drawing.Color.LightCyan;
            this.buttonAddLocation.Location = new System.Drawing.Point(44, 79);
            this.buttonAddLocation.Name = "buttonAddLocation";
            this.buttonAddLocation.Size = new System.Drawing.Size(176, 35);
            this.buttonAddLocation.TabIndex = 24;
            this.buttonAddLocation.Text = "Add Location";
            this.buttonAddLocation.UseVisualStyleBackColor = false;
            this.buttonAddLocation.Click += new System.EventHandler(this.ButtonAddLocation_Click);
            // 
            // Locations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 217);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditLocation);
            this.Controls.Add(this.buttonAddLocation);
            this.Name = "Locations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locations";
            this.Load += new System.EventHandler(this.Locations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditLocation;
        private System.Windows.Forms.Button buttonAddLocation;
    }
}