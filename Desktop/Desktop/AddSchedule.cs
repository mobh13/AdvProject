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
    public partial class AddSchedule : Form
    {
        ScheduleList schedules = new ScheduleList();
        SectionList sections = new SectionList();
        LocationList locations = new LocationList();

        public AddSchedule()
        {
            InitializeComponent();
        }

        private void AddSchedule_Load(object sender, EventArgs e)
        {
            schedules.Populate();
            nextID();
            sections.Populate();
            this.cmbSections.DataSource = sections.List;
            locations.Populate();
            this.cmbLocations.DataSource = locations.List;
            string[] days = { "Sunday", "Monday", "Tuesday", "Wensday", "Thursday", "Friday", "Saturday" };
            foreach (string day in days)
            {
                this.cmbDays.Items.Add(day);
            }
        }

        void nextID()
        {
            int ID = schedules.GetMaxID() + 1;
            this.txtScheduleID.Text = ID.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Name != "txtScheduleID")
                {
                    txt.Text = "";
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Schedule sch = new Schedule();
            sch.setID(this.txtDuration.Text.ToString());
            Section section = (Section)this.cmbSections.SelectedItem;
            sch.SectionID = section.getID();
            sch.LocationID = ((Location)this.cmbLocations.SelectedItem).getID();
            sch.Day = cmbDays.SelectedItem.ToString();
            sch.Duration = this.txtDuration.Text.ToString();
            sch.Time = this.txtTime.Text.ToString();

            //check double scheduling for instructor using sectionID
            Boolean chkInstructor = 
                schedules.Exist("Section", "Schedule.SectionID", "Section.SectionID","Day",sch.Day.ToString(),
                "Time",sch.Time.ToString(), "Section.instrcutorID", section.InstructorID.ToString());
            if (chkInstructor)
            {
                Boolean chkLocation = schedules.Exist("Day",sch.Day.ToString(),"Time",
                    sch.Time.ToString(),"LocationID",sch.LocationID.ToString());
                if (chkLocation)
                {
                    /*
                     * select (location.capacity - section.capacity) from schedule 
                     * where location.locationID = schedule.locationID 
                     * and schedule.sectionID = section.sectionID 
                     * and location.locaionID = value 
                     * and section.sectionID = value
                     */
                }
                else
                {
                    MessageBox.Show("Location is busy at this time.");
                }
            }
            else
            {
                MessageBox.Show("Instructor is busy at this time.");
            }
         }
     }
}
