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
        private void EditSchedule_Load(object sender, EventArgs e)
        {
            schedules.Populate();
            this.cmbSchedules.DataSource = schedules.List;
        }

        private void cmbSchedules_SelectedIndexChanged(object sender, EventArgs e)
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
            Schedule sch = new Schedule();
            sch.setID(this.cmbSchedules.SelectedItem.ToString());
            Section section = (Section)this.cmbSections.SelectedItem;
            sch.SectionID = section.getID();
            Location location = (Location)this.cmbLocations.SelectedItem;
            sch.LocationID = location.getID();
            sch.Day = cmbDays.SelectedItem.ToString();
            sch.Duration = this.txtDuration.Text.ToString();
            sch.Time = this.txtTime.Text.ToString();

            //check double scheduling for instructor using sectionID
            Boolean chkInstructor =
                schedules.Exist("Section", "Schedule.SectionID", "Section.SectionID", "Day", "'" + sch.Day.ToString() + "'",
                "Time", sch.Time.ToString(), "Section.instructorID", section.InstructorID.ToString());
            if (chkInstructor)
            {
                Boolean chkLocation = schedules.Exist("Day", sch.Day.ToString(), "Time",
                    sch.Time.ToString(), "LocationID", sch.LocationID.ToString());
                if (chkLocation)
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
    }
}
