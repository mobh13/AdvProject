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
    public partial class EditSchedule : Form
    {
        public EditSchedule()
        {
            InitializeComponent();
        }

        ScheduleList schedules = new ScheduleList();
        SectionList sections = new SectionList();
        LocationList locations = new LocationList();

        private void EditSchedule_Load(object sender, EventArgs e)
        {
            schedules.Populate();
            this.cmbSchedules.DataSource = schedules.List;
            this.cmbSchedules.SelectedIndex = -1;

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

            this.txtDuration.Text = "";
            this.txtTime.Text = "";
        }

        private void cmbSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSchedules.SelectedIndex != -1)
            {
                Schedule schedule = (Schedule)this.cmbSchedules.SelectedItem;
                int count = 0;
                foreach (Section sec in cmbSections.Items)
                {
                    if (sec.getID() == schedule.SectionID)
                    {
                        this.cmbSections.SelectedIndex = count;
                    }
                    count++;
                }
                count = 0;
                foreach (Location loc in cmbLocations.Items)
                {
                    if (loc.getID() == schedule.LocationID)
                    {
                        this.cmbLocations.SelectedIndex = count;
                    }
                    count++;
                }
                count = 0;
                foreach (String day in cmbDays.Items)
                {
                    if (day == schedule.Day)
                    {
                        this.cmbDays.SelectedIndex = count;
                    }
                    count++;
                }
                this.txtTime.Text = schedule.Time.ToString();
                this.txtDuration.Text = schedule.Duration.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                    txt.Text = "";
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
            Schedule sch = (Schedule)this.cmbSchedules.SelectedItem;
            Section section = (Section)this.cmbSections.SelectedItem;
            string newSID = section.getID();
            string oldSID = sch.SectionID;
            Location location = (Location)this.cmbLocations.SelectedItem;
            string newLID = location.getID();
            string oldLID = sch.LocationID ;
            string oldDay = sch.Day;
            string newDay = cmbDays.SelectedItem.ToString();
            string oldDuration = sch.Duration;
            string newDuration = this.txtDuration.Text.ToString();
            string oldTime = sch.Time;
            string newTime = this.txtTime.Text.ToString();

            if (newSID != oldSID || oldDay != newDay || newDuration != oldDuration 
                || newTime != oldTime)
            {
                sch.SectionID = newSID;
                sch.Time = newTime;
                sch.Duration = newDuration;
                sch.Day = newDay;
                //check double scheduling for instructor using sectionID
                Boolean chkInstructor = false;
                int checkTime = Convert.ToInt32(sch.Time);
                int schDuration = Convert.ToInt32(sch.Duration);
                while (schDuration >= 1 & !chkInstructor)
                {
                    chkInstructor = schedules.Exist("Section", "Schedule.SectionID", "Section.SectionID", "Day", "'" + sch.Day.ToString() + "'",
                    "Time", checkTime.ToString(), "Section.instructorID", section.InstructorID.ToString());
                    checkTime++;
                    schDuration--;
                }
                if (!chkInstructor)
                {
                    Boolean chkLocation = schedules.Exist("Day", sch.Day.ToString(), "Time",
                        sch.Time.ToString(), "LocationID", sch.LocationID.ToString());
                    if (!chkLocation)
                    {
                        if (Convert.ToInt32(section.Capacity) <= Convert.ToInt32(location.Capacity))
                        {
                            schedules.Update(sch);
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
            }
            else if (newLID != oldLID)
            {
                sch.LocationID = newLID;
                schedules.Update(sch);
                
            }
            if (sch.getValid() == true)
            {
                MessageBox.Show("Schedule have been updated successfully.");
            }
            else
            {
                MessageBox.Show("An error has occured. record was not updated.");
            }
        }
    }
}
