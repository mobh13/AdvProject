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
    The Edit Student class
    Contains all methods for editing/updating a student from the Students table
    */
    public partial class EditStudent : Form
    {
        StudentList studentList;
        public EditStudent()
        {
            InitializeComponent();
        }

        //Populate both the student list and fields when the page is loaded
        private void EditStudent_Load(object sender, EventArgs e)
        {
            studentList = new StudentList();
            studentList.Populate();
            PopulateStudents();
        }

        //Re-populate the text boxes whenever the combobox value changes (the user selects another student)
        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateStudents();
        }

        //Populate the correlated text boxes with chosen student and combo boxes with all students IDs
        private void PopulateStudents()
        {
            //change the data source of the combo box to the data from the student list
            comboBoxID.DataSource = studentList.List;
            //Create an Student object from the item selected in the combobox from the user
            Student student = (Student)comboBoxID.SelectedItem;
            //Fill the appropriate text boxes from the Student object selected by the user
            textBoxFname.Text = student.FirstName;
            textBoxlName.Text = student.LastName;
            textBoxEdate.Text = student.EnrollmentDate;
            textBoxPasswd.Text = student.Password;
        }

        //Clear the text boxes
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            //Clear all the controls which are text boxes
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        //Exit the current form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Responsible of updating the student with all its details to the database
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Taking all the details from text boxes (submitted by user) and fill it in an Student object
            Student student = (Student)comboBoxID.SelectedItem;
            student.FirstName = textBoxFname.Text;
            student.LastName = textBoxlName.Text;
            student.EnrollmentDate = textBoxEdate.Text;
            student.Password = textBoxPasswd.Text;
            //Update the student
            studentList.Update(student);
            //Show confirmation message
            MessageBox.Show("Student Updated Successfully!");
            //Re-populate the ID combobox
            PopulateStudents();
        }
    }
}
