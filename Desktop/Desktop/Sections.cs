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
    public partial class Sections : Form
    {
        public Sections()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addSectionForm = new AddSection();
            addSectionForm.Show();
            addSectionForm.Location = this.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form editSectionForm = new EditSection();
            editSectionForm.Show();
            editSectionForm.Location = this.Location;

        }
    }
}
