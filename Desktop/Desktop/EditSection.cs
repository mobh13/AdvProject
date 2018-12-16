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
    public partial class EditSection : Form
    {
        public EditSection()
        {
            InitializeComponent();
        }
        SectionList sections = new SectionList();
        TaughtCourseList tCourses = new TaughtCourseList();
        InstructorList instructors = new InstructorList();

        private void EditSection_Load(object sender, EventArgs e)
        {
            sections.Populate();
            this.cmbSecID.DataSource = sections.List;
            this.cmbSecID.SelectedIndex = -1;

            instructors.Populate();
            this.cmbInstructor.DataSource = instructors.List;
            this.cmbInstructor.SelectedIndex = -1;

            tCourses.Populate();
            this.cmbTCourse.DataSource = tCourses.List;
            this.cmbTCourse.SelectedIndex = -1;
            this.txtCapacity.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
            foreach (ComboBox cmb in this.Controls.OfType<ComboBox>())
            {
                cmb.SelectedIndex = -1;
            }
        }

        private void cmbSecID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSecID.SelectedIndex != -1)
            {
                Section sec = (Section)this.cmbSecID.SelectedItem;
                int count = 0;
                foreach (Instructor inst in cmbInstructor.Items)
                {
                    if (inst.getID() == sec.InstructorID)
                    {
                        this.cmbInstructor.SelectedIndex = count;
                    }
                    count++;
                }
                count = 0;
                foreach (TaughtCourse tCourse in cmbTCourse.Items)
                {
                    if (tCourse.getID() == sec.TaughtCourseID)
                    {
                        this.cmbTCourse.SelectedIndex = count;
                    }
                    count++;
                }
                this.txtCapacity.Text = sec.Capacity.ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Section sec = (Section)this.cmbSecID.SelectedItem;
            sec.setID(this.cmbSecID.SelectedItem.ToString());
            sec.Capacity = this.txtCapacity.Text.ToString();
            sec.InstructorID = this.cmbInstructor.SelectedItem.ToString();
            sec.TaughtCourseID = this.cmbTCourse.SelectedItem.ToString();
            sections.Update(sec);
            if (sec.getValid() == true)
            {
                MessageBox.Show("Schedule have been updated successfully.");
            }
            else
            {
                MessageBox.Show("An error has occured. record was not updated.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
