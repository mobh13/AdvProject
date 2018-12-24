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
    The TaughtCourses class
    Contains all methods for opening the forms related to TaughtCourses functionalities
    */
    public partial class TaughtCourses : Form
    {
        public TaughtCourses()
        {
            InitializeComponent();
        }

        //Instantaites and opens the Add TaughtCourses form 
        private void AddTaughtCourse_Click(object sender, EventArgs e)
        {
            Form addTaughtCourseForm = new AddTaughtCourse();
            addTaughtCourseForm.Show();
            addTaughtCourseForm.Location = this.Location;
        }
        //Instantaites and opens the Edit TaughtCourses form 
        private void EditTaughtCourse_Click(object sender, EventArgs e)
        {
            Form editTaughtCourseForm = new EditTaughtCourse();
            editTaughtCourseForm.Show();
            editTaughtCourseForm.Location = this.Location;
        }
        //Instantaites and opens the Delete TaughtCourses form 
        private void DeleteTaughtCourse_Click(object sender, EventArgs e)
        {
            Form deleteTaughtCourseForm = new DeleteTaughtCourse();
            deleteTaughtCourseForm.Show();
            deleteTaughtCourseForm.Location = this.Location;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaughtCourses_Load(object sender, EventArgs e)
        {

        }
    }
}
