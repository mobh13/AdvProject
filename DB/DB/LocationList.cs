using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class LocationList : DataList
    {
        public LocationList() : base("Location", "LocationID")
        {
        }

        protected override void GenerateList()
        {
            List.Clear();
            SetDataTableColumns(new Location());
            while (Reader.Read())
            {
                Location location = new Location(Reader.GetValue(0).ToString());
                SetValues(location);
                List.Add(location);
                AddDataTableRow(location);
            }
            Reader.Close();
            Connection.Close();
        }
    }
}
