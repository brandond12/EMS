/*
* FILE   : ContractEmployee.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the file containing the ContractEmployee class. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// \class ContractEmployee
    ///
    /// \brief <b>Brief Description</b>
    /// The Contract Employee class is used to store and manage data about a employee who is hired on a contract.
    /// This class is a child to Employee class. It adds the contract start and stop date and the amout the employee is payed for the contract.
    /// The base classes Social Insurance Number is treated as a buisness number for this class.
    /// If the constructor creates a invalid employee, a exception is thrown.
    /// All other errors result in a defined return.
    ///
    /// \author <i>Brandon</i>

    public class ContractEmployee : Employee
    {
        private DateTime contractStartDate;
        private DateTime contractStopDate;
        private float fixedContractAmount;

        /**
        * \brief default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public ContractEmployee()
            : base()
        {
            contractStartDate = new DateTime();
            contractStopDate = new DateTime();
            fixedContractAmount = 0;
            SetEmployeeType("CT");
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
        public ContractEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            contractStartDate = new DateTime();
            contractStopDate = new DateTime();
            fixedContractAmount = 0;
            SetEmployeeType("CT");
            if (this.Validate() != true)
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
        * \param contractStartDate - <b>DateTime</b> - Contract Start Date of employee contract to add to records
        * \param contractStopDate - <b>DateTime</b> - Contract Stop Date of employee contract to add to records
        * \param fixedContractAmount - <b>float</b> - Fixed Contract Amount of employee contract to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public ContractEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime contractStartDate, DateTime contractStopDate, float fixedContractAmount)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth, "CT")
        {
            this.contractStartDate = contractStartDate;
            this.contractStopDate = contractStopDate;
            this.fixedContractAmount = fixedContractAmount;
            if (this.Validate() != true)
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
        * \return  dataValid - <b>bool</b> - True if the object contains all data for a valid employee
        */
        public bool Validate()
        {
            bool dataValid = this.ValidateBase();

            if (fixedContractAmount < 0)
            {
                dataValid = false;
            }

            if (int.Parse(GetSocialInsuranceNumber().ToString().Substring(0, 2)) != int.Parse(GetDateOfBirthString().Substring(2, 2)))
            {
                dataValid = false;
            }
            return dataValid;
        }

        /**
        * \brief Used to create a formated string of all employee to be printed to the screen
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return  userInfo <b>string</b> - formatted string of employee data
        */
        public string Details()
        {
            return ("Employee Type: Contract\nName: " + GetFirstName() + " " + GetLastName() +
                "\nBuisness Number: " + GetSocialInsuranceNumber().ToString().Substring(0, 5) + " " + GetSocialInsuranceNumber().ToString().Substring(5, 4) +
                "\nDate of Birth: " + GetDateOfBirthString() +
                "\nContract Start Date: " + GetContractStartDateString() +
                "\nContract Stop Date: " + GetContractStopDateString() +
                "\nFixed Contract Amount: " + fixedContractAmount.ToString());
        }

        /**
        * \brief Overriden method ToString used to return a formated string of all data about employee
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return employeeString <b>string</b> - the formated string containing all employee data
        */
        public override string ToString()
        {
            string outputString = "CT" + "|" + 
                ToStringBase() + 
                GetContractStopDateString() + "|" + 
                GetContractStartDateString() + "|" + 
                fixedContractAmount.ToString();
            return outputString;
        }

        ////* Setters *////
        /**
        * \brief Setter for contractStartDate from DateTime
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The start date of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStartDate(DateTime date)
        {
            bool dataSaved = true;
            contractStartDate = date;
            return dataSaved;
        }

        /**
        * \brief Setter for contractStartDate from String
        *
        * \details <b>Details</b>
        *
        * \param date <b>string</b> - The start date of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStartDate(string date)
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

                DateTime newcontractStartDate = new DateTime(year, month, day);
                contractStartDate = newcontractStartDate;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for contractStartDate from ints
        *
        * \details <b>Details</b>
        *
        * \param year <b>int</b> - The start year of the employees contract
        * \param month <b>int</b> - The start month of the employees contract
        * \param day <b>int</b> - The start day of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStartDate(int year, int month, int day)
        {
            bool dataSaved = true;

            try
            {
                DateTime newcontractStartDate = new DateTime(year, month, day);
                contractStartDate = newcontractStartDate;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for contractStopDate from DateTime
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The stop date of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStopDate(DateTime date)
        {
            bool dataSaved = true;
            contractStopDate = date;
            return dataSaved;
        }

        /**
        * \brief Setter for contractStopDate from string
        *
        * \details <b>Details</b>
        *
        * \param date <b>string</b> - The stop date of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStopDate(string date)
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
                contractStopDate = new DateTime(year, month, day);
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for contractStopDate from ints
        *
        * \details <b>Details</b>
        *
        * \param year <b>int</b> - The stop year of the employees contract
        * \param month <b>int</b> - The stop month of the employees contract
        * \param day <b>int</b> - The stop day of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStopDate(int year, int month, int day)
        {
            bool dataSaved = true;

            try
            {
                DateTime newcontractStartDate = new DateTime(year, month, day);
                contractStartDate = newcontractStartDate;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for fixedContractAmount
        *
        * \details <b>Details</b>
        *
        * \param contractAmount <b>float</b> - The amount the contract is payed
        * 
        * \return dataSaves <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetFixedContractAmount(float contractAmount)
        {
            bool dataSaved = true;
            if (contractAmount > 0)
            {
                this.fixedContractAmount = contractAmount;
            }
            else
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        ////* Getter *////
        /**
        * \brief Getter for contractStartDate that returns DateTime
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return contractStartDate <b>DateTime</b>
        */
        public DateTime GetContractStartDate()
        {
            return contractStartDate;
        }

        /**
        * \brief Getter for contractStartDate that returns formatted string
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return contractStartDate <b>string</b>
        */
        public string GetContractStartDateString()
        {
            return String.Format("{0:yyyy-MM-dd}",contractStartDate);
        }

        /**
        * \brief Getter for contractStopDate that returns DateTime
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return contractStopDate <b>DateTime</b>
        */
        public DateTime GetContractStopDate()
        {
            return contractStopDate;
        }

        /**
        * \brief Getter for contractStopDate that returns formatted string
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return contractStopDate <b>string</b>
        */
        public string GetContractStopDateString()
        {
            return String.Format("{0:yyyy-MM-dd}",contractStopDate);
        }

        /**
        * \brief Getter for fixedContractAmount
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return fixedContractAmount <b>float</b>
        */
        public float GetFixedContractAmount()
        {
            return fixedContractAmount;
        }
    }
}