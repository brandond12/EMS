﻿/*
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
using Supporting;

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
        private double fixedContractAmount;

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
            Logging.Log("ContractEmployee", "ContractEmployee", "New Contract Employee Created");
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
            Logging.Log("ContractEmployee", "ContractEmployee", "New Contract Employee Created");
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
        * \param fixedContractAmount - <b>double</b> - Fixed Contract Amount of employee contract to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public ContractEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime contractStartDate, DateTime contractStopDate, double fixedContractAmount)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth, "CT")
        {
            this.contractStartDate = contractStartDate;
            this.contractStopDate = contractStopDate;
            this.fixedContractAmount = fixedContractAmount;
            if ((contractStartDate.Year == 1 && contractStopDate.Year != 1) || this.Validate() != true)
            {
                Logging.Log("ContractEmployee", "ContractEmployee", "Invalid ContractEmployee made in constructor");
                throw new FailedConstructorException();
            }
            Logging.Log("ContractEmployee", "ContractEmployee", "New Contract Employee Created");
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
                Logging.Log("ContractEmployee", "Validate", "Invalid Contract Amount - Can Not be Less Than 0. Input: " + fixedContractAmount);
            }

            else if (GetSocialInsuranceNumber() != 0 && GetSocialInsuranceNumber().ToString().Length != 9)
            {
                dataValid = false;
                Logging.Log("ContractEmployee", "Validate", "Invalid Social Insurance Number - Incorrect number of characters. Input: " + GetSocialInsuranceNumber().ToString());
            }

            else if (GetSocialInsuranceNumber() != 0 && GetDateOfBirth().Year != 1 && int.Parse(GetSocialInsuranceNumber().ToString().Substring(0, 2)) != int.Parse(GetDateOfBirthString().Substring(2, 2)))
            {
                dataValid = false;
                Logging.Log("ContractEmployee", "Validate", "Invalid Social Insurance Number - First 2 numbers dont match buisness start date. Input: " + GetSocialInsuranceNumber().ToString());
            }

            //validate dates
            else if(contractStopDate.Year != 1 && contractStartDate.Year == 1)
            {
                dataValid = false;
                Logging.Log("ContractEmployee", "Validate", "Invalid Contract Stop Date - No Contract Start Date");
            }

            else if (contractStopDate.Year != 1 && DateTime.Compare(contractStopDate, contractStartDate) < 0)
            {
                dataValid = false;
                Logging.Log("ContractEmployee", "Validate", "Invalid Contract Stop Date - Stop date before Start Date. Input: " + String.Format("{0:yyyy-MM-dd}", contractStopDate));
            }

            else if (contractStartDate.Year != 1 && DateTime.Compare(contractStartDate, GetDateOfBirth()) < 0)
            {
                dataValid = false;
                Logging.Log("ContractEmployee", "Validate", "Invalid Contract Start Date - Start date before Date of Birth. Input: " + String.Format("{0:yyyy-MM-dd}", contractStartDate));
            }

            else if(contractStartDate.Year == 1 || fixedContractAmount == 0)
            {
                dataValid = false;
                Logging.Log("ContractEmployee", "Validate", "Invalid Employee: " + this.ToString());
            }
            Logging.Log("ContractEmployee", "Validate", dataValid.ToString() + " Employee: " + this.ToString());
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
            string returnString = "Employee Type: Contract\nName: " + GetLastName()+
            "\nBuisness Number: ";
            if (GetSocialInsuranceNumber().ToString().Length == 9)
            {
                returnString += GetSocialInsuranceNumber().ToString().Substring(0, 5) + " " + GetSocialInsuranceNumber().ToString().Substring(5, 4);
            }
            returnString += "\nBuisness Start Date: ";
            if(GetDateOfBirthString() != "0001-01-01")
            {
                returnString += GetDateOfBirthString();
            }
            returnString += "\nContract Start Date: ";
            if (GetContractStartDateString() != "0001-01-01")
            {
                returnString += GetContractStartDateString();
            }
            returnString += "\nContract Stop Date: ";
            if (GetContractStopDateString() != "0001-01-01")
            {
                returnString += GetContractStopDateString();
            }
            returnString += "\nFixed Contract Amount: " + string.Format("{0:N2}", fixedContractAmount);

            return returnString;
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
                GetContractStartDateString() + "|" +
                GetContractStopDateString() + "|" + 
                fixedContractAmount.ToString() + "|";
            return outputString;
        }

        ////* Setters *////
        /**
       * \brief Setter for dateOfHire
       *
       * \details <b>Details</b>
       *
       * \param date <b>DateTime</b> - The employees date of hire
       * 
       * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
       */
        public bool SetDateOfBirth(DateTime date)
        {
            bool dataSaved = true;
            //validate dates
            if (contractStartDate.Year != 1 && (DateTime.Compare(contractStartDate, date) == -1))
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Date of Birth After Contract Start Date");
            }
            else if (DateTime.Compare(date, DateTime.Now) > 0)
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Can Not be in Future");
            }
            else if (int.Parse(GetSocialInsuranceNumber().ToString().Substring(0, 2)) != int.Parse(date.Year.ToString().Substring(2, 2)))
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Does not math buisness Number");
            }
            else
            {
                Logging.Log("ContractEmployee", "SetDateOfBirth", "Date of Birth Changed From: " + GetDateOfBirthString() + " To: " + String.Format("{0:yyyy-MM-dd}", date));
                SetDateOfBirthBase(date);
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfBirth with String
        *
        * \details <b>Details</b> - string format: YYYY-MM-DD
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
                DateTime DOB = new DateTime(year, month, day);
                //validate dates
                if (contractStartDate.Year != 1 && (DateTime.Compare(contractStartDate, DOB) == -1))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Date of Birth After Contract Start Date");
                }
                else if (DateTime.Compare(DOB, DateTime.Now) > 0)
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Can Not be in Future");
                }
                else if (date[4] != '-' || date[7] != '-')
                {
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Hire - Delimiters not '-'");
                    dataSaved = false;
                }
                else if (int.Parse(GetSocialInsuranceNumber().ToString().Substring(0, 2)) != int.Parse(year.ToString().Substring(2, 2)))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Does not math buisness Number");
                }
                else
                {
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Date of Birth Changed From: " + GetDateOfBirthString() + " To: " + String.Format("{0:yyyy-MM-dd}", DOB));
                    SetDateOfBirthBase(DOB);
                }
            }
            catch (Exception ex)
            {
                if (date.Length != 0)
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Exception Caught in Method. " + ex.Message);
                }
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
                DateTime DOB = new DateTime(year, month, day);
                //validate dates
                if (contractStartDate.Year != 1 && (DateTime.Compare(contractStartDate, DOB) == -1))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Date of Birth After Contract Start Date");
                }
                else if (DateTime.Compare(DOB, DateTime.Now) > 0)
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Can Not be in Future");
                }
                else if (int.Parse(GetSocialInsuranceNumber().ToString().Substring(0, 2)) != int.Parse(year.ToString().Substring(2, 2)))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Invalid Date of Birth - Does not math buisness Number");
                }
                else
                {
                    Logging.Log("ContractEmployee", "SetDateOfBirth", "Date of Birth Changed From: " + GetDateOfBirthString() + " To: " + String.Format("{0:yyyy-MM-dd}", DOB));
                    SetDateOfBirthBase(DOB);
                }
                
            }
            catch (Exception ex)
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetDateOfBirth", "Exception Caught in Method. " + ex.Message);
            }
            return dataSaved;
        }

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
            //validate dates
            if (GetDateOfBirth().Year != 1 && (DateTime.Compare(date, GetDateOfBirth()) == -1))
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetContractStartDate", "Invalid Contract Start Date - Contract Start Date Before Date of Birth");
            }
            else if (contractStopDate.Year != 1 && (DateTime.Compare(date, contractStopDate) == 1))
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetContractStartDate", "Invalid Contract Start Date - Contract Start Date after Contract Stop Date");
            }
            else
            {
                Logging.Log("ContractEmployee", "SetContractStartDate", "Contract Start Date Changed From: " + GetContractStartDateString() + " To: " + String.Format("{0:yyyy-MM-dd}", date));
                contractStartDate = date;
            }
            
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
                //validate dates
                if (GetDateOfBirth().Year != 1 && (DateTime.Compare(newcontractStartDate, GetDateOfBirth()) == -1))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Invalid Contract Start Date - Contract Start Date Before Date of Birth");
                }
                else if (contractStopDate.Year != 1 && (DateTime.Compare(newcontractStartDate, contractStopDate) == 1))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Invalid Contract Start Date - Contract Start Date after Contract Stop Date");
                }
                else if (date[4] != '-' || date[7] != '-')
                {
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Invalid Date of Hire - Delimiters not '-'");
                    dataSaved = false;
                }
                else
                {
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Contract Start Date Changed From: " + GetContractStartDateString() + " To: " + String.Format("{0:yyyy-MM-dd}", newcontractStartDate));
                    contractStartDate = newcontractStartDate;
                }
            }
            catch (Exception ex)
            {
                if (date.Length != 0)
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Exception Caught in Method. " + ex.Message);
                }
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
                //validate dates
                if (GetDateOfBirth().Year != 1 && (DateTime.Compare(newcontractStartDate, GetDateOfBirth()) == -1))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Invalid Contract Start Date - Contract Start Date Before Date of Birth");
                }
                else if (contractStopDate.Year != 1 && (DateTime.Compare(newcontractStartDate, contractStopDate) == 1))
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Invalid Contract Start Date - Contract Start Date after Contract Stop Date");
                }
                else
                {
                    Logging.Log("ContractEmployee", "SetContractStartDate", "Contract Start Date Changed From: " + GetContractStartDateString() + " To: " + String.Format("{0:yyyy-MM-dd}", newcontractStartDate));
                    contractStartDate = newcontractStartDate;
                }
            }
            catch (Exception ex)
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetContractStartDate", "Exception Caught in Method. " + ex.Message);
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
            if (DateTime.Compare(date, contractStartDate) == -1 && date.Year != 1)
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetContractStopDate", "Invalid Contract Stop Date - Contract Stop Date Before Contract Start Date");
            }
            else
            {
                Logging.Log("ContractEmployee", "SetContractStopDate", "Contract Stop Date Changed From: " + GetContractStopDateString() + " To: " + String.Format("{0:yyyy-MM-dd}", date));
                contractStopDate = date;
            }
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
            if (date != "N/A")
            {
                try
                {
                    year = Int32.Parse(date.Substring(0, 4));
                    month = Int32.Parse(date.Substring(5, 2));
                    day = Int32.Parse(date.Substring(8, 2));
                    DateTime newcontractStopDate = new DateTime(year, month, day);
                    //validate dates
                    if (DateTime.Compare(newcontractStopDate, contractStartDate) == -1 && year != 1)
                    {
                        dataSaved = false;
                        Logging.Log("ContractEmployee", "SetContractStopDate", "Invalid Contract Stop Date - Contract Stop Date Before Contract Start Date");
                    }
                    else if (date[4] != '-' || date[7] != '-')
                    {
                        Logging.Log("ContractEmployee", "SetContractStopDate", "Invalid Date of Hire - Delimiters not '-'");
                        dataSaved = false;
                    }
                    else
                    {
                        Logging.Log("ContractEmployee", "SetContractStopDate", "Contract Stop Date Changed From: " + GetContractStopDateString() + " To: " + String.Format("{0:yyyy-MM-dd}", newcontractStopDate));
                        contractStopDate = newcontractStopDate;
                    }
                }
                catch (Exception ex)
                {
                    if (date.Length != 0)
                    {
                        dataSaved = false;
                        Logging.Log("ContractEmployee", "SetContractStopDate", "Exception Caught in Method. " + ex.Message);
                    }
                }
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
                DateTime newcontractStopDate = new DateTime(year, month, day);
                //validate dates
                if(DateTime.Compare(newcontractStopDate, contractStartDate) == -1)
                {
                    dataSaved = false;
                    Logging.Log("ContractEmployee", "SetContractStopDate", "Invalid Contract Stop Date - Contract Stop Date Before Contract Start Date");
                }
                else
                {
                    Logging.Log("ContractEmployee", "SetContractStopDate", "Contract Stop Date Changed From: " + GetContractStopDateString() + " To: " + String.Format("{0:yyyy-MM-dd}", newcontractStopDate));
                    contractStopDate = newcontractStopDate;
                }
            }
            catch (Exception ex)
            {
                dataSaved = false;
                Logging.Log("ContractEmployee", "SetContractStopDate", "Exception Caught in Method. " + ex.Message);
            }
            return dataSaved;
        }

        /**
        * \brief Setter for fixedContractAmount
        *
        * \details <b>Details</b>
        *
        * \param contractAmount <b>double</b> - The amount the contract is payed
        * 
        * \return dataSaves <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetFixedContractAmount(double contractAmount)
        {
            bool dataSaved = true;
            if (contractAmount > 0)
            {
                Logging.Log("ContractEmployee", "SetFixedContractAmount", "Contract Amount Changed From: " + this.fixedContractAmount + " To: " + contractAmount);
                this.fixedContractAmount = contractAmount;
            }
            else
            {
                Logging.Log("ContractEmployee", "SetFixedContractAmount", "Invalid Contract Amount - Must be Greater Than 0");
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
            string termination = String.Format("{0:yyyy-MM-dd}", contractStopDate);
            if (termination == "0001-01-01")
            {
                termination = "N/A";
            }
            return termination;
        }

        /**
        * \brief Getter for fixedContractAmount
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return fixedContractAmount <b>double</b>
        */
        public double GetFixedContractAmount()
        {
            return fixedContractAmount;
        }
    }
}