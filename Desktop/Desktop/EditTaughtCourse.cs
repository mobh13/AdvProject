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
            taughtCourses.Populate();
            this.cmbTaughtCourse.DataSource = taughtCourses.List;
            this.cmbTaughtCourse.SelectedIndex = -1;

            courses.Populate();
            this.cmbCourse.DataSource = courses.List;
            this.cmbCourse.SelectedIndex = -1;

            this.txtYear.Text = "";
        }

        private void cmbTaughtCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTaughtCourse.SelectedIndex !=-1)
            {
                TaughtCourse tCourse = (TaughtCourse)this.cmbTaughtCourse.SelectedItem;
                int count = 0;
                foreach (Course cou in cmbCourse.Items)
                {
                    if (cou.getID() == tCourse.CourseID)
                    {
                        this.cmbCourse.SelectedIndex = count;
                    }
                    count++;
                }
                count = 0;
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
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            TaughtCourse tCourse = (TaughtCourse)this.cmbTaughtCourse.SelectedItem;
            tCourse.Semester = this.cmbSemester.SelectedItem.ToString();
            tCourse.CourseID = this.cmbCourse.SelectedItem.ToString();
            tCourse.Year = this.txtYear.Text.ToString();
            taughtCourses.Update(tCourse);

            if (tCourse.getValid() == true)
            {
                MessageBox.Show("Taught Course have been updated successfully.");
            }
            else
            {
                MessageBox.Show("An error has occured. record was not updated.");
            }
        }
    }
}
