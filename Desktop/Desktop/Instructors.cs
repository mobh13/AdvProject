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
    public partial class Instructors : Form
    {
        public Instructors()
        {
            InitializeComponent();
        }

        private void ButtonAddInstructor_Click(object sender, EventArgs e)
        {
            Form addInstructorForm = new AddInstructor();
            addInstructorForm.StartPosition = FormStartPosition.CenterScreen;
            addInstructorForm.Show();
        }

        private void ButtonEditInstructor_Click(object sender, EventArgs e)
        {
            Form editInstructorForm = new EditInstructor();
            editInstructorForm.StartPosition = FormStartPosition.CenterScreen;
            editInstructorForm.Show();
        }

        private void ButtonDeleteInstructor_Click(object sender, EventArgs e)
        {
            Form deleteInstructorForm = new DeleteInstructor();
            deleteInstructorForm.StartPosition = FormStartPosition.CenterScreen;
            deleteInstructorForm.Show();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Instructors_Load(object sender, EventArgs e)
        {

        }
    }
}
