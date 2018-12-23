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
    public partial class EditLocation : Form
    {
        LocationList locations = new LocationList();
        Location loc;
        public EditLocation()
        {
            InitializeComponent();
        }
         
        void loadLocations()
        {
            locations.Populate();
            this.cmbLocationID.DataSource = locations.List;
        }
        private void EditLocation_Load(object sender, EventArgs e)
        {
            loadLocations();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            loc = (Location) this.cmbLocationID.SelectedItem;
            loc.Name = this.txtName.Text.ToString();
            //checks if the capacity entered is a number
            Boolean isValid = false;
            foreach (char c in this.txtCapacity.Text.ToString())
            {
                if (c < '0' || c > '9')
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
            if (isValid)
            {
                loc.Capacity = this.txtCapacity.Text.ToString();
            }
            else
            {
                loc.Capacity = "0";
                MessageBox.Show("Capacity entered is invalid.");
            }
            
            locations.Update(loc);
            if (loc.getValid() == true)
            {
                MessageBox.Show("Location have been updated successfully.");
            }
            else
            {
                MessageBox.Show("An error has occured. Record was not updated."+
                    "\n"+loc.geterrorMessage());
            }
            loadLocations();
        }

        private void cmbLocationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            loc = (Location)this.cmbLocationID.SelectedItem;
            this.txtName.Text = loc.Name;
            this.txtCapacity.Text = loc.Capacity;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                    txt.Text = "";
            }
            this.cmbLocationID.SelectedIndex = -1;
        }
    }
}
