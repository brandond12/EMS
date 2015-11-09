using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class FulltimeEmployee : Employee
    {
        public FulltimeEmployee()
        {

        }

        public FulltimeEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public FulltimeEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime dateOfHire, DateTime dateOfTermination, float salary)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth)
        {

        }

        public new bool Validate()
        {
            
            return true;//temp to remove errors
        }

        public override string ToString()
        {
            return base.ToString();//temp to remoce errors
        }
    }
}
