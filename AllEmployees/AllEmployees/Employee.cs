using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class Employee
    {
        public Employee()
        {

        }

        public Employee(string firstName, string lastName)
        {

        }

        public Employee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth)
        {

        }

        public bool Validate()
        {
            return true;//temp to remove errors
        }

        public override string ToString()
        {
            return base.ToString();//temp to remoce errors
        }
    }
}
