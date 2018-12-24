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
        //class variables declared
        LocationList locations;
        Location loc;
        public EditLocation()
        {
            InitializeComponent();
            locations = new LocationList();
        }
         //a method that populates and reloads the list of locations
        void loadLocations()
        {
            locations.Populate();
            this.cmbLocationID.DataSource = locations.List;
        }
        private void EditLocation_Load(object sender, EventArgs e)
        {
            //call the method to populate the list
            loadLocations();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the form
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //foreach loop that checks all controls and whether if they are empty or not.
            bool isEmpty =  false;
            foreach (Control ctl in this.Controls.OfType<TextBox>())
            {
                    if (ctl.Text == "" || ctl.Text == null)
                    {
                        isEmpty = true;
                    }
            }
            //checks the boolean and see if any controls are empty
            if (isEmpty == false)
            {
                //set the selected location item in the location object
                loc = (Location)this.cmbLocationID.SelectedItem;
                //assigngs the varibles
                loc.Name = this.txtName.Text.ToString();
                //checks if the capacity entered is a number
                Boolean isValid = true;
                //loops each character in the string to check if only contains numbers
                foreach (char c in this.txtCapacity.Text.ToString())
                {
                    //checks if a character is a number
                    if (c < '0' || c > '9')
                    {
                        isValid = false;
                    }
                }
                //if the input is correct
                if (isValid)
                {
                    //set the capacity property
                    loc.Capacity = this.txtCapacity.Text.ToString();
                }
                else
                {
                    //if invalid  input, set the default value which is 0
                    loc.Capacity = "0";
                    MessageBox.Show("Capacity entered is invalid.");
                }
                //pass the location object to the update method
                locations.Update(loc);
                //checks if the execution was a success and prints a message appropiatly
                if (loc.getValid() == true)
                {
                    MessageBox.Show("Location have been updated successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. Record was not updated." +
                        "\n" + loc.geterrorMessage());
                }
                //reloads the locations to update the list with the new infromation
                loadLocations();
            }
            else
            {
                MessageBox.Show("Cannot leave an empty control.");
            }
        }

        private void cmbLocationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbLocationID.SelectedIndex != -1)
            {
                //displays the information of the selected location
                loc = (Location)this.cmbLocationID.SelectedItem;
                this.txtName.Text = loc.Name;
                this.txtCapacity.Text = loc.Capacity;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //loops the text boxes and clear them all, also, set the index of combobox to -1
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                    txt.Text = "";
            }
            this.cmbLocationID.SelectedIndex = -1;
        }
    }
}
