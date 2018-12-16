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
            string[] listBy = {"Collage (All grades)","Section","Student","Course"};
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
                    this.txtAvgGrade.Text = "";
                    break;
                case "Student":
                    students.Populate();
                    this.cmbListFor.DataSource = students.List;
                    this.cmbListFor.SelectedIndex = -1;
                    this.txtAvgGrade.Text = "";
                    break;
                case "Course":
                    courses.Populate();
                    this.cmbListFor.DataSource = courses.List;
                   this.cmbListFor.SelectedIndex = -1;
                    this.txtAvgGrade.Text = "";
                    break;
                case "Collage (All grades)":
                    this.txtAvgGrade.Text = secStuds.AverageValue("Grade").ToString();
                    this.cmbListFor.Items.Clear();
                    break;

                default:
                    break;
            }
        }

        private void cmbListFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbListFor.SelectedIndex != -1 )
            {
                switch (this.cmbListBy.SelectedItem.ToString())
                {
                    case "Section":
                        this.txtAvgGrade.Text = secStuds.AverageValue("Grade","SectionID",this.cmbListFor.SelectedItem.ToString()).ToString();
                        break;
                    case "Student":
                        this.txtAvgGrade.Text = secStuds.AverageValue("Grade", "StudentID", this.cmbListFor.SelectedItem.ToString()).ToString();
                        break;
                    case "Course":
                        this.txtAvgGrade.Text = secStuds.AverageValue("Grade","Section","SectionStudent.sectionID","Section.sectionID","TaughtCourse"
                            ,"Section.taughtCourseID", "TaughtCourse.taughtCourseID","CourseID",this.cmbListFor.SelectedItem.ToString()).ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
