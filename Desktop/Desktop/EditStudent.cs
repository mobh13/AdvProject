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
    public partial class EditStudent : Form
    {
        StudentList studentList;
        public EditStudent()
        {
            InitializeComponent();
        }

        private void EditStudent_Load(object sender, EventArgs e)
        {
            studentList = new StudentList();
            studentList.Populate();
            PopulateStudents();
        }

        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateStudents();
        }

        private void PopulateStudents()
        {
            comboBoxID.DataSource = studentList.List;
            Student student = (Student)comboBoxID.SelectedItem;
            textBoxFname.Text = student.FirstName;
            textBoxlName.Text = student.LastName;
            textBoxEdate.Text = student.EnrollmentDate;
            textBoxPasswd.Text = student.Password;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Student student = (Student)comboBoxID.SelectedItem;
            student.FirstName = textBoxFname.Text;
            student.LastName = textBoxlName.Text;
            student.EnrollmentDate = textBoxEdate.Text;
            student.Password = textBoxPasswd.Text;
            studentList.Update(student);
            MessageBox.Show("Student Updated Successfully!");
            PopulateStudents();
        }
    }
}
