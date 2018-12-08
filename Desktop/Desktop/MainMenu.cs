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
            instructorsForm.StartPosition = FormStartPosition.CenterScreen;
            instructorsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form coursesForm = new Courses();
            coursesForm.StartPosition = FormStartPosition.CenterScreen;
            coursesForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form taughtCoursesForm = new TaughtCourses();
            taughtCoursesForm.StartPosition = FormStartPosition.CenterScreen;
            taughtCoursesForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form sectionsForm = new Sections();
            sectionsForm.StartPosition = FormStartPosition.CenterScreen;
            sectionsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form studentsForm = new Students();
            studentsForm.StartPosition = FormStartPosition.CenterScreen;
            studentsForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form schedulesForm = new Schedules();
            schedulesForm.StartPosition = FormStartPosition.CenterScreen;
            schedulesForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form locationsForm = new Locations();
            locationsForm.StartPosition = FormStartPosition.CenterScreen;
            locationsForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form reportsForm = new Reports();
            reportsForm.StartPosition = FormStartPosition.CenterScreen;
            reportsForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
