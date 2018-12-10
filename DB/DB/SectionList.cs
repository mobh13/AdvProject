using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class SectionList : DataList
    {
        public SectionList() : base("Section", "SectionID")
        {
        }

        protected override void GenerateList()
        {
            List.Clear();
            SetDataTableColumns(new Section());
            while (Reader.Read())
            {
                Section section = new Section(Reader.GetValue(0).ToString());
                SetValues(section);
                List.Add(section);
                AddDataTableRow(section);
            }
            Reader.Close();
            Connection.Close();
        }
    }
}
