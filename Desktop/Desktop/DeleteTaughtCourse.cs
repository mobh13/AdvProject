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
        public DeleteTaughtCourse()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ScheduleList scheduleList;
        SectionStudentList sectionStudentList;
        SectionList sectionList;
        TaughtCourseList taughtCourses;

        private void DeleteTaughtCourse_Load(object sender, EventArgs e)
        {
            taughtCourses = new TaughtCourseList();
            scheduleList = new ScheduleList();
            sectionStudentList = new SectionStudentList();
            sectionList = new SectionList();
            taughtCourses.Populate();
            this.cmbTaughtID.DataSource = taughtCourses.List;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this taught course?",
               "Delete Notice", MessageBoxButtons.YesNo);
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

                if (tCourse.getValid() == true)
                {
                    MessageBox.Show("Taught Course has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not added.");
                }
                
            }
        }
    }
}
