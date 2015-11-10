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
        public bool ValidateBase()
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
        * \brief Used to print all employee data to the consol
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return  n/a
        */
        public string BaseDetails()
        {
            string stringOutput = "Employee Type: Contract\nName: " + GetFirstName() + " " + GetLastName() +
                "\nSocial Insurance Number: " + GetSocialInsuranceNumber().ToString().Substring(0, 5) + " " + GetSocialInsuranceNumber().ToString().Substring(5, 4) +
                "\nDate of Birth: " + String.Format("{0:yyyy-MM-dd}", GetDateOfBirth());
            return stringOutput;
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
        public string ToStringBase()
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
            return true;
        }

        /**
        * \brief Setter for dateOfBirth
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
    }
}
