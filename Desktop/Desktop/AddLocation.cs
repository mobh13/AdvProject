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
        LocationList locations = new LocationList();
        public AddLocation()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Location loc = new Location();
            loc.setID(this.txtLocationID.Text.ToString());
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
           
            locations.Add(loc);
            if (loc.getValid() == true)
            {
                MessageBox.Show("Location have been added successfully.");
                clear();
                getNextID();
            }
            else
            {
                MessageBox.Show("An error has occured. Record was not added.\n"+loc.geterrorMessage());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
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
        void getNextID()
        {
            int id = locations.GetMaxID() + 1;
            this.txtLocationID.Text = id.ToString();
        }
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
