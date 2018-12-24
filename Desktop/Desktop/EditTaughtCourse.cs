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
    public partial class EditTaughtCourse : Form
    {
        public EditTaughtCourse()
        {
            InitializeComponent();
        }
        TaughtCourseList taughtCourses = new TaughtCourseList();
        CourseList courses = new CourseList();
        private void EditTaughtCourse_Load(object sender, EventArgs e)
        {
            //populate the lists and combo oxes 
            taughtCourses.Populate();
            this.cmbTaughtCourse.DataSource = taughtCourses.List;
            this.cmbTaughtCourse.SelectedIndex = -1;

            courses.Populate();
            this.cmbCourse.DataSource = courses.List;
            this.cmbCourse.SelectedIndex = -1;

            this.txtYear.Text = "";

            this.cmbSemester.SelectedIndex = -1;
        }

        private void cmbTaughtCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTaughtCourse.SelectedIndex !=-1)
            {
                TaughtCourse tCourse = (TaughtCourse)this.cmbTaughtCourse.SelectedItem;
                int count = 0;
                //searches and sets the course in combobox
                foreach (Course cou in cmbCourse.Items)
                {
                    if (cou.getID() == tCourse.CourseID)
                    {
                        this.cmbCourse.SelectedIndex = count;
                    }
                    count++;
                }
                count = 0;
                //searches and sets the semester in combobox
                foreach (String sem in cmbSemester.Items)
                {
                    if (sem == tCourse.Semester)
                    {
                        this.cmbSemester.SelectedIndex = count;
                    }
                    count++;
                }
                this.txtYear.Text = tCourse.Year;
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears all controls in the form
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            foreach (ComboBox cmb in this.Controls.OfType<ComboBox>())
            {
                cmb.SelectedIndex = -1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes form
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //foreach loop that checks all controls and whether if they are empty or not.
            bool isEmpty = false;
            foreach (Control ctl in this.Controls.OfType<ComboBox>())
            {
                if (ctl.Text == "" || ctl.Text == null)
                {
                    isEmpty = true;
                }
            }
            if (isEmpty == false)
            {
                //create an object and set properties
                TaughtCourse tCourse = (TaughtCourse)this.cmbTaughtCourse.SelectedItem;
                tCourse.Semester = this.cmbSemester.SelectedItem.ToString();
                tCourse.CourseID = this.cmbCourse.SelectedItem.ToString();
                //checks if the capacity entered is a number by checking each character in the number
                Boolean isValid = false;
                foreach (char c in this.txtYear.Text.ToString())
                {
                    if (c < '0' || c > '9')
                    {
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                //if valid, set the year. if not, set the default value
                if (isValid)
                {
                    tCourse.Year = this.txtYear.Text.ToString();
                }
                else
                {
                    tCourse.Year = "0000";
                    MessageBox.Show("Year entered is invalid.");
                }
                //updates the created taught course object 
                taughtCourses.Update(tCourse);
                if (tCourse.getValid() == true)
                {
                    MessageBox.Show("Taught Course have been updated successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. Record was not updated.");
                }
           }
        }
    }
}
