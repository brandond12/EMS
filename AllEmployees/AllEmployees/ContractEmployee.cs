using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class ContractEmployee : Employee
    {
        public ContractEmployee()
        {

        }

        public ContractEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public ContractEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime contractStartDate, DateTime contractStopDate, float fixedContractAmount)
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
            return base.ToString();//temp to remoce errors
        }
    }
}
