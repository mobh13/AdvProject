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
    public partial class AddInstructor : Form
    {
        InstructorList instructorList;
        public AddInstructor()
        {
            InitializeComponent();
        }

        private void AddInstructor_Load(object sender, EventArgs e)
        {
            instructorList = new InstructorList();
            textBoxID.Text = (instructorList.GetMaxID() + 1).ToString();
            textBoxHdate.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Instructor instructor = new Instructor();
            instructor.InstructorID = textBoxID.Text.ToString();
            instructor.FirstName = textBoxFname.Text;
            instructor.LastName = textBoxlName.Text;
            instructor.HireDate = textBoxHdate.Text;
            instructor.Password = textBoxPasswd.Text;
            instructorList.Add(instructor);
            MessageBox.Show("Instructor Added Successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
            textBoxID.Text = (instructorList.GetMaxID() + 1).ToString();
            textBoxHdate.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
