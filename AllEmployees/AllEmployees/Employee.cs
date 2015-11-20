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

namespace AllEmployees
{
    /// \class Employee
    ///
    /// \brief <b>Brief Description</b>
    /// The Employee class is used to hold the basic infomation for all types of employees
    /// This class is the parent to many classes that furthur define different types of employees
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
            if (this.ValidateBase() != true)
            {
                throw new FailedConstructorException();
            }
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
                throw new FailedConstructorException();
            }
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
                }
            }
            //check valid last name
            foreach (char letter in lastName)
            {
                if (!char.IsLetter(letter) && letter != '\'' && letter != '-')
                {
                    dataValid = false;
                }
            }
            //check valid sin
            if (socialInsuranceNumber.ToString().Length != 9 && socialInsuranceNumber.ToString().Length != 0)
            {
                dataValid = false;
            }
            //DateTime will never be invalid
            //check employeeType
            if (employeeType != "" && employeeType != "FT" && employeeType != "PT" && employeeType != "CT" && employeeType != "SN")
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
            string employeeString = firstName + "|" + lastName + "|" + socialInsuranceNumber + "|" + dateOfBirth.Year + "-" + dateOfBirth.Month + "-" + dateOfBirth.Day + "|";
            return employeeString;//temp to remoce errors
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
                }
            }
            if (dataSaved == true)
            {
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
                }
            }
            if (dataSaved == true)
            {
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
            if(socialInsuranceNumber < 0)
            {
                dataSaved = false;
            }
            else
            {
                this.socialInsuranceNumber = socialInsuranceNumber;
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
        public bool SetDateOfBirth(DateTime date)
        {
            dateOfBirth = date;
            return true;
        }

        /**
        * \brief Setter for dateOfBirth with String
        *
        * \details <b>Details</b>
        *
        * \param date <b>string</b> - The date of birth of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfBirth(string date)
        {
            bool dataSaved = true;
            int year = 0;
            int month = 0;
            int day = 0;
            try
            {
                year = Int32.Parse(date.Substring(0, 4));
                month = Int32.Parse(date.Substring(5, 2));
                day = Int32.Parse(date.Substring(8, 2));
                DateTime newDateOfBirth = new DateTime(year, month, day);
                dateOfBirth = newDateOfBirth;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfBirth with ints
        *
        * \details <b>Details</b>
        *
        * \param year <b>int</b> - The year of birth of the employee
        * \param month <b>int</b> - The month of birth of the employee
        * \param day <b>int</b> - The day of birth of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfBirth(int year, int month, int day)
        {
            bool dataSaved = true;

            try
            {
                DateTime newcontractStartDate = new DateTime(year, month, day);
                dateOfBirth = newcontractStartDate;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
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
                this.employeeType = employeeType;
            }
            else
            {
                dataSaved = false;
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