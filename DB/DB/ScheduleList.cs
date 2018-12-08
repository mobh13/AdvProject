using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class ScheduleList : DataList
    {
        public ScheduleList() : base("Schedule", "ScheduleID")
        {
        }

        protected override void GenerateList()
        {
            List.Clear();
            SetDataTableColumns(new Schedule());
            while (Reader.Read())
            {
                Schedule schedule = new Schedule(Reader.GetValue(0).ToString());
                SetValues(schedule);
                List.Add(schedule);
                AddDataTableRow(schedule);
            }
            Reader.Close();
            Connection.Close();
        }
    }
}
