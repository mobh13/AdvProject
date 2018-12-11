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
    public partial class EditCourse : Form
    {
        CourseList courseList;
        public EditCourse()
        {
            InitializeComponent();
        }

        private void EditCourse_Load(object sender, EventArgs e)
        {
            courseList = new CourseList();
            courseList.Populate();
            PopulateCourses();
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCourses();
        }

        private void PopulateCourses()
        {
            comboBoxID.DataSource = courseList.List;
            Course course = (Course)comboBoxID.SelectedItem;
            textBoxTitle.Text = course.Title;
            textBoxCredits.Text = course.Credits;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Course course = (Course)comboBoxID.SelectedItem;
            course.Title = textBoxTitle.Text;
            course.Credits = textBoxCredits.Text;
            courseList.Update(course);
            MessageBox.Show("Course Updated Successfully!");
            PopulateCourses();
        }
    }
}
