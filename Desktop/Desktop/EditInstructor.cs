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
    public partial class EditInstructor : Form
    {
        InstructorList instructorList;
        public EditInstructor()
        {
            InitializeComponent();
        }

        private void EditInstructor_Load(object sender, EventArgs e)
        {
            instructorList = new InstructorList();
            instructorList.Populate();
            PopulateInstructors();
        }

        private void ComboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateInstructors();
        }

        private void PopulateInstructors()
        {
            comboBoxID.DataSource = instructorList.List;
            Instructor instructor = (Instructor)comboBoxID.SelectedItem;
            textBoxFname.Text = instructor.FirstName;
            textBoxlName.Text = instructor.LastName;
            textBoxHdate.Text = instructor.HireDate;
            textBoxPasswd.Text = instructor.Password;
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
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                Instructor instructor = (Instructor)comboBoxID.SelectedItem;
                instructor.FirstName = textBoxFname.Text;
                instructor.LastName = textBoxlName.Text;
                instructor.HireDate = DateTime.Parse(textBoxHdate.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
                instructor.Password = textBoxPasswd.Text;

                instructorList.Update(instructor);
                if (instructor.getValid())
                {
                    MessageBox.Show("Instructor Updated Successfully!");
                    PopulateInstructors();
                }
                else
                {
                    MessageBox.Show("An error has occured");
                }
            } else
            {
                MessageBox.Show("A field is empty");
            }
        }
    }
}
