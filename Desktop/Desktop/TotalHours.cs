﻿using System;
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

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

            String[] tables = { "Location", "Section", "Instructor", "Course", "Student", "All" };
            comboBoxBy.DataSource = tables;
        }

        private void ComboBoxBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxBy.SelectedItem.ToString())
            {
                case "Location":
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
                    textBoxTotal.Text = scheduleList.TotalValue("Duration").ToString();
                    break;
                default:
                    break;
            }
        }

        private void ComboBoxFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxBy.SelectedItem.ToString())
            {
                case "Location":
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

