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
    public partial class Instructors : Form
    {
        public Instructors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addInstructorForm = new AddInstructor();
            addInstructorForm.Show();
            addInstructorForm.Location = this.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form editInstructorForm = new EditInstructor();
            editInstructorForm.Show();
            editInstructorForm.Location = this.Location;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form deleteInstructorForm = new DeleteInstructor();
            deleteInstructorForm.Show();
            deleteInstructorForm.Location = this.Location;

        }
    }
}
