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
    public partial class DeleteTaughtCourse : Form
    {
        //class level variables
        ScheduleList scheduleList;
        SectionStudentList sectionStudentList;
        SectionList sectionList;
        TaughtCourseList taughtCourses;

        public DeleteTaughtCourse()
        {
            InitializeComponent();
            taughtCourses = new TaughtCourseList();
            scheduleList = new ScheduleList();
            sectionStudentList = new SectionStudentList();
            sectionList = new SectionList();
        }
        //closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //on load, populate the taught course list and set the combobox to it
        private void DeleteTaughtCourse_Load(object sender, EventArgs e)
        {
            taughtCourses.Populate();
            this.cmbTaughtID.DataSource = taughtCourses.List;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //prompts a validation message to ensure selection
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this taught course?",
               "Delete Notice", MessageBoxButtons.YesNo);
            //if yes, the taught course object is created and passed to be deleted
            if (dialogResult == DialogResult.Yes)
            {
                TaughtCourse tCourse = (TaughtCourse)this.cmbTaughtID.SelectedItem;
                //Delete All Related Records First
                //From Schedule Table
                scheduleList.Delete("Section", "Section.SectionID", "Schedule.SectionID", "Section.TaughtCourseID", cmbTaughtID.SelectedItem.ToString());
                //From SectionStudent Table
                sectionStudentList.Delete("Section", "Section.SectionID", "SectionStudent.SectionID", "Section.TaughtCourseID", cmbTaughtID.SelectedItem.ToString());
                //From Section Table
                sectionList.Delete("TaughtCourseID", cmbTaughtID.SelectedItem.ToString());
                //Delete Taught Course From Taught Courses Table Second
                taughtCourses.Delete(tCourse);
                //checks if the execution was a seccuess or not
                if (tCourse.getValid() == true)
                {
                    MessageBox.Show("Taught Course has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. Record was not deleted.");
                }
                
            }
        }
    }
}
