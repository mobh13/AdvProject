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
    The Add Student class
    Contains all methods for creating a student to the Students table
    */
    public partial class AddStudent : Form
    {
        StudentList studentList;
        public AddStudent()
        {
            InitializeComponent();
        }

        //Responsible of filling necessary fields for the adding process
        private void AddStudent_Load(object sender, EventArgs e)
        {
            studentList = new StudentList();
            //Fills the ID text box with the now to be added Student ID (Last Student ID in the table + 1)
            textBoxID.Text = (studentList.GetMaxID() + 1).ToString();
            //Fills the date text box with the current Time and Date
            textBoxEdate.Text = DateTime.Now.ToString();
        }

        //Responsible of submitting the student with all its details to the database
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if there is an empty field
            bool isValid = true;
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    if (ctr.Text == "" || ctr.Text is null)
                    {
                        isValid = false;
                    }
                }
            }

            //Check if there is an empty field that wasn't put
            if (isValid)
            {
                Student student = new Student();
                //Taking all the details from text boxes (submitted by user) and fill it in an Student object
                student.StudentID = textBoxID.Text.ToString();
                student.FirstName = textBoxFname.Text;
                student.LastName = textBoxLname.Text;
                student.EnrollmentDate = textBoxEdate.Text;
                student.Password = textBoxPasswd.Text;
                //Add the student
                studentList.Add(student);
                if (student.getValid())
                {
                    //Show confirmation message
                    MessageBox.Show("Student Added Successfully!");
                    Clear();
                }
                else
                {
                    MessageBox.Show(student.geterrorMessage());
                }
            } else
            {
                MessageBox.Show("A field is empty");
            }
                
        }

        //Used to clear all the textboses and refilling required data
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Used to exit the current opened form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            //for loop to clear the controls which are textboxes
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
    }
}
