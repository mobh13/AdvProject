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
    public partial class DeleteInstructor : Form
    {
        InstructorList instructorList;
        public DeleteInstructor()
        {
            InitializeComponent();
        }

        private void DeleteInstructor_Load(object sender, EventArgs e)
        {
            instructorList = new InstructorList();
            populateInstructors();
        }

        private void populateInstructors()
        {
            instructorList.Populate();
            comboBoxID.DataSource = null;
            comboBoxID.DataSource = instructorList.List;
            comboBoxID.SelectedIndex = 0;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)comboBoxID.SelectedItem;

            instructorList.Delete(instructor);
            MessageBox.Show("Instructor Deleted Successfully!");
            populateInstructors();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
