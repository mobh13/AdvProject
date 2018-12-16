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
            nextID();
            sections.Populate();
            this.cmbSections.DataSource = sections.List;
            this.cmbSections.SelectedIndex = -1;

            locations.Populate();
            this.cmbLocations.DataSource = locations.List;
            this.cmbLocations.SelectedIndex = -1;

            string[] days = { "Sunday", "Monday", "Tuesday", "Wensday", "Thursday", "Friday", "Saturday" };
            foreach (string day in days)
            {
                this.cmbDays.Items.Add(day);
            }
            this.cmbDays.SelectedIndex = -1;
        }

        void nextID()
        {
            int ID = schedules.GetMaxID() + 1;
            this.txtScheduleID.Text = ID.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Name != "txtScheduleID")
                {
                    txt.Text = "";
                }
            }
            foreach (ComboBox cmb in this.Controls.OfType<ComboBox>())
            {
                cmb.SelectedIndex = -1;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Schedule sch = new Schedule();
            sch.setID(this.txtScheduleID.Text.ToString());
            Section section = (Section)this.cmbSections.SelectedItem;
            sch.SectionID = section.getID();
            Location location = (Location)this.cmbLocations.SelectedItem;
            sch.LocationID = location.getID();
            sch.Day = cmbDays.SelectedItem.ToString();
            sch.Duration = this.txtDuration.Text.ToString();
            sch.Time = this.txtTime.Text.ToString();

            //check double scheduling for instructor using sectionID
            Boolean chkInstructor = false;
            int newTime = Convert.ToInt32(sch.Time);
            int schDuration = Convert.ToInt32(sch.Duration);
            while (schDuration >= 1 & !chkInstructor)
            {
                chkInstructor = schedules.Exist("Section", "Schedule.SectionID", "Section.SectionID", "Day", "'" + sch.Day.ToString() + "'",
                "Time", newTime.ToString(), "Section.instructorID", section.InstructorID.ToString());
                newTime++;
                schDuration--;
            }
            if (!chkInstructor)
            {
                Boolean chkLocation = schedules.Exist("Day",sch.Day.ToString(),"Time",
                    sch.Time.ToString(),"LocationID",sch.LocationID.ToString());
                if (!chkLocation)
                {
                    if (Convert.ToInt32(section.Capacity) <= Convert.ToInt32(location.Capacity))
                    {
                        schedules.Add(sch);
                        if (sch.getValid() == true)
                        {
                            MessageBox.Show("Schedule have been added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("An error has occured. Record was not added.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Section's capacity is larger than the location's capacity.");
                    }
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
            clear();
            nextID();
         }
     }
}
