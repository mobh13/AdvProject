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
    The Edit Course class
    Contains all methods for editing/updating a course from the Courses table
    */
    public partial class EditCourse : Form
    {
        CourseList courseList;
        public EditCourse()
        {
            InitializeComponent();
        }

        //Populate both the course list and fields when the page is loaded
        private void EditCourse_Load(object sender, EventArgs e)
        {
            courseList = new CourseList();
            courseList.Populate();
            PopulateCourses();
        }

        //Re-populate the text boxes whenever the combobox value changes (the user selects another course)
        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCourses();
        }

        //Populate the correlated text boxes with chosen course and combo boxes with all courses IDs
        private void PopulateCourses()
        {
            //change the data source of the combo box to the data from the course list
            comboBoxID.DataSource = courseList.List;
            //Create a course object from the item selected in the combobox from the user
            Course course = (Course)comboBoxID.SelectedItem;
            //Fill the appropriate text boxes from the Course object selected by the user
            textBoxTitle.Text = course.Title;
            textBoxCredits.Text = course.Credits;
        }

        //Clear the text boxes
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            //Clear all the controls which are text boxes
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        //Exit current page
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Responsible of updating the course with all its details to the database
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
                //Taking all the details from text boxes (submitted by user) and fill it in an course object
                Course course = (Course)comboBoxID.SelectedItem;
                course.Title = textBoxTitle.Text;
                course.Credits = textBoxCredits.Text;
                //Update the course
                courseList.Update(course);
                if (course.getValid())
                {
                    //Show confirmation message
                    MessageBox.Show("Course Updated Successfully!");
                    //Show confirmation message
                    PopulateCourses();
                }
                else
                {
                    MessageBox.Show("An error has occured");
                }
            } else
            {
                MessageBox.Show("A field is empty");
            }
                
        }
    }
}
