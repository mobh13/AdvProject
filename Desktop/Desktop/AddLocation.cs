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
    public partial class AddLocation : Form
    {
        //declaring a class level variable and instantiating it in the constructor. To handle the locations table.
        LocationList locations;
        public AddLocation()
        {
            InitializeComponent();
            locations = new LocationList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //declaring a locaiton object to store the information from the form
            Location loc = new Location();
            //seting the name and ID from the text boxes in the form
            loc.setID(this.txtLocationID.Text.ToString());
            loc.Name = this.txtName.Text.ToString();
            //checks if the capacity entered is a number
            Boolean isValid = true;
            //a foreach loop for every character in the string entered
            foreach (char c in this.txtCapacity.Text.ToString())
            {
                //if the character is not between 0 and 9, isValid is set to false.
                if (c < '0' || c > '9')
                {
                    isValid = false;
                }
            }
            //if statment to check if the isValid changed in the loop or not
            if (isValid)
            {
                //assiging the value from the text box to the property
                loc.Capacity = this.txtCapacity.Text.ToString();
            }
            else
            {
                //if input is not valid a default value of 0 will be entered
                loc.Capacity = "0";
                //warning message will show to the user
                MessageBox.Show("Capacity entered is invalid.");
            }
           //after populating the location object, the item will be passed to the Add();
            locations.Add(loc);
            //clear the fields and get the next ID for the next location to be added
            clear();
            getNextID();
            //this if statment checks if the execution was successful or not and show a message acoordingly 
            if (loc.getValid() == true)
            {
                MessageBox.Show("Location have been added successfully.");
            }
            else
            {
                MessageBox.Show("An error has occured. Record was not added.\n"+loc.geterrorMessage());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //call the clear method to clear boxes
            clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLocation_Load(object sender, EventArgs e)
        {
            getNextID();
        }
        //this method is used to get the next avaiable ID for the location
        void getNextID()
        {
            int id = locations.GetMaxID() + 1;
            this.txtLocationID.Text = id.ToString();
        }
        //this method loops through all text boxes and clears them except for id text box
        void clear()
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Name != "txtLocationID")
                {
                    txt.Text = "";
                }
            }
        }
    }
}
