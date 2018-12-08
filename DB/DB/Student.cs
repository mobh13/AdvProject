using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class Student:Item
	{
		private string lastName;
		private string firstName;
		private string enrollmentDate;
		private string password;

		public Student(string id) : base(id)
		{

		}

		public Student()
		{

		}

		public string StudentID { get => base.getID(); set => base.setID(value); }
		public string LastName { get => lastName; set => lastName = value; }
		public string FirstName { get => firstName; set => firstName = value; }
		public string EnrollmentDate { get => enrollmentDate; set => enrollmentDate = value; }
		public string Password { get => password; set => password = value; }

		public override string ToString()
		{
			return StudentID;
		}
	}
}
