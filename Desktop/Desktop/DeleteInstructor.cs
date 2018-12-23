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

        private void DeleteInstructor_Load(object sender, EventArgs e)
        {
            instructorList = new InstructorList();
            scheduleList = new ScheduleList();
            sectionStudentList = new SectionStudentList();
            sectionList = new SectionList();
            PopulateInstructors();
        }

        private void PopulateInstructors()
        {
            instructorList.Populate();
            comboBoxID.DataSource = null;
            comboBoxID.DataSource = instructorList.List;
            comboBoxID.SelectedIndex = 0;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this instructor?",
               "Delete Notice", MessageBoxButtons.YesNo);
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

                if (instructor.getValid() == true)
                {
                    MessageBox.Show("Instructor has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not added.");
                }

            }
            PopulateInstructors();
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
