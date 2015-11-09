using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class FulltimeEmployee : Employee
    {
        private DateTime dateOfHire;
        private DateTime dateOfTermination;
        private float salary;

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

        //prints all employee info to the screen
        public void Details()
        {

        }

        ////*Setters*//////
        public bool SetDateOfHire(DateTime date)
        {
            return true;
        }

        public bool SetDateOfTermination(DateTime date)
        {
            return true;
        }

        public bool SetSalary(float salary)
        {
            return true;
        }

        ////*Getter*//////
        public DateTime GetDateOfHire()
        {
            return dateOfHire;
        }

        public DateTime GetDateOfTermination()
        {
            return dateOfTermination;
        }

        public float GetSalary()
        {
            return salary;
        }

        //override the ToString to allow easy printing
        public override string ToString()
        {
            return base.ToString();//temp to remoce errors
        }
    }
}
