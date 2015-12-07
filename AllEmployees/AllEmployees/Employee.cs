/*
* FILE   : ContractEmployee.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the file containing the Employee class. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporting;

namespace AllEmployees
{
    /// \class Employee
    ///
    /// \brief <b>Brief Description</b>
    /// The Employee class is used to hold the basic infomation for all types of employees.
    /// This class is the parent to many classes that furthur define different types of employees.
    /// If the constructor creates a invalid employee, a exception is thrown.
    /// All other errors result in a defined return.
    ///
    /// \author <i>Brandon</i>
    public class Employee
    {
        private string firstName;
        private string lastName;
        private int socialInsuranceNumber;
        private DateTime dateOfBirth;
        private string employeeType;

        /**
        * \brief default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public Employee()
        {
            firstName = "";
            lastName = "";
            socialInsuranceNumber = 0;
            dateOfBirth = new DateTime();
            employeeType = "";
        }

        /**
        * \brief overloaded constructor. Sets name to inputed names, set all other values to default
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
            this.firstName = firstName;
            this.lastName = lastName;
            socialInsuranceNumber = 0;
            dateOfBirth = new DateTime();
            employeeType = "";

            //check valid firstName
            foreach (char letter in firstName)
            {
                if (!char.IsLetter(letter) && letter != '\'' && letter != '-')
                {
                    throw new FailedConstructorException();
                }
            }
            //check valid last name
            foreach (char letter in lastName)
            {
                if (!char.IsLetter(letter) && letter != '\'' && letter != '-')
                {
                    throw new FailedConstructorException();
                }
            }

            Logging.Log("Employee", "Employee", "New Employee Created: " + this.ToStringBase());
        }

        /**
        * \brief overloaded constructor. Sets all values to the values given. no default values
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
        public Employee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, string employeeType)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialInsuranceNumber = socialInsuranceNumber;
            this.dateOfBirth = dateOfBirth;
            this.employeeType = employeeType;
            if (this.ValidateBase() != true)
            {
                Logging.Log("Employee", "Employee", "Invalid employee made in constructor");
                throw new FailedConstructorException();
            }
            Logging.Log("Employee", "Employee", "New Employee Created: " + this.ToStringBase());
        }

        /**
        * \brief Used to determine in the object contains a valid employee
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dataValid - <b>bool</b> - True if the object contains all data for a valid employee
        */
        protected bool ValidateBase()
        {
            bool dataValid = true;
            //check valid firstName
            foreach (char letter in firstName)
            {
                if (!char.IsLetter(letter) && letter != '\'' && letter != '-')
                {
                    dataValid = false;
                    Logging.Log("Employee", "ValidateBase", "Invalid First Name - Contains Invalid Characters. Input: " + firstName);
                }
            }
            //check valid last name
            foreach (char letter in lastName)
            {
                if (!char.IsLetter(letter) && letter != '\'' && letter != '-')
                {
                    dataValid = false;
                    Logging.Log("Employee", "ValidateBase", "Invalid Last Name - Contains Invalid Characters. Input: " + lastName);
                }
            }
            //check valid sin
            if (socialInsuranceNumber.ToString().Length != 9 && socialInsuranceNumber != 0)
            {
                dataValid = false;
                Logging.Log("Employee", "ValidateBase", "Invalid Social Insurance Number - Incorrect number of characters. Input: " + socialInsuranceNumber.ToString());
            }
            //check date
            if(DateTime.Compare(dateOfBirth, DateTime.Now) > 0)
            {
                dataValid = false;
                Logging.Log("Employee", "ValidateBase", "Invalid Date of Birth - Birthdate Can Not be in the Future");
            }
             
            //check employeeType
            if (employeeType != "" && employeeType != "FT" && employeeType != "PT" && employeeType != "CT" && employeeType != "SN")
            {
                dataValid = false;
                Logging.Log("Employee", "ValidateBase", "Invalid Employee Type - Types can only be: FT PT CT SN. Input : " + employeeType);
            }
            //check that all needed data is present
            if(lastName.Length == 0 || firstName.Length == 0 || dateOfBirth.Year == 1 || socialInsuranceNumber.ToString().Length == 1)
            {
                dataValid = false;
            }
            return dataValid;
        }

        /**
        * \brief Overriden method ToString used to return a formated string of all data
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return employeeString <b>string</b> - the formated string containing all employee data
        */
        protected string ToStringBase()
        {
            string employeeString = firstName + "|" + lastName + "|" + socialInsuranceNumber + "|" + GetDateOfBirthString() + "|";
            return employeeString;
        }

        ////*Setters*//////
        /**
        * \brief Setter for firstName
        *
        * \details <b>Details</b>
        *
        * \param firstName <b>string</b> - The first name of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetFirstName(string firstName)
        {
            bool dataSaved = true;
            foreach (char letter in firstName)
            {
                if (!char.IsLetter(letter) && letter != '\'' && letter != '-')
                {
                    dataSaved = false;
                    Logging.Log("Employee", "SetFirstName", "Invalid First Name - Contains Invalid Characters. Input: " + firstName);
                }
            }
            if (dataSaved == true)
            {
                Logging.Log("Employee", "SetFirstName", "First Name Changed - From: " + this.firstName + " To: " + firstName);
                this.firstName = firstName;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for lastName
        *
        * \details <b>Details</b>
        *
        * \param lasttName <b>string</b> - The last name of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetLastName(string lastName)
        {
            bool dataSaved = true;
            foreach (char letter in lastName)
            {
                if (!char.IsLetter(letter) && letter != '\'' && letter != '-')
                {
                    dataSaved = false;
                    Logging.Log("Employee", "SetFirstName", "Invalid First Name - Contains Invalid Characters. Input: " + firstName);
                }
            }
            if (dataSaved == true)
            {
                Logging.Log("Employee", "SetLastName", "Last Name Changed - From: " + this.lastName + " To: " + lastName);
                this.lastName = lastName;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for socialInsuranceNumber
        *
        * \details <b>Details</b>
        *
        * \param socialInsuranceNumber <b>int</b> - The social insurance number of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetSocialInsuranceNumber(int socialInsuranceNumber)
        {
            bool dataSaved = true;
            if (socialInsuranceNumber < 0 || (socialInsuranceNumber.ToString().Length != 9 && socialInsuranceNumber != 0))
            {
                dataSaved = false;
                Logging.Log("Employee", "SetSocialInsuranceNumber", "Invalid Social Insurance Number - Incorrect number of characters. Input: " + socialInsuranceNumber.ToString());
            }
            else
            {
                this.socialInsuranceNumber = socialInsuranceNumber;
                Logging.Log("Employee", "SetSocialInsuranceNumber", "Social Insurance Number Changed - From: " + this.socialInsuranceNumber.ToString() + " To: " + socialInsuranceNumber.ToString());
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfBirth using DateTime
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The date of birth of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        protected bool SetDateOfBirthBase(DateTime date)
        {
            Logging.Log("Employee", "SetDateOfBirthBase", "Date of Birth Changed - From: " + String.Format("{0:yyyy-MM-dd}", this.dateOfBirth) + " To: " + String.Format("{0:yyyy-MM-dd}", dateOfBirth));
            dateOfBirth = date;
            return true;
        }

        /**
        * \brief Setter for type of employee
        *
        * \details <b>Details</b>
        *
        * \param employeeType <b>string</b> - The type of the employee. Must be: "FT" "PT" "CT" "SN" or ""
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetEmployeeType(string employeeType)
        {
            bool dataSaved = true;
            if (employeeType == "" || employeeType == "FT" || employeeType == "PT" || employeeType == "CT" || employeeType == "SN")
            {
                Logging.Log("Employee", "SetEmployeeType", "Employee Type Changed - From: " + this.employeeType + " To: " + employeeType);
                this.employeeType = employeeType;
            }
            else
            {
                dataSaved = false;
                Logging.Log("Employee", "ValidateBase", "Invalid Employee Type - Types can only be: FT PT CT SN. Input : " + employeeType);
            }
            return dataSaved;
        }

        ////*Getter*//////
        /**
        * \brief Getter for firstName
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
        * \brief Getter for lastName
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
        * \brief Getter for socialInsuranceNumber
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
        * \brief Getter for dateOfBirth
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

        /**
        * \brief Getter for dateOfBirth that returns formatted string
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dateOfBirth <b>string</b>
        */
        public string GetDateOfBirthString()
        {
            return String.Format("{0:yyyy-MM-dd}", dateOfBirth);
        }

        /**
        * \brief Getter for employeeType
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return employeeType <b>string</b>
        */
        public string GetEmployeeType()
        {
            return employeeType;
        }
    }
}