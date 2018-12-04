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
            addCourseForm.Show();
            addCourseForm.Location = this.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form editCourseForm = new EditCourse();
            editCourseForm.Show();
            editCourseForm.Location = this.Location;

        }
    }
}
