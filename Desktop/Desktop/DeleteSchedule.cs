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
        ScheduleList schedules = new ScheduleList();

        public DeleteSchedule()
        {
            InitializeComponent();
        }

        private void DeleteSchedule_Load(object sender, EventArgs e)
        {
            schedules.Populate();
            this.cmbSchedules.DataSource = schedules.List;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the schedule?", 
                "Delete Notice", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Schedule sch = (Schedule) this.cmbSchedules.SelectedItem;
                schedules.Delete(sch);

                MessageBox.Show("Schedule has been deleted successfully!");
            }
        }
    }
}
