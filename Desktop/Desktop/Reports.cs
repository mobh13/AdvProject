﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form totalHoursForm = new TotalHours();
            totalHoursForm.Show();
            totalHoursForm.Location = this.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form averageGradeForm = new AverageGrade();
            averageGradeForm.Show();
            averageGradeForm.Location = this.Location;
        }
    }
}