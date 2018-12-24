using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    /*
    The Schedules class
    Contains all methods for opening the forms related to Schedules functionalities
    */
    public partial class Schedules : Form
    {
        public Schedules()
        {
            InitializeComponent();
        }
        //Instantaites and opens the Add Schedule form 
        private void ButtonAddSchedule_Click(object sender, EventArgs e)
        {
            Form addScheduleForm = new AddSchedule();
            addScheduleForm.Show();
            addScheduleForm.Location = this.Location;
        }
        //Instantaites and opens the Edit Schedule form 
        private void ButtonEditSchedule_Click(object sender, EventArgs e)
        {
            Form editScheduleForm = new EditSchedule();
            editScheduleForm.Show();
            editScheduleForm.Location = this.Location;
        }
        //Instantaites and opens the Delete Schedule form 
        private void ButtonDeleteSchedule_Click(object sender, EventArgs e)
        {
            Form deleteScheduleForm = new DeleteSchedule();
            deleteScheduleForm.Show();
            deleteScheduleForm.Location = this.Location;
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Schedules_Load(object sender, EventArgs e)
        {

        }
    }
}
