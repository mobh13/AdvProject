using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Instructor : Item
    {
        private string lastName;
        private string firstName;
        private string hireDate;
        private string password;

        public Instructor(string id) : base(id)
        {

        }

        public Instructor()
        {

        }

        public string InstructorID { get => base.getID(); set => base.setID(value); }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string HireDate { get => hireDate; set => hireDate = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return InstructorID;
        }
    }
}
