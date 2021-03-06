﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class TaughtCourse : Item
    {
        private string courseID;
        private string semester;
        private string year;

        public string TaughtCourseID { get => base.getID(); set => base.setID(value); }
        public string CourseID { get => courseID; set => courseID = value; }
        public string Semester { get => semester; set => semester = value; }
        public string Year { get => year; set => year = value; }

        public TaughtCourse(String ID) : base(ID)
        {

        }
        public TaughtCourse()
        {

        }
        public override string ToString()
        {
            return TaughtCourseID;
        }
    }
}
