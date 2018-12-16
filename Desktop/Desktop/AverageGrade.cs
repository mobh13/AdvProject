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
    public partial class AverageGrade : Form
    {
        public AverageGrade()
        {
            InitializeComponent();
        }
        
        // Section, Student and Course
        SectionList sections = new SectionList();
        StudentList students = new StudentList();
        CourseList courses = new CourseList();
        SectionStudentList secStuds = new SectionStudentList();

        private void AverageGrade_Load(object sender, EventArgs e)
        {
            string[] listBy = {"Section","Student","Course"};
            foreach (String by in listBy)
            {
                this.cmbListBy.Items.Add(by);
            }
        }

        private void cmbListBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbListBy.SelectedItem.ToString())
            {
                case "Section":
                    sections.Populate();
                    this.cmbListFor.DataSource = sections.List;
                    this.cmbListFor.SelectedIndex = -1;
                    break;
                case "Student":
                    students.Populate();
                    this.cmbListFor.DataSource = students.List;
                    this.cmbListFor.SelectedIndex = -1;
                    break;
                case "Course":
                    courses.Populate();
                    this.cmbListFor.DataSource = courses.List;
                    this.cmbListFor.SelectedIndex = -1;
                    break;
                default:
                    break;
            }
        }

        private void cmbListFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbListFor.SelectedIndex != -1)
            {
                //string avgColumn, string column, string value
                secStuds.AverageValue();
            }
        }
    }
}
