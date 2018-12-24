using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;

namespace Desktop
{
    /*
    The Add Course class
    Contains all methods for creating a course to the Courses table
    */
    public partial class AddCourse : Form
    {
        CourseList courseList;
        public AddCourse()
        {
            InitializeComponent();
        }

        //Responsible to instantiate the courseList object
        private void AddCourse_Load(object sender, EventArgs e)
        {
            courseList = new CourseList();
        }

        //Responsible of submitting the course with all its details to the database
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            course.CourseID = textBoxID.Text.ToString();
            course.Title = textBoxTitle.Text;
            course.Credits = textBoxCredits.Text;
            courseList.Add(course);
            MessageBox.Show("Course Added Successfully!");
        }

        //Used to clear all the textboses and refilling required data
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            //for loop to clear the controls which are textboxes
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        //Used to exit the current opened form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
