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
    The Delete Student class
    Contains all methods for deleting a student from the Students table
    */
    public partial class DeleteStudent : Form
    {
        StudentList studentList;
        SectionStudentList sectionStudentList;
        public DeleteStudent()
        {
            InitializeComponent();
        }

        //Populate the combo box of the student IDs and instantiantes objects to use
        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            studentList = new StudentList();
            sectionStudentList = new SectionStudentList();
            PopulateStudents();
        }

        //Populate the students combobox with students IDs
        private void PopulateStudents()
        {
            studentList.Populate();
            comboBoxID.DataSource = null; //To reset the data source
            comboBoxID.DataSource = studentList.List; //Get the source from the list
            comboBoxID.SelectedIndex = 0;
        }

        //Deletes the selected student from the combobox from the databse
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            //Prompt the user if he wants to delete the student (for confirmation)
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this student?",
               "Delete Notice", MessageBoxButtons.YesNo);
            //If the user clicks Yes Button
            if (dialogResult == DialogResult.Yes)
            {
                Student student = (Student)comboBoxID.SelectedItem;
                //Delete All Related Records First
                //From Section Student Table
                sectionStudentList.Delete("StudentID", comboBoxID.SelectedItem.ToString());
                //Delete Instructor From Instructor Table Second
                studentList.Delete(student);

                //Check if instructor is valid or not and show appropriate message
                if (student.getValid() == true)
                {
                    MessageBox.Show("Student has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not added.");
                }

            }
            //Re-populate the comboboxes after the deletion
            PopulateStudents();
        }

        //Exit the current form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
