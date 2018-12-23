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

        private void ButtonAddLocation_Click(object sender, EventArgs e)
        {
            Form addLocationForm = new AddLocation();
            addLocationForm.Show();
            addLocationForm.Location = this.Location;
        }

        private void ButtonEditLocation_Click(object sender, EventArgs e)
        {
            Form editLocationForm = new EditLocation();
            editLocationForm.Show();
            editLocationForm.Location = this.Location;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Locations_Load(object sender, EventArgs e)
        {

        }
    }
}
