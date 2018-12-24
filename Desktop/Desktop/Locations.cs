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
    The Locations class
    Contains all methods for opening the forms related to Locations functionalities
    */
    public partial class Locations : Form
    {
        public Locations()
        {
            InitializeComponent();
        }
        //Instantaites and opens the Add Location form 
        private void ButtonAddLocation_Click(object sender, EventArgs e)
        {
            Form addLocationForm = new AddLocation();
            addLocationForm.Show();
            addLocationForm.Location = this.Location;
        }
        //Instantaites and opens the Edit Location form 
        private void ButtonEditLocation_Click(object sender, EventArgs e)
        {
            Form editLocationForm = new EditLocation();
            editLocationForm.Show();
            editLocationForm.Location = this.Location;
        }
        //Instantaites and opens the Exit Location form 
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Locations_Load(object sender, EventArgs e)
        {
        }
        }
}
