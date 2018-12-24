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
    The Studetns class
    Contains all methods for opening the forms related to Student functionalities
    */

    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }

        //Instantaites and opens the Add Student form 
        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            Form addStudentForm = new AddStudent();
            addStudentForm.StartPosition = FormStartPosition.CenterScreen;
            addStudentForm.Show();
        }

        //Instantaites and opens the Edit Student form
        private void ButtonEditStudent_Click(object sender, EventArgs e)
        {
            Form editStudentForm = new EditStudent();
            editStudentForm.StartPosition = FormStartPosition.CenterScreen;
            editStudentForm.Show();
        }

        //Instantaites and opens the Delete Student form
        private void ButtonDeleteStudent_Click(object sender, EventArgs e)
        {
            Form deleteStudentForm = new DeleteStudent();
            deleteStudentForm.StartPosition = FormStartPosition.CenterScreen;
            deleteStudentForm.Show();
        }

        //Exit the current form
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Students_Load(object sender, EventArgs e)
        {

        }
    }
}
