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
    /*
    The Add Instructors class
    Contains all methods for creating an instructor to the Instructors table
    */
    public partial class AddInstructor : Form
    {
        InstructorList instructorList;
        public AddInstructor()
        {
            InitializeComponent();
        }

        //Responsible of filling necessary fields for the adding process
        private void AddInstructor_Load(object sender, EventArgs e)
        {
            instructorList = new InstructorList();
            //Fills the ID text box with the now to be added instructor ID (Last Instructor ID in the table + 1)
            textBoxID.Text = (instructorList.GetMaxID() + 1).ToString();
            //Fills the date text box with the current Time and Date
            textBoxHdate.Text = DateTime.Now.ToString();
        }

        //Responsible of submitting the instructor with all its details to the database
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Check if there is an empty field
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

            //Check if there is an empty field that wasn't put
            if (isValid)
            {
                Instructor instructor = new Instructor();
                //Taking all the details from text boxes (submitted by user) and fill it in an Instructor object
                instructor.InstructorID = textBoxID.Text.ToString();
                instructor.FirstName = textBoxFname.Text;
                instructor.LastName = textBoxlName.Text;
                instructor.HireDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                instructor.Password = textBoxPasswd.Text;
                //Add the instructor
                instructorList.Add(instructor);
                if (instructor.getValid())
                {
                    //Show confirmation message
                    MessageBox.Show("Instructor Added Successfully!");
                    Clear();
                }
                else
                {
                    MessageBox.Show(instructor.geterrorMessage());
                }
            }
            else
            {
                MessageBox.Show("A field is empty");
            }

        }

        //Used to clear all the textboses and refilling required data
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Used to exit the current opened form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            //for loop to clear the controls which are textboxes
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
    }
}
