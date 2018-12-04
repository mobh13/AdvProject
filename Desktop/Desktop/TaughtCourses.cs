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
    public partial class TaughtCourses : Form
    {
        public TaughtCourses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form addTaughtCourseForm = new AddTaughtCourse();
            addTaughtCourseForm.Show();
            addTaughtCourseForm.Location = this.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form editTaughtCourseForm = new EditTaughtCourse();
            editTaughtCourseForm.Show();
            editTaughtCourseForm.Location = this.Location;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form deleteTaughtCourseForm = new DeleteTaughtCourse();
            deleteTaughtCourseForm.Show();
            deleteTaughtCourseForm.Location = this.Location;
        }
    }
}
