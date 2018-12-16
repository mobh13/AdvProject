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
    public partial class DeleteTaughtCourse : Form
    {
        public DeleteTaughtCourse()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TaughtCourseList taughtCourses = new TaughtCourseList();

        private void DeleteTaughtCourse_Load(object sender, EventArgs e)
        {
            taughtCourses.Populate();
            this.cmbTaughtID.DataSource = taughtCourses.List;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this taught course?",
               "Delete Notice", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TaughtCourse tCourse = (TaughtCourse)this.cmbTaughtID.SelectedItem;
                taughtCourses.Delete(tCourse);

                if (tCourse.getValid() == true)
                {
                    MessageBox.Show("Schedule has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("An error has occured. record was not added.");
                }
                
            }
        }
    }
}
