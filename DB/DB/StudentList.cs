using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class StudentList: DataList
	{
		public StudentList() : base("Student", "StudentID")
		{
		}

		protected override void GenerateList()
		{
			List.Clear();
			SetDataTableColumns(new Student());
			while (Reader.Read())
			{
				Student student = new Student(Reader.GetValue(0).ToString());
				SetValues(student);
				List.Add(student);
				AddDataTableRow(student);
			}
			Reader.Close();
			Connection.Close();
		}
	}
}
