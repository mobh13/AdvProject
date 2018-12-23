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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form addSectionForm = new AddSection();
            addSectionForm.Show();
            addSectionForm.Location = this.Location;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Form editSectionForm = new EditSection();
            editSectionForm.Show();
            editSectionForm.Location = this.Location;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Form deleteSectionForm = new DeleteSection();
            deleteSectionForm.Show();
            deleteSectionForm.Location = this.Location;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
