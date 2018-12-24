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
    The Total Hours class
    Used to display the total hours (duration) for a particular Location, Section, Instructor, Course, Student or All the total Hours
    */
    public partial class TotalHours : Form
    {
        ScheduleList scheduleList;
        LocationList locationList;
        SectionList sectionList;
        InstructorList instructorList;
        CourseList courseList;
        StudentList studentList;

        public TotalHours()
        {
            InitializeComponent();
        }

        //Close current opened form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Instantiates all objects to be used and adds the table names to the tables combobox
        private void TotalHours_Load(object sender, EventArgs e)
        {
            scheduleList = new ScheduleList();

            locationList = new LocationList();
            locationList.Populate();
            sectionList = new SectionList();
            sectionList.Populate();
            instructorList = new InstructorList();
            instructorList.Populate();
            courseList = new CourseList();
            courseList.Populate();
            studentList = new StudentList();
            studentList.Populate();

            //Adds the tables of wanted data to be selected from in an Array
            String[] tables = { "Location", "Section", "Instructor", "Course", "Student", "All" };
            //Make above array the datasource of the tables combobox
            comboBoxBy.DataSource = tables;
        }

        //Populates the fields combobox of the selected table from the tables combobox
        private void ComboBoxBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Switch statement taking the table name and choosing which table to populate its fields
            switch (comboBoxBy.SelectedItem.ToString())
            {
                case "Location":
                    //Change the data source to the fields of the specific selected table 
                    comboBoxFor.DataSource = locationList.List;
                    break;
                case "Section":
                    comboBoxFor.DataSource = sectionList.List;
                    break;
                case "Instructor":
                    comboBoxFor.DataSource = instructorList.List;
                    break;
                case "Course":
                    comboBoxFor.DataSource = courseList.List;
                    break;
                case "Student":
                    comboBoxFor.DataSource = studentList.List;
                    break;
                case "All":
                    comboBoxFor.DataSource = null;
                    textBoxTotal.Text = scheduleList.TotalValue("Duration").ToString(); //Takes the total duration of all and puts it in the total text box
                    break;
                default:
                    break;
            }
        }

        //Fills the total text box with the duration based on selected field from the table 
        private void ComboBoxFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Switch statement to make sure of the table selected and display the total based on column selected
            switch (comboBoxBy.SelectedItem.ToString())
            {
                case "Location":
                    //Fill text file based on both the table selected and the column selected from both comboboxes
                    textBoxTotal.Text = scheduleList.TotalValue("Duration", "LocationID", 
                        comboBoxFor.SelectedItem.ToString()).ToString();
                    break;
                case "Section":
                    //Commented script is where 6 parameters were used (still works) (Model Design Given)
                    //textBoxTotal.Text = scheduleList.TotalValue("Duration", "Section", "Section.SectionID", 
                    //    "Schedule.SectionID", "Section.SectionID", comboBoxFor.SelectedItem.ToString()).ToString();
                    textBoxTotal.Text = scheduleList.TotalValue("Duration", "Section", "SectionID",
                        "Section.SectionID", comboBoxFor.SelectedItem.ToString()).ToString();
                    break;
                case "Instructor":
                    //Commented script is where 6 parameters were used (still works) (Model Design Given)
                    //textBoxTotal.Text = scheduleList.TotalValue("Duration", "Section", "Section.SectionID",
                    //    "Schedule.SectionID", "Section.InstructorID", comboBoxFor.SelectedItem.ToString()).ToString();
                    textBoxTotal.Text = scheduleList.TotalValue("Duration", "Section", "SectionID",
                        "Section.InstructorID", comboBoxFor.SelectedItem.ToString()).ToString();
                    break;
                case "Course":
                    //Commented script is where 9 parameters were used (still works) (Model Design Given)
                    //textBoxTotal.Text = scheduleList.TotalValue("Duration", "Section", "Section.SectionID",
                    //    "Schedule.SectionID", "TaughtCourse", "Section.TaughtCourseID", "TaughtCourse.TaughtCourseID",
                    //    "TaughtCourse.CourseID", comboBoxFor.SelectedItem.ToString()).ToString();
                    textBoxTotal.Text = scheduleList.TotalValue("Duration", "Section", "SectionID", "TaughtCourseID",
                    "TaughtCourse", "TaughtCourse.CourseID", comboBoxFor.SelectedItem.ToString()).ToString();
                    break;
                case "Student":
                    //Commented script is where 6 parameters were used (still works) (Model Design Given)
                    //textBoxTotal.Text = scheduleList.TotalValue("Duration", "SectionStudent", "SectionStudent.SectionID",
                    //    "Schedule.SectionID", "SectionStudent.StudentID", comboBoxFor.SelectedItem.ToString()).ToString();
                    textBoxTotal.Text = scheduleList.TotalValue("Duration", "SectionStudent", "SectionID",
                        "SectionStudent.StudentID", comboBoxFor.SelectedItem.ToString()).ToString();
                    break;
                default:
                    break;
            }
        }
    }
    }

