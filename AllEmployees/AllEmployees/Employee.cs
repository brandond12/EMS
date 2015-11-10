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

        /**
        * \breif default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public Employee()
        {

        }

        /**
        * \breif overloaded constructor. Sets name to inputed names, set all other values to default
        *
        * \details <b>Details</b>
        *
        * \param firstName - <b>string</b> - First Name of employee to add to records
        * \param lastName - <b>string</b> - Last Name of employee to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public Employee(string firstName, string lastName)
        {

        }

        /**
        * \breif overloaded constructor. Sets all values to the values given. no default values
        *
        * \details <b>Details</b>
        *
        * \param firstName - <b>string</b> - First Name of employee to add to records
        * \param lastName - <b>string</b> - Last Name of employee to add to records
        * \param socialInsuranceNumber - <b>int</b> - Social Insurance Number of employee to add to records
        * \param dateOfBirth - <b>DateTime</b> - Date Of Birth of employee to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public Employee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth)
        {

        }

        /**
        * \breif Used to determine in the object contains a valid employee
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dataValid - <b>bool</b> - True if the object contains all data for a valid employee
        */
        public bool Validate()
        {
            return true;//temp to remove errors
        }

        /**
        * \breif Overriden method ToString used to return a formated string of all data
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return employeeString <b>string</b> - the formated string containing all employee data
        */
        public override string ToString()
        {
            return base.ToString();//temp to remoce errors
        }

        ////*Setters*//////
        /**
        * \breif Setter for firstName
        *
        * \details <b>Details</b>
        *
        * \param firstName <b>string</b> - The first name of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetFirstName(string firstName)
        {
            return true;
        }

        /**
        * \breif Setter for lastName
        *
        * \details <b>Details</b>
        *
        * \param lasttName <b>string</b> - The last name of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetLastName(string lastName)
        {
            return true;
        }

        /**
        * \breif Setter for socialInsuranceNumber
        *
        * \details <b>Details</b>
        *
        * \param socialInsuranceNumber <b>int</b> - The social insurance number of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetSocialInsuranceNumber(int socialInsuranceNumber)
        {
            return true;
        }

        /**
        * \breif Setter for dateOfBirth
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The date of birth of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfBirth(DateTime date)
        {
            return true;
        }

        ////*Getter*//////
        /**
        * \breif Getter for firstName
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return firstName <b>string</b>
        */
        public string GetFirstName()
        {
            return firstName;
        }

        /**
        * \breif Getter for lastName
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return lastName <b>string</b>
        */
        public string GetLastName()
        {
            return lastName;
        }

        /**
        * \breif Getter for socialInsuranceNumber
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return socialInsuranceNumber <b>int</b>
        */
        public int GetSocialInsuranceNumber()
        {
            return socialInsuranceNumber;
        }

        /**
        * \breif Getter for dateOfBirth
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dateOfBirth <b>string</b>
        */
        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }
    }
}
