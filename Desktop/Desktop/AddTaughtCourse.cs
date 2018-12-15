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
        public AddTaughtCourse()
        {
            InitializeComponent();
        }
        TaughtCourseList taughtCourses = new TaughtCourseList();
        CourseList courses = new CourseList();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTaughtCourse_Load(object sender, EventArgs e)
        {
            nextID();
            courses.Populate();
            this.cmbCourseID.DataSource = courses.List;
            this.cmbCourseID.SelectedIndex = -1;
        }
        void nextID()
        {
            int ID = taughtCourses.GetMaxID() + 1;
            this.txtTaughtID.Text = ID.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
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
            TaughtCourse tCourse = new TaughtCourse();
            tCourse.setID(this.txtTaughtID.Text.ToString());
            tCourse.CourseID = this.cmbCourseID.SelectedItem.ToString();
            tCourse.Semester = this.cmbSemester.SelectedItem.ToString();
            tCourse.Year = this.txtYear.Text.ToString();
            taughtCourses.Add(tCourse);
            if (tCourse.getValid() == true)
            {
                MessageBox.Show("Taught course have been added successfully.");
            }
            else
            {
                MessageBox.Show("An error has occured. record was not added.");
            }
        }
    }
}
