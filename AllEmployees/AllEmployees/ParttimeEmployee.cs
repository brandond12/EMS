using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class ParttimeEmployee : Employee
    {
        private DateTime dateOfTermination;
        private float hourlyRate;
        private DateTime dateOfHire;

        public ParttimeEmployee()
        {

        }

        public ParttimeEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public ParttimeEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime dateOfHire, DateTime dateOfTermination, float hourlyRate)
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
        public bool SetDateOfTermination(DateTime date)
        {
            return true;
        }

        public bool SetHourlyRate(float rate)
        {
            return true;
        }

        public bool SetDateOfHire(DateTime date)
        {
            return true;
        }

        ////*Getters*//////
        public DateTime GetDateOfTermination()
        {
            return dateOfTermination;
        }

        public float GetHourlyRate()
        {
            return hourlyRate;
        }

        public DateTime GetDateOfHire()
        {
            return dateOfHire;
        }

        //override the ToString to allow easy printing
        public override string ToString()
        {
            return base.ToString();//temp to remoce errors
        }
    }
}
