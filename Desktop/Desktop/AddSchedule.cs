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
        //declaring class level variables to be used throughout the form
        ScheduleList schedules;
        SectionList sections;
        LocationList locations;

        public AddSchedule()
        {
            InitializeComponent();
            schedules = new ScheduleList();
            sections = new SectionList();
            locations = new LocationList();
        }

        private void AddSchedule_Load(object sender, EventArgs e)
        {
            //show the next avaiable id in the text box 
            nextID();
            //populating all sections list and adding their IDs in the combobox
            sections.Populate();
            this.cmbSections.DataSource = sections.List;
            this.cmbSections.SelectedIndex = -1;
            //populating all locations list and adding their IDs in the combobox
            locations.Populate();
            this.cmbLocations.DataSource = locations.List;
            this.cmbLocations.SelectedIndex = -1;
            //adding the days of the week in the system to minimize user input 
            string[] days = { "Sunday", "Monday", "Tuesday", "Wensday", "Thursday", "Friday", "Saturday" };
            foreach (string day in days)
            {
                this.cmbDays.Items.Add(day);
            }
            this.cmbDays.SelectedIndex = -1;
        }
        //this method is used to get the next avaiable ID for the schedule
        void nextID()
        {
            int ID = schedules.GetMaxID() + 1;
            this.txtScheduleID.Text = ID.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        //this method loops through all text boxes and comboboxes to clear them except for id text box
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
            //declare a schedule object to store the information of the schedule
            Schedule sch = new Schedule();
            //setting the properties of the schedule from the infromation provided in the form
            sch.setID(this.txtScheduleID.Text.ToString());
            //using a section object and a location object to access the instructor id from section and capacity from location for validation
            Section section = (Section)this.cmbSections.SelectedItem;
            sch.SectionID = section.getID();
            Location location = (Location)this.cmbLocations.SelectedItem;
            sch.LocationID = location.getID();
            sch.Day = cmbDays.SelectedItem.ToString();
            Boolean isValid = true;
            //checks if the duration enters is valid
            foreach (char c in this.txtDuration.Text.ToString())
            { 
                //if the character is not between 0 and 9, isValid is set to false.
                if (c < '0' || c > '9')
                {
                    isValid = false;
                }
            }
            //if statment to check if the isValid changed in the loop or not
            if (isValid)
            {
                //assiging the value from the text box to the property
                sch.Duration = this.txtDuration.Text.ToString();
            }
            else
            {
                //if input is not valid a default value of 0 will be entered
                sch.Duration = "0";
                //warning message will show to the user
                MessageBox.Show("Duration entered is invalid.");
            }
            sch.Time = this.txtTime.Text.ToString();
            //The below code checks for double scheduling for instructor, location and capacity of the location
            Boolean chkInstructor = false;
            int newTime = Convert.ToInt32(sch.Time);
            int schDuration = Convert.ToInt32(sch.Duration);
            //while loop to check if the instructor is busy in schedule start time and through out the duration as well. to prevent overlapping between two schedules
            while (schDuration >= 1 & !chkInstructor)
            {
                //calls the method for every hour of the schedule. i.e. class starts at 3 and lasts for 2 hourse. The loop will check the hourse 3, 4 and 5
                chkInstructor = schedules.Exist("Section", "Schedule.SectionID", "Section.SectionID", "Day", "'" + sch.Day.ToString() + "'",
                "Time", newTime.ToString(), "Section.instructorID", section.InstructorID.ToString());
                newTime++;
                schDuration--;
            }
            //if instructor has no double scheduling execute code
            if (!chkInstructor)
            {
                //check if location is busy at specific day and time to prevent double scheduling
                Boolean chkLocation = schedules.Exist("Day",sch.Day.ToString(),"Time",
                    sch.Time.ToString(),"LocationID",sch.LocationID.ToString());
                //if locaion has no double scheduling, execute code inside
                if (!chkLocation)
                {
                    //checks for the capacity of the section and the location and if it will fit
                    if (Convert.ToInt32(section.Capacity) <= Convert.ToInt32(location.Capacity))
                    {
                        //if all condition were satified, add the schedule object to the databse
                        schedules.Add(sch);
                        //clear the tet boxes after a seccuessful insertion in the database
                        clear();
                        nextID();
                        //this if statment checks if the execution was successful or not and show a message acoordingly 
                        if (sch.getValid() == true)
                        {
                            MessageBox.Show("Schedule have been added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("An error has occured. Record was not added.");
                        }
                        //the below else statment will show an error message if the conditions were not satified
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
