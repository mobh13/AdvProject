using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

	
//Set fixed border
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;


//Disable the minimize box and the maximize box
			this.MinimizeBox = false;
this.MaximizeBox = false;
			label4.Text = DateTime.Now.ToLongDateString();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Form instructorsForm = new Instructors();
            instructorsForm.Show();
            instructorsForm.Location = this.Location;
        }
    }
}
