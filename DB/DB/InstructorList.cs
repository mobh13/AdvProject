using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class InstructorList : DataList
    {
        public InstructorList() : base("INSTRUCTOR", "INSTRUCTORID")
        {
        }

        protected override void GenerateList()
        {
            List.Clear();
            SetDataTableColumns(new Instructor());
            while (Reader.Read())
            {
                Instructor instructor = new Instructor();
                SetValues(instructor);
                List.Add(instructor);
                AddDataTableRow(instructor);
            }
            Reader.Close();
            Connection.Close();
        }
    }
}
