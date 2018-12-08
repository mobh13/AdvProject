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
            this.comboBox4.DataSource = locations.List;
        }
        private void EditLocation_Load(object sender, EventArgs e)
        {
            loadLocations();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             loc = (Location) this.comboBox4.SelectedItem;
            loc.Name = this.textBox2.Text.ToString();
            loc.Capacity = this.textBox5.Text.ToString();
            locations.Update(loc);
            loadLocations();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
             loc = (Location)this.comboBox4.SelectedItem;
            this.textBox5.Text = loc.Name;
            this.textBox2.Text = loc.Capacity;
        }
    }
}
