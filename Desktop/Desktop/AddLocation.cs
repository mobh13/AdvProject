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
            int id = locations.GetMaxID() + 1;
            this.textBox1.Text =  id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Location loc = new Location();
            loc.setID(this.textBox1.Text.ToString());
            loc.Name = this.textBox5.Text.ToString();
            loc.Capacity = this.textBox2.Text.ToString();
            locations.Add(loc);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Name != "textBox1")
                {
                    txt.Text = "";
                }
              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
