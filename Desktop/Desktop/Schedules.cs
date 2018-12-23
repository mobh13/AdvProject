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
    public partial class Schedules : Form
    {
        public Schedules()
        {
            InitializeComponent();
        }

        private void ButtonAddSchedule_Click(object sender, EventArgs e)
        {
            Form addScheduleForm = new AddSchedule();
            addScheduleForm.Show();
            addScheduleForm.Location = this.Location;
        }

        private void ButtonEditSchedule_Click(object sender, EventArgs e)
        {
            Form editScheduleForm = new EditSchedule();
            editScheduleForm.Show();
            editScheduleForm.Location = this.Location;
        }

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
