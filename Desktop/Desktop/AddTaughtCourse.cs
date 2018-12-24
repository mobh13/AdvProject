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
    public partial class AddTaughtCourse : Form
    {
        //class level variable to be used throughout the form
        TaughtCourseList taughtCourses;
        CourseList courses;
        public AddTaughtCourse()
        {
            //instantiating the objects to be used in the 
            InitializeComponent();
            taughtCourses = new TaughtCourseList();
            courses = new CourseList();
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the windows form
            this.Close();
        }

        private void AddTaughtCourse_Load(object sender, EventArgs e)
        {
            //set the next avaiable id in the text box
            nextID();
            //populate the courses combobox
            courses.Populate();
            this.cmbCourseID.DataSource = courses.List;
            this.cmbCourseID.SelectedIndex = -1;
        }
        //a method that returns next avaiable id in the database table
        void nextID()
        {
            int ID = taughtCourses.GetMaxID() + 1;
            this.txtTaughtID.Text = ID.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        //a method that clear text boxes and comboboxes except the id text box
        void clear()
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Name != "txtTaughtID")
                {
                    txt.Text = "";
                }
            }
            foreach (ComboBox cmb in this.Controls.OfType<ComboBox>())
            {
                cmb.SelectedIndex = -1;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //create a TaughtCourse object to be used to store information
            TaughtCourse tCourse = new TaughtCourse();
            //setting the properties of the object
            tCourse.setID(this.txtTaughtID.Text.ToString());
            tCourse.CourseID = this.cmbCourseID.SelectedItem.ToString();
            tCourse.Semester = this.cmbSemester.SelectedItem.ToString();
            //checks if the capacity entered is a number
            Boolean isValid = true;
            foreach (char c in this.txtYear.Text.ToString())
            {
                //checks the cahracter is between 0 or 9  and set the boolean to false if not
                if (c < '0' || c > '9')
                {
                    isValid = false;
                }
            }
            //if the string contains only numbers then set the proeprty
            if (isValid)
            {
                tCourse.Year = this.txtYear.Text.ToString();
            }
            else
            {
                //if invalid input, set the default value 0000 and show a message
                tCourse.Year = "0000";
                MessageBox.Show("Year entered is invalid.");
            }
            //call the add method and pass the TaughtCourse object as a parameter
            taughtCourses.Add(tCourse);
            //checks if the execution was a success or not
            if (tCourse.getValid() == true)
            {
                MessageBox.Show("Taught course have been added successfully.");
                //This calls two methods to get the new id and clears old information
                clear();
                nextID();
            }
            else
            {
                MessageBox.Show("An error has occured. record was not added.");
            }
        }
    }
}
