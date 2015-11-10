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

        /**
        * \breif default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public ParttimeEmployee()
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
        public ParttimeEmployee(string firstName, string lastName)
            : base(firstName, lastName)
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
        * \param dateOfHire - <b>DateTime</b> - Date Of Hire of employee to add to records
        * \param dateOfTermination - <b>DateTime</b> - Date Of Termination of employee to add to records
        * \param hourlyRate - <b>float</b> - Hourly Rate of employee to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public ParttimeEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime dateOfHire, DateTime dateOfTermination, float hourlyRate)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth)
        {

        }

        /**
        * \breif Used to determine in the object contains a valid employee
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return  dataValid - <b>bool</b> - True if the object contains all data for a valid employee
        */
        public new bool Validate()
        {
            return true;//temp to remove errors
        }

        /**
        * \breif Used to print all employee data to the consol
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return  n/a
        */
        public void Details()
        {

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
        * \breif Setter for dateOfTermination
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The employees date of termination
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfTermination(DateTime date)
        {
            return true;
        }

        /**
        * \breif Setter for hourlyRate
        *
        * \details <b>Details</b>
        *
        * \param rate <b>float</b> - The employees hourly rate
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetHourlyRate(float rate)
        {
            return true;
        }

        /**
        * \breif Setter for dateOfHire
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The employees date of hire
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfHire(DateTime date)
        {
            return true;
        }

        ////*Getters*//////
        /**
        * \breif Getter for dateOfTermination
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dateOfTermination <b>DateTime</b>
        */
        public DateTime GetDateOfTermination()
        {
            return dateOfTermination;
        }

        /**
        * \breif Getter for hourlyRate
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return hourlyRate <b>float</b>
        */
        public float GetHourlyRate()
        {
            return hourlyRate;
        }

        /**
        * \breif Getter for dateOfHire
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dateOfHire <b>DateTime</b>
        */
        public DateTime GetDateOfHire()
        {
            return dateOfHire;
        }
    }
}
