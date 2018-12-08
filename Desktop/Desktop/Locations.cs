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
    public partial class Locations : Form
    {
        public Locations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addLocationForm = new AddLocation();
            addLocationForm.Show();
            addLocationForm.Location = this.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form editLocationForm = new EditLocation();
            editLocationForm.Show();
            editLocationForm.Location = this.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
