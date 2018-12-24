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
    The Edit Instructors class
    Contains all methods for editing/updating an instructor from the Instructors table
    */
    public partial class EditInstructor : Form
    {
        InstructorList instructorList;
        public EditInstructor()
        {
            InitializeComponent();
        }

        //Populate both the instructor list and fields when the page is loaded
        private void EditInstructor_Load(object sender, EventArgs e)
        {
            instructorList = new InstructorList();
            instructorList.Populate();
            PopulateInstructors();
        }

        //Re-populate the text boxes whenever the combobox value changes (the user selects another instructor)
        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateInstructors();
        }

        //Populate the correlated text boxes with chosen instructor and combo boxes with all instructors IDs
        private void PopulateInstructors()
        {
            //change the data source of the combo box to the data from the instructor list
            comboBoxID.DataSource = instructorList.List;
            //Create an Instructor object from the item selected in the combobox from the user
            Instructor instructor = (Instructor)comboBoxID.SelectedItem;
            //Fill the appropriate text boxes from the Instructor object selected by the user
            textBoxFname.Text = instructor.FirstName;
            textBoxlName.Text = instructor.LastName;
            textBoxHdate.Text = instructor.HireDate;
            textBoxPasswd.Text = instructor.Password;
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

        //Responsible of updating the instructor with all its details to the database
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Taking all the details from text boxes (submitted by user) and fill it in an Instructor object
            Instructor instructor = (Instructor)comboBoxID.SelectedItem;
            instructor.FirstName = textBoxFname.Text;
            instructor.LastName = textBoxlName.Text;
            instructor.HireDate = textBoxHdate.Text;
            instructor.Password = textBoxPasswd.Text;
            //Update the instructor
            instructorList.Update(instructor);
            //Show confirmation message
            MessageBox.Show("Instructor Updated Successfully!");
            //Re-populate the ID combobox
            PopulateInstructors();
        }
    }
}
