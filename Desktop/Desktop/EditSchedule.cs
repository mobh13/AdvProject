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
        //declaring the class variables to be usued in the form
        ScheduleList schedules;
        SectionList sections;
        LocationList locations;

        public EditSchedule()
        {
            InitializeComponent();
            schedules = new ScheduleList();
            locations = new LocationList();
            sections = new SectionList();
        }


        private void EditSchedule_Load(object sender, EventArgs e)
        {
            //load all the objects in the comboboxes 
            schedules.Populate();
            this.cmbSchedules.DataSource = schedules.List;
            this.cmbSchedules.SelectedIndex = -1;

            sections.Populate();
            this.cmbSections.DataSource = sections.List;
            this.cmbSections.SelectedIndex = -1;

            locations.Populate();
            this.cmbLocations.DataSource = locations.List;
            this.cmbLocations.SelectedIndex = -1;
            //set the days in the combobox so the user won't enter them manually
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
            //checks if the combo box has a selection or not
            if (this.cmbSchedules.SelectedIndex != -1)
            {
                //create an object to store the new information
                Schedule schedule = (Schedule)this.cmbSchedules.SelectedItem;
                int count = 0;
                //for each loop to set the section in the combobox by comparing IDs
                foreach (Section sec in cmbSections.Items)
                {
                    if (sec.getID() == schedule.SectionID)
                    {
                        this.cmbSections.SelectedIndex = count;
                    }
                    count++;
                }
                count = 0;
                //for each loop to set the location in the combobox by comparing IDs
                foreach (Location loc in cmbLocations.Items)
                {
                    if (loc.getID() == schedule.LocationID)
                    {
                        this.cmbLocations.SelectedIndex = count;
                    }
                    count++;
                }
                count = 0;
                //for each loop to set the day 
                foreach (String day in cmbDays.Items)
                {
                    if (day == schedule.Day)
                    {
                        this.cmbDays.SelectedIndex = count;
                    }
                    count++;
                }
                //setting the text boxes directly
                this.txtTime.Text = schedule.Time.ToString();
                this.txtDuration.Text = schedule.Duration.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clearing all the comboboxes and textboxes
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
            //close the form
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //foreach loop that checks all controls and whether if they are empty or not.
            bool isEmpty = false;
            foreach (Control ctl in this.Controls.OfType<TextBox>())
            {
                if (ctl.Text == "" || ctl.Text == null)
                {
                    isEmpty = true;
                }
            }
            if (isEmpty == false)
            {
                //saving the new and old properties from the textboxes to be compared
                Schedule sch = (Schedule)this.cmbSchedules.SelectedItem;
                Section section = (Section)this.cmbSections.SelectedItem;
                string newSID = section.getID();
                string oldSID = sch.SectionID;
                Location location = (Location)this.cmbLocations.SelectedItem;
                string newLID = location.getID();
                string oldLID = sch.LocationID;
                string oldDay = sch.Day;
                string newDay = cmbDays.SelectedItem.ToString();
                string oldDuration = sch.Duration;
                string newDuration = this.txtDuration.Text.ToString();
                string oldTime = sch.Time;
                string newTime = this.txtTime.Text.ToString();
                //checks if the section ID, day, duration or time have been changed in orderd to check for doube scheduling with the new information
                if (newSID != oldSID || oldDay != newDay || newDuration != oldDuration
                    || newTime != oldTime)
                {
                    sch.SectionID = newSID;
                    sch.Time = newTime;
                    Boolean isValid = true;
                    //checks if the duration enters is valid by comparing each character and setting a boolean to false
                    foreach (char c in newDuration.ToString())
                    {
                        if (c < '0' || c > '9')
                        {
                            isValid = false;
                        }
                    }
                    //assigns the duration if it is valid and assign a 0 if not
                    if (isValid)
                    {
                        sch.Duration = newDuration;
                    }
                    else
                    {
                        sch.Duration = "0";
                        MessageBox.Show("Duration entered is invalid.");
                    }
                    sch.Day = newDay;
                    //loop to check if the instructor is busy during the whole schedule. Using the start time and the duration.
                    Boolean chkInstructor = false;
                    int checkTime = Convert.ToInt32(sch.Time);
                    int schDuration = Convert.ToInt32(sch.Duration);
                    while (schDuration >= 1 & !chkInstructor)
                    {
                        //call the exist method with each time a new time during the duration of the schedules
                        chkInstructor = schedules.Exist("Section", "Schedule.SectionID", "Section.SectionID", "Day", "'" + sch.Day.ToString() + "'",
                        "Time", checkTime.ToString(), "Section.instructorID", section.InstructorID.ToString());
                        checkTime++;
                        schDuration--;
                    }
                    if (!chkInstructor)
                    {
                        //checks if the location is busy at the time and day
                        Boolean chkLocation = schedules.Exist("Day", sch.Day.ToString(), "Time",
                            sch.Time.ToString(), "LocationID", sch.LocationID.ToString());
                        if (!chkLocation)
                        {
                            //if all conditions are satified, check for the capacity
                            if (Convert.ToInt32(section.Capacity) <= Convert.ToInt32(location.Capacity))
                            {
                                //update the schedules by passing the schedule obeject in the method
                                schedules.Update(sch);
                            }
                            // print error messsages if any occured during the runtime
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
                //if the schedule only changed the location id, no need for checking double scheduling
                else if (newLID != oldLID)
                {
                    //check the capacity of the section against the location
                    if (Convert.ToInt32(section.Capacity) <= Convert.ToInt32(location.Capacity))
                    {
                        sch.LocationID = newLID;
                        schedules.Update(sch);
                    }
                }
                //print messages appropiatly
                if (sch.getValid() == true)
                {
                    MessageBox.Show("Schedule have been updated successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not updated.\n" + sch.geterrorMessage());
                }
            }
        }
    }
}
