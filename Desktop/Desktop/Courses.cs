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
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addCourseForm = new AddCourse();
            addCourseForm.StartPosition = FormStartPosition.CenterScreen;
            addCourseForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form editCourseForm = new EditCourse();
            editCourseForm.StartPosition = FormStartPosition.CenterScreen;
            editCourseForm.Show();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
