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

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    if (ctr.Text == "" || ctr.Text is null)
                    {
                        isValid = false;
                    }
                }
            }
            if (isValid)
            {
                Instructor instructor = new Instructor();
                instructor.InstructorID = textBoxID.Text.ToString();
                instructor.FirstName = textBoxFname.Text;
                instructor.LastName = textBoxlName.Text;
                instructor.HireDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                instructor.Password = textBoxPasswd.Text;
                instructorList.Add(instructor);
                if (instructor.getValid())
                {
                    MessageBox.Show("Instructor Added Successfully!");

                }
                else
                {
                    MessageBox.Show(instructor.geterrorMessage());
                }
            } else
            {
                MessageBox.Show("A field is empty");
            }
               


        }

        private void ButtonClear_Click(object sender, EventArgs e)
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

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
