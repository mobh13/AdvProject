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
            //Check if there is an empty field
            bool isValid = true;
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    if (ctr.Text == "" || ctr.Text is null)
                    {
                        isValid = false;
                    }
                }
            }

            //Check if there is an empty field that wasn't put
            if (isValid)
            {
                Course course = new Course();
                course.CourseID = textBoxID.Text.ToString();
                course.Title = textBoxTitle.Text;
                course.Credits = textBoxCredits.Text;
                courseList.Add(course);
                if (course.getValid())
                {
                    //Show confirmation message
                    MessageBox.Show("Course Added Successfully!");
                    Clear();
                }
                else
                {
                    MessageBox.Show(course.geterrorMessage());
                }
            }
            else
            {
                MessageBox.Show("A field is empty");
            }

        }

        //Used to clear all the textboses and refilling required data
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Used to exit the current opened form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
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
    }
}
