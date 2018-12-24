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
    /*
    The Courses class
    Contains all methods for opening the forms related to Course functionalities
    */
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
        }

        //Instantaites and opens the Add Course form 
        private void ButtonAddCourse_Click(object sender, EventArgs e)
        {
            Form addCourseForm = new AddCourse();
            addCourseForm.StartPosition = FormStartPosition.CenterScreen;
            addCourseForm.Show();
        }

        //Instantaites and opens the Edit Course form 
        private void ButtonEditCourse_Click(object sender, EventArgs e)
        {
            Form editCourseForm = new EditCourse();
            editCourseForm.StartPosition = FormStartPosition.CenterScreen;
            editCourseForm.Show();

        }

        //Exit the current page
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Courses_Load(object sender, EventArgs e)
        {

        }
    }
}
