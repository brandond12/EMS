﻿/*
* FILE   : ContractEmployee.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the file containing the FulltimeEmployee class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporting;

namespace AllEmployees
{
    /// \class FulltimeEmployee
    ///
    /// \brief <b>Brief Description</b>
    /// The Fulltime Employee class is used to store and manage data about a employee who is hired for a full-time position.
    /// This class is a child to Employee class. It adds the date of hire and termination, and the employees salary.
    /// If the constructor creates a invalid employee, a exception is thrown.
    /// All other errors result in a defined return.
    ///
    /// \author <i>Brandon</i>

    public class FulltimeEmployee : Employee
    {
        private DateTime dateOfHire;
        private DateTime dateOfTermination;
        private double salary;

        /**
        * \brief default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public FulltimeEmployee()
            : base()
        {
            SetEmployeeType("FT");
            dateOfHire = new DateTime();
            dateOfTermination = new DateTime();
            salary = 0;
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
        public FulltimeEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            SetEmployeeType("FT");
            dateOfHire = new DateTime();
            dateOfTermination = new DateTime();
            salary = 0;
            Logging.Log("FulltimeEmployee", "Employee", "New Employee Created");
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
        * \param dateOfHire - <b>DateTime</b> - Date Of Hire of employee to add to records
        * \param dateOfTermination - <b>DateTime</b> - Date Of Termination of employee to add to records
        * \param salary - <b>double</b> - salary of employee to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public FulltimeEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime dateOfHire, DateTime dateOfTermination, double salary)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth, "FT")
        {
            this.dateOfHire = dateOfHire;
            this.dateOfTermination = dateOfTermination;
            this.salary = salary;
            if ((dateOfHire.Year == 1 && dateOfTermination.Year != 1) || this.Validate() != true)
            {
                Logging.Log("FulltimeEmployee", "FulltimeEmployee", "Invalid FulltimeEmployee made in constructor");
                throw new FailedConstructorException();
            }
            Logging.Log("FulltimeEmployee", "FulltimeEmployee", "New Full timeEmployee Created");
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

            if (GetFirstName() == "")
            {
                dataValid = false;
            }

            if (salary < 0)
            {
                dataValid = false;
                Logging.Log("FulltimeEmployee", "Validate", "Invalid Salary - Salary Can Not be Less Than 0");
            }

            //validate dates
            else if (dateOfTermination.Year != 1 && dateOfHire.Year == 1)
            {
                dataValid = false;
                Logging.Log("FulltimeEmployee", "Validate", "Invalid Termination Date - No Date of Hire");
            }

            else if(dateOfTermination.Year != 1 && DateTime.Compare(dateOfTermination, dateOfHire) < 0)
            {
                dataValid = false;
                Logging.Log("FulltimeEmployee", "Validate", "Invalid Termination Date - Date of Termination before Start Date.");
            }

            else if (dateOfHire.Year != 1 && DateTime.Compare(dateOfHire, GetDateOfBirth()) < 0)
            {
                dataValid = false;
                Logging.Log("FulltimeEmployee", "Validate", "Invalid Start Date - Start Date Before Birth Date.");
            }
            else if (dateOfHire.Year == 1 || salary == 0)
            {
                dataValid = false;
                Logging.Log("FulltimeEmployee", "Validate", "Invalid Employee: " + this.ToString());
            }
            Logging.Log("FulltimeEmployee", "Validate", dataValid.ToString() + " Employee: " + this.ToString());
            return dataValid;
        }

        /**
        * \brief Used to print all employee data to the consol
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return  userInfo <b>string</b> - formatted string of employee data
        */
        public string Details()
        {
            string details = "Employee Type: FullTime\nName: " + GetFirstName() + " " + GetLastName() +
                "\nSocial Insurance Number: ";
            if (GetSocialInsuranceNumber().ToString().Length == 9)
            {
                details += GetSocialInsuranceNumber().ToString().Substring(0, 3) + " " + GetSocialInsuranceNumber().ToString().Substring(3, 3) + " " + GetSocialInsuranceNumber().ToString().Substring(6, 3);
            }
            details += "\nDate of Birth: ";
            if (GetDateOfBirthString() != "0001-01-01")
            {
                details += GetDateOfBirthString();
            }
            details += "\nDate of Hire: ";
            if (GetDateOfHireString() != "0001-01-01")
            {
                details += GetDateOfHireString();
            }
            details += "\nDate of Termination: ";
            if (GetDateOfTerminationString() != "0001-01-01")
            {
                details += GetDateOfTerminationString();
            }
            details += "\nSalary: " + string.Format("{0:N2}", salary);
            //details += "\nSalary: " + salary.ToString();
            return details;
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
        public override string ToString()
        {
            string outputString = "FT" + "|" +
                ToStringBase() +
                GetDateOfHireString() + "|" +
                GetDateOfTerminationString() + "|" +
                salary.ToString() + "|";
            return outputString;
        }

        ////*Setters*//////
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
            if (dateOfHire.Year != 1 && (DateTime.Compare(dateOfHire, date) == -1))
            {
                Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Invalid Date of Birth - Date of Birth After Date of Hire");
                dataSaved = false;
            }
            else if (DateTime.Compare(date, DateTime.Now) > 0)
            {
                Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Invalid Date of Birth - Can Not be in Future");
                dataSaved = false;
            }
            else
            {
                Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Date of Birth Changed From: " + GetDateOfBirthString() + " To: " + String.Format("{0:yyyy-MM-dd}", date));
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
                if (dateOfHire.Year != 1 && (DateTime.Compare(dateOfHire, DOB) == -1))
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Invalid Date of Birth - Date of Birth After Contract Start Date");
                    dataSaved = false;
                }
                else if (DateTime.Compare(DOB, DateTime.Now) > 0)
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Invalid Date of Birth - Can Not be in Future");
                    dataSaved = false;
                }
                else if (date[4] != '-' || date[7] != '-')
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Invalid Date of Hire - Delimiters not '-'");
                    dataSaved = false;
                }
                else
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Date of Birth Changed From: " + GetDateOfBirthString() + " To: " + String.Format("{0:yyyy-MM-dd}", DOB));
                    SetDateOfBirthBase(DOB);
                }
            }
            catch (Exception ex)
            {
                if (date.Length != 0)
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Exception Caught in Method. " + ex.Message);
                    dataSaved = false;
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
                if (dateOfHire.Year != 1 && (DateTime.Compare(dateOfHire, DOB) == -1))
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Invalid Date of Birth - Date of Birth After Contract Start Date");
                    dataSaved = false;
                }
                else if (DateTime.Compare(DOB, DateTime.Now) > 0)
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Invalid Date of Birth - Can Not be in Future");
                    dataSaved = false;
                }
                else
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Date of Birth Changed From: " + GetDateOfBirthString() + " To: " + String.Format("{0:yyyy-MM-dd}", DOB));
                    SetDateOfBirthBase(DOB);
                }
            }
            catch (Exception ex)
            {
                Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Exception Caught in Method. " + ex.Message);
                dataSaved = false;
            }
            return dataSaved;
        }


        /**
        * \brief Setter for dateOfHire
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The employees date of hire
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfHire(DateTime date)
        {
            bool dataSaved = true;
            //validate dates
            if (GetDateOfBirth().Year != 1 && (DateTime.Compare(date, GetDateOfBirth()) == -1))
            {
                Logging.Log("FulltimeEmployee", "SetDateOfHire", "Invalid Date of Hire - Date of Hire Before Date of Birth");
                dataSaved = false;
            }
            else if(dateOfTermination.Year != 1 && (DateTime.Compare(date, dateOfTermination) == 1))
            {
                Logging.Log("FulltimeEmployee", "SetDateOfHire", "Invalid Date of Hire - Date of Hire after Date of Termination");
                dataSaved = false;
            }
            else
            {
                Logging.Log("FulltimeEmployee", "SetDateOfHire", "Date of Hire Changed From: " + GetDateOfHireString() + " To: " + String.Format("{0:yyyy-MM-dd}", date));
                dateOfHire = date;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfHire from String
        *
        * \details <b>Details</b>
        *
        * \param date <b>string</b> - The employees date of hire
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfHire(string date)
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

                DateTime newdateOfHire = new DateTime(year, month, day);
                //validate dates
                if (GetDateOfBirth().Year != 1 && (DateTime.Compare(newdateOfHire, GetDateOfBirth()) == -1))
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfHire", "Invalid Date of Hire - Date of Hire Before Date of Birth");
                    dataSaved = false;
                }
                else if (dateOfTermination.Year != 1 && (DateTime.Compare(newdateOfHire, dateOfTermination) == 1))
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfHire", "Invalid Date of Hire - Date of Hire after Date of Termination");
                    dataSaved = false;
                }
                else if (date[4] != '-' || date[7] != '-')
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfHire", "Invalid Date of Hire - Delimiters not '-'");
                    dataSaved = false;
                }
                else
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfHire", "Date of Hire Changed From: " + GetDateOfHireString() + " To: " + String.Format("{0:yyyy-MM-dd}", newdateOfHire));
                    dateOfHire = newdateOfHire;
                }
            }
            catch (Exception ex)
            {
                if (date.Length != 0)
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Exception Caught in Method. " + ex.Message);
                    dataSaved = false;
                }
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfHire from ints
        *
        * \details <b>Details</b>
        *
        * \param year <b>int</b> - The start year of the employees date of hire
        * \param month <b>int</b> - The start month of the employees date of hire
        * \param day <b>int</b> - The start day of the employees date of hire
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfHire(int year, int month, int day)
        {
            bool dataSaved = true;

            try
            {
                DateTime newdateOfHire = new DateTime(year, month, day);
                //validate dates
                if (GetDateOfBirth().Year != 1 && (DateTime.Compare(newdateOfHire, GetDateOfBirth()) == -1))
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfHire", "Invalid Date of Hire - Date of Hire Before Date of Birth");
                    dataSaved = false;
                }
                else if (dateOfTermination.Year != 1 && (DateTime.Compare(newdateOfHire, dateOfTermination) == 1))
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfHire", "Invalid Date of Hire - Date of Hire after Date of Termination");
                    dataSaved = false;
                }
                else
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfHire", "Date of Hire Changed From: " + GetDateOfHireString() + " To: " + String.Format("{0:yyyy-MM-dd}", newdateOfHire));
                    dateOfHire = newdateOfHire;
                }
            }
            catch (Exception ex)
            {
                Logging.Log("FulltimeEmployee", "SetDateOfBirth", "Exception Caught in Method. " + ex.Message);
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfTermination
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The employees date of termination
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfTermination(DateTime date)
        {
            bool dataSaved = true;
            //validate dates
            if (DateTime.Compare(date, dateOfHire) == -1 && date.Year != 1)
            {
                Logging.Log("FulltimeEmployee", "SetDateOfTermination", "Invalid Date of Termination - Date of Termination Before Start Date");
                dataSaved = false;
            }
            else
            {
                Logging.Log("ContractEmployee", "SetContractStopDate", "Contract Stop Date Changed From: " + GetDateOfTerminationString() + " To: " + String.Format("{0:yyyy-MM-dd}", date));
                dateOfTermination = date;
            }
            
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfTermination from string
        *
        * \details <b>Details</b>
        *
        * \param date <b>string</b> - The employees date of termination
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfTermination(string date)
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

                    DateTime newdateOfTermination = new DateTime(year, month, day);
                    //validate dates
                    if (DateTime.Compare(newdateOfTermination, dateOfHire) == -1 && year != 1)
                    {
                        Logging.Log("FulltimeEmployee", "SetDateOfTermination", "Invalid Date of Termination - Date of Termination Before Start Date");
                        dataSaved = false;
                    }
                    else if (date[4] != '-' || date[7] != '-')
                    {
                        Logging.Log("FulltimeEmployee", "SetDateOfTermination", "Invalid Date of Hire - Delimiters not '-'");
                        dataSaved = false;
                    }
                    else
                    {
                        Logging.Log("ContractEmployee", "SetContractStopDate", "Contract Stop Date Changed From: " + GetDateOfTerminationString() + " To: " + String.Format("{0:yyyy-MM-dd}", newdateOfTermination));
                        dateOfTermination = newdateOfTermination;
                    }
                }
                catch (Exception ex)
                {
                    if (date.Length != 0)
                    {
                        Logging.Log("FulltimeEmployee", "SetContractStopDate", "Exception Caught in Method. " + ex.Message);
                        dataSaved = false;
                    }
                }
            }
            return dataSaved;            
        }

        /**
        * \brief Setter for dateOfTermination from int
        *
        * \details <b>Details</b>
        *
        * \param year <b>int</b> - The start year of the employees date of termination
        * \param month <b>int</b> - The start month of the employees date of termination
        * \param day <b>int</b> - The start day of the employees date of termination
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfTermination(int year, int month, int day)
        {
            bool dataSaved = true;

            try
            {
                DateTime newdateOfTermination = new DateTime(year, month, day);
                //validate dates
                if (DateTime.Compare(newdateOfTermination, dateOfHire) == -1)
                {
                    Logging.Log("FulltimeEmployee", "SetDateOfTermination", "Invalid Date of Termination - Date of Termination Before Start Date");
                    dataSaved = false;
                }
                else
                {
                    Logging.Log("ContractEmployee", "SetContractStopDate", "Contract Stop Date Changed From: " + GetDateOfTerminationString() + " To: " + String.Format("{0:yyyy-MM-dd}", newdateOfTermination));
                    dateOfTermination = newdateOfTermination;
                }
            }
            catch (Exception ex)
            {
                Logging.Log("FulltimeEmployee", "SetContractStopDate", "Exception Caught in Method. " + ex.Message);
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for salary
        *
        * \details <b>Details</b>
        *
        * \param salary <b>double</b> - The salary of the employee
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetSalary(double salary)
        {
            bool dataSaved = true;

            if (salary >= 0)
            {
                Logging.Log("ContractEmployee", "SetContractStopDate", "Contract Stop Date Changed From: ");
                this.salary = salary;
            }
            else
            {
                Logging.Log("FulltimeEmployee", "SetSalary", "Invalid Salary - Salary Must be Greater Than 0");
                dataSaved = false;
            }

            return dataSaved;
        }

        ////*Getter*//////
        /**
        * \brief Getter for dateOfHire
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

        /**
        * \brief Getter for dateOfHire that returns formatted string
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dateOfHire <b>string</b>
        */
        public string GetDateOfHireString()
        {
            return String.Format("{0:yyyy-MM-dd}", dateOfHire);
        }

        /**
        * \brief Getter for dateOfTermination
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
        * \brief Getter for dateOfTermination that returns formatted string
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return dateOfTermination <b>string</b>
        */
        public string GetDateOfTerminationString()
        {
            string termination = String.Format("{0:yyyy-MM-dd}", dateOfTermination);
            if(termination == "0001-01-01")
            {
                termination = "N/A";
            }
            return termination;
        }

        /**
        * \brief Getter for salary
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return salary <b>double</b>
        */
        public double GetSalary()
        {
            return salary;
        }
    }
}
