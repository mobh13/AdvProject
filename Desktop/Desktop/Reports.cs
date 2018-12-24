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
    The Reports class
    Contains all methods for opening the forms related to wanted Reports functionalities
    */
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        //Instantaites and opens the Total Scheduled Hours form
        private void TotalScheduledHoursBtn_Click(object sender, EventArgs e)
        {
            Form totalHoursForm = new TotalHours();
            totalHoursForm.Show();
            totalHoursForm.Location = this.Location;
        }

        //Instantaites and opens the Average Grades form
        private void AverageGradesBtn_Click(object sender, EventArgs e)
        {
            Form averageGradeForm = new AverageGrade();
            averageGradeForm.Show();
            averageGradeForm.Location = this.Location;
        }

        //Exit this opened form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
