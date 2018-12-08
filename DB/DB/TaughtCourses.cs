﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class TaughtCourses : Item
    {
        private string taughCourseID;
        private string courseID;
        private string semester;
        private string year;

        public string TaughCourseID { get => taughCourseID; set => taughCourseID = value; }
        public string CourseID { get => courseID; set => courseID = value; }
        public string Semester { get => semester; set => semester = value; }
        public string Year { get => year; set => year = value; }

        public TaughtCourses(String ID) : base(ID)
        {

        }
        public TaughtCourses()
        {

        }
        public override string ToString()
        {
            return taughCourseID;
        }
    }
}
