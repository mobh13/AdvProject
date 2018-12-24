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
    public partial class DeleteSchedule : Form
    {
        //class level variable to be used in the form methods
        ScheduleList schedules;

        public DeleteSchedule()
        {
            InitializeComponent();
            schedules = new ScheduleList();
        }

        private void DeleteSchedule_Load(object sender, EventArgs e)
        {
            //populating all the schedules in the combobox
            schedules.Populate();
            this.cmbSchedules.DataSource = schedules.List;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closing the form
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //prompts a validatin message to make sure to delete the schedule
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the schedule?", 
                "Delete Notice", MessageBoxButtons.YesNo);
            //if user enters yes, the schedule is deleted from the database
            if (dialogResult == DialogResult.Yes)
            {
                //creates an object from the selected combobox and passed to the delete method
                Schedule sch = (Schedule) this.cmbSchedules.SelectedItem;
                schedules.Delete(sch);
                if (sch.getValid())
                {
                    MessageBox.Show("Schedule has been deleted successfully!");
                }
                else
                {
                    MessageBox.Show("There was en error. Record have not been deleted.\n"+sch.geterrorMessage());
                }
               
            }
        }
    }
}
