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

        private void button2_Click(object sender, EventArgs e)
        {
            Form coursesForm = new Courses();
            coursesForm.Show();
            coursesForm.Location = this.Location;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form taughtCoursesForm = new TaughtCourses();
            taughtCoursesForm.Show();
            taughtCoursesForm.Location = this.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form sectionsForm = new Sections();
            sectionsForm.Show();
            sectionsForm.Location = this.Location;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form studentsForm = new Students();
            studentsForm.Show();
            studentsForm.Location = this.Location;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form schedulesForm = new Schedules();
            schedulesForm.Show();
            schedulesForm.Location = this.Location;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form locationsForm = new Locations();
            locationsForm.Show();
            locationsForm.Location = this.Location;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form reportsForm = new Reports();
            reportsForm.Show();
            reportsForm.Location = this.Location;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
