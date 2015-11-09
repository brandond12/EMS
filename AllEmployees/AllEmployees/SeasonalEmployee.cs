using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class SeasonalEmployee : Employee
    {
        public SeasonalEmployee()
        {

        }

        public SeasonalEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public SeasonalEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, string season, float piecePay)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth)
        {

        }

        public new bool Validate()
        {
            return true;//temp to remove errors
        }

        public void Details()
        {

        }

        public override string ToString()
        {
            return base.ToString();//temp to remove errors
        }
    }
}
