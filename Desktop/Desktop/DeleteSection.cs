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
    public partial class DeleteSection : Form
    {
        SectionList sectionList;
        SectionStudentList sectionStudentList;
        ScheduleList scheduleList;

        public DeleteSection()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteSection_Load(object sender, EventArgs e)
        {
            sectionList = new SectionList();
            sectionStudentList = new SectionStudentList();
            scheduleList = new ScheduleList();
            PopulateSections();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this section?",
               "Delete Notice", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Section section = (Section)cmbSectionID.SelectedItem;
                //Delete All Related Records First
                //From SectionStudent Table
                sectionStudentList.Delete("SectionID", cmbSectionID.SelectedItem.ToString());
                //From Schedule Table
                scheduleList.Delete("SectionID", cmbSectionID.SelectedItem.ToString());
                //Delete Section From Section Table Second
                sectionList.Delete(section);

                if (section.getValid() == true)
                {
                    MessageBox.Show("Section has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not added.");
                }

            }
            PopulateSections();
        }

        private void PopulateSections()
        {
            sectionList.Populate();
            cmbSectionID.DataSource = sectionList.List;
        }
    }
}
