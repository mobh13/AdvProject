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
    public partial class AddStudent : Form
    {
        StudentList studentList;
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            studentList = new StudentList();
            textBoxID.Text = (studentList.GetMaxID() + 1).ToString();
            textBoxEdate.Text = DateTime.Now.ToString();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.StudentID = textBoxID.Text.ToString();
            student.FirstName = textBoxFname.Text;
            student.LastName = textBoxLname.Text;
            student.EnrollmentDate = textBoxEdate.Text;
            student.Password = textBoxPasswd.Text;
            studentList.Add(student);
            MessageBox.Show("Student Added Successfully!");
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
            textBoxID.Text = studentList.GetMaxID().ToString();
            textBoxEdate.Text = DateTime.Now.ToString();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
