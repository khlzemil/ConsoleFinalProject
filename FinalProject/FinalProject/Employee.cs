using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Employee
    {
        public int id { get; set; }
        private int _id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public RoleType RoleType { get; set; }
        public int Salary { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Employee()
        {
            id = ++_id;
        }
        
        
    }

    public enum RoleType
    {
        ADMIN,
        STAFF
    }
}
