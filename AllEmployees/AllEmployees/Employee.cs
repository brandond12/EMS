using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private int socialInsuranceNumber;
        private DateTime dateOfBirth;

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

        ////*Setters*//////
        public bool SetFirstName(string firstName)
        {
            return true;
        }

        public bool SetLastName(string lastName)
        {
            return true;
        }

        public bool SetSocialInsuranceNumber(int socialInsuranceNumber)
        {
            return true;
        }

        public bool SetDateOfBirth(DateTime date)
        {
            return true;
        }

        ////*Getter*//////
        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public int GetSocialInsuranceNumber()
        {
            return socialInsuranceNumber;
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        //override the ToString to allow easy printing
        public override string ToString()
        {
            return base.ToString();//temp to remoce errors
        }
    }
}
