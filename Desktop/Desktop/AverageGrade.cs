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
        //declaring class variables to be used throughout the form
        SectionList sections;
        StudentList students;
        CourseList courses;
        SectionStudentList secStuds;
        public AverageGrade()
        {
            //instantiating the variables
            InitializeComponent();
            sections = new SectionList();
            students = new StudentList();
            courses = new CourseList();
            secStuds = new SectionStudentList();
        }

        private void AverageGrade_Load(object sender, EventArgs e)
        {
            //add the catergories to display the average by
            string[] listBy = {"Collage (All grades)","Section","Student","Course"};
            foreach (String by in listBy)
            {
                this.cmbListBy.Items.Add(by);
            }
        }

        private void cmbListBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //a switch case to check the selection of the 'by' combobox
            switch (this.cmbListBy.SelectedItem.ToString())
            {
                //for each selection, the appropiate list is populated in the 'for' combobox 
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
                    //to show the average grade for all the students in all sections
                case "Collage (All grades)":
                    this.txtAvgGrade.Text = secStuds.AverageValue("Grade").ToString();
                    this.cmbListFor.Items.Clear();
                    break;
                    //the default will show the average for the all of students in collage
                default:
                    this.txtAvgGrade.Text = secStuds.AverageValue("Grade").ToString();
                    this.cmbListFor.Items.Clear();
                    break;
            }
        }

        private void cmbListFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checks if the user selected any option in the combobox
            if (this.cmbListFor.SelectedIndex != -1 )
            {
                //a switch case to check the selection of the 'for' combobox
                switch (this.cmbListBy.SelectedItem.ToString())
                {
                    //for each selection, the appropiate average value is displayed in the text box
                    case "Section":
                        this.txtAvgGrade.Text = secStuds.AverageValue("Grade","SectionID",this.cmbListFor.SelectedItem.ToString()).ToString();
                        break;
                    case "Student":
                        this.txtAvgGrade.Text = secStuds.AverageValue("Grade", "StudentID", this.cmbListFor.SelectedItem.ToString()).ToString();
                        break;
                    case "Course":
                        //********************************************************************************************************
                        //this line of code calls the method with 9 parameters. The same parameters from model design document
                        //********************************************************************************************************
                        //this.txtAvgGrade.Text = secStuds.AverageValue("Grade", "Section", "SectionStudent.sectionID", "Section.sectionID", "TaughtCourse"
                        //    , "Section.taughtCourseID", "TaughtCourse.taughtCourseID", "CourseID", this.cmbListFor.SelectedItem.ToString()).ToString();

                        //********************************************************************************************************
                        //This line calls the method similar to the one above but with less parameters. same as our design document.
                        //********************************************************************************************************
                        this.txtAvgGrade.Text = secStuds.AverageValue("Grade", "Section", "sectionID", "taughtCourseID", "TaughtCourse"
                            , "CourseID", this.cmbListFor.SelectedItem.ToString()).ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        //exit the form when clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
