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
    public partial class DeleteStudent : Form
    {
        StudentList studentList;
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            studentList = new StudentList();
            PopulateStudents();
        }

        private void PopulateStudents()
        {
            studentList.Populate();
            comboBoxID.DataSource = null;
            comboBoxID.DataSource = studentList.List;
            comboBoxID.SelectedIndex = 0;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Student student = (Student)comboBoxID.SelectedItem;
            studentList.Delete(student);
            MessageBox.Show("Instructor Deleted Successfully!");
            PopulateStudents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
