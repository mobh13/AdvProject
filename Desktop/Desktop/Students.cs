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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addStudentForm = new AddStudent();
            addStudentForm.StartPosition = FormStartPosition.CenterScreen;
            addStudentForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form editStudentForm = new EditStudent();
            editStudentForm.StartPosition = FormStartPosition.CenterScreen;
            editStudentForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form deleteStudentForm = new DeleteStudent();
            deleteStudentForm.StartPosition = FormStartPosition.CenterScreen;
            deleteStudentForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
