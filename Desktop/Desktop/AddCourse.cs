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
    public partial class AddCourse : Form
    {
        CourseList courseList;
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            courseList = new CourseList();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            course.CourseID = textBoxID.Text.ToString();
            course.Title = textBoxTitle.Text;
            course.Credits = textBoxCredits.Text;
            courseList.Add(course);
            MessageBox.Show("Course Added Successfully!");
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
