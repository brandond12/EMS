using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class ContractEmployee : Employee
    {
        private DateTime contractStartDate;
        private DateTime contractStopDate;
        private float fixedContractAmount;

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

        //prints all employee info to the screen
        public void Details()
        {

        }

        ////* Setters *////
        public bool SetContractStartDate(DateTime date)
        {
            return true;
        }

        public bool SetContractSopDate(DateTime date)
        {
            return true;
        }

        public bool SetFixedContractAmount(float date)
        {
            return true;
        }

        ////* Getter *////
        public DateTime GetContractStartDate()
        {
            return contractStartDate;
        }

        public DateTime GetContractStopDate()
        {
            return contractStopDate;
        }

        public float GetFixedContractAmount()
        {
            return fixedContractAmount;
        }

        //override the ToString to allow easy printing
        public override string ToString()
        {
            return base.ToString();//temp to remoce errors
        }
    }
}
