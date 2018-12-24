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
    The Delete Instructors class
    Contains all methods for deleting an instructor from the Instructors table
    */
    public partial class DeleteInstructor : Form
    {
        InstructorList instructorList;
        ScheduleList scheduleList;
        SectionStudentList sectionStudentList;
        SectionList sectionList;
        public DeleteInstructor()
        {
            InitializeComponent();
        }

        //Populate the combo box of the instructor IDs and instantiantes objects to use
        private void DeleteInstructor_Load(object sender, EventArgs e)
        {
            instructorList = new InstructorList();
            scheduleList = new ScheduleList();
            sectionStudentList = new SectionStudentList();
            sectionList = new SectionList();
            PopulateInstructors();
        }

        //Populate the instructors combobox with instructors IDs
        private void PopulateInstructors()
        {
            instructorList.Populate();
            comboBoxID.DataSource = null; //To reset the data source
            comboBoxID.DataSource = instructorList.List; //Get the source from the list
            comboBoxID.SelectedIndex = 0;
        }

        //Deletes the selected instructor from the combobox from the databse
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            //Prompt the user if he wants to delete the instructor (for confirmation)
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this instructor?",
               "Delete Notice", MessageBoxButtons.YesNo);
            //If the user clicks Yes Button
            if (dialogResult == DialogResult.Yes)
            {
                Instructor instructor = (Instructor)comboBoxID.SelectedItem;
                //Delete All Related Records First
                //From Schedule Table
                scheduleList.Delete("Section", "Section.SectionID", "Schedule.SectionID", "Section.InstructorID", comboBoxID.SelectedItem.ToString());
                //From SectionStudent Table
                sectionStudentList.Delete("Section", "Section.SectionID", "SectionStudent.SectionID", "Section.InstructorID", comboBoxID.SelectedItem.ToString());
                //From Section Table
                sectionList.Delete("InstructorID", comboBoxID.SelectedItem.ToString());
                //Delete Instructor From Instructor Table Second
                instructorList.Delete(instructor);

                //Check if instructor is valid or not and show appropriate message
                if (instructor.getValid() == true)
                {
                    MessageBox.Show("Instructor has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not added.");
                }

            }
            //Re-populate the comboboxes after the deletion
            PopulateInstructors();
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
