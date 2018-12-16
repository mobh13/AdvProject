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
    public partial class AddSection : Form
    {
        SectionList sections = new SectionList();
        TaughtCourseList tCourses = new TaughtCourseList();
        InstructorList instructors = new InstructorList();
        public AddSection()
        {
            InitializeComponent();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Name != "txtSecID")
                {
                    txt.Text = "";
                }
            }
            foreach (ComboBox cmb in this.Controls.OfType<ComboBox>())
            {
                cmb.SelectedIndex = -1;
            }
        }
        void nextID()
        {
            int ID = sections.GetMaxID() + 1;
            this.txtSecID.Text = ID.ToString();
        }
        private void AddSection_Load(object sender, EventArgs e)
        {
            nextID();
            instructors.Populate();
            this.cmbInstructor.DataSource = instructors.List;
            this.cmbInstructor.SelectedIndex = -1;

            tCourses.Populate();
            this.cmbTCourse.DataSource = tCourses.List;
            this.cmbTCourse.SelectedIndex = -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Section sec = new Section();
            sec.setID(this.txtSecID.Text.ToString());
            sec.InstructorID = this.cmbInstructor.SelectedItem.ToString();
            sec.TaughtCourseID = this.cmbTCourse.SelectedItem.ToString();
            sec.Capacity = this.txtCapacity.Text.ToString();
            sections.Add(sec);
            if (sec.getValid() == true)
            {
                MessageBox.Show("Section have been added successfully.");
            }
            else
            {
                MessageBox.Show("An error has occured. Record was not added.");
            }
            nextID();
            clear();
        }
    }
}
