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
        SectionStudentList sectionStudentList;
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            studentList = new StudentList();
            sectionStudentList = new SectionStudentList();
            PopulateStudents();
        }

        private void PopulateStudents()
        {
            studentList.Populate();
            comboBoxID.DataSource = null;
            comboBoxID.DataSource = studentList.List;
            comboBoxID.SelectedIndex = 0;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student?",
               "Delete Notice", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Student student = (Student)comboBoxID.SelectedItem;
                sectionStudentList.Delete("StudentID", comboBoxID.SelectedItem.ToString());
                studentList.Delete(student);

                if (student.getValid() == true)
                {
                    MessageBox.Show("Student has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not added.");
                }

            }
            PopulateStudents();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
