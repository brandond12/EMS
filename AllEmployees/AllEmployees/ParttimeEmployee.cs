/*
* FILE   : ContractEmployee.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the file containing the ParttimeEmployee class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// \class ParttimeEmployee
    ///
    /// \brief <b>Brief Description</b>
    /// The Parttime Employee class is used to store and manage data about a employee who is hired for a part-time possition.
    /// This class is a child to Employee class. It adds the date of hire and termination, and the employees hourly wage.
    /// If the constructor creates a invalid employee, a exception is thrown
    /// All other errors result in a defined return
    ///
    /// \author <i>Brandon</i>
    public class ParttimeEmployee : Employee
    {
        private DateTime dateOfHire;
        private DateTime dateOfTermination;
        private float hourlyRate;

        /**
        * \brief default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public ParttimeEmployee()
            : base()
        {
            dateOfTermination = new DateTime();
            hourlyRate = 0;
            dateOfHire = new DateTime();
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
        public ParttimeEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            dateOfTermination = new DateTime();
            hourlyRate = 0;
            dateOfHire = new DateTime();
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
        * \param dateOfHire - <b>DateTime</b> - Date Of Hire of employee to add to records
        * \param dateOfTermination - <b>DateTime</b> - Date Of Termination of employee to add to records
        * \param hourlyRate - <b>float</b> - Hourly Rate of employee to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public ParttimeEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime dateOfHire, DateTime dateOfTermination, float hourlyRate)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth, "PT")
        {
            this.dateOfTermination = dateOfTermination;
            this.hourlyRate = hourlyRate;
            this.dateOfHire = dateOfHire;
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
            bool dataValid = ValidateBase();
            if (hourlyRate < 0)
            {
                dataValid = false;
            }
            return dataValid;//temp to remove errors
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
            return ("Employee Type: Contract\nName: " + GetFirstName() + " " + GetLastName() +
                "\nSocial Insurance Number: " + GetSocialInsuranceNumber().ToString().Substring(0, 3) + " " + GetSocialInsuranceNumber().ToString().Substring(3, 3) + " " + GetSocialInsuranceNumber().ToString().Substring(6, 3) +
                "\nDate of Birth: " + GetDateOfBirthString() +
                "\nDate of Hire: " + GetDateOfHireString() +
                "\nDate of Termionation" + GetDateOfTerminationString() +
                "\nHourly Rate: " + hourlyRate.ToString());
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
            string outputString = "PT" + "|" +
               ToStringBase() +
               GetDateOfHireString() + "|" +
               GetDateOfTerminationString() + "|" +
               hourlyRate.ToString();
            return outputString;
        }

        ////*Setters*//////
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
            dateOfTermination = date;
            return true;
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
            try
            {
                year = Int32.Parse(date.Substring(0, 4));
                month = Int32.Parse(date.Substring(5, 2));
                day = Int32.Parse(date.Substring(8, 2));

                DateTime newDateOfTermination = new DateTime(year, month, day);
                dateOfTermination = newDateOfTermination;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfTermination from ints
        *
        * \details <b>Details</b>
        *
        * \param year <b>int</b> - The year of the employees Termination
        * \param month <b>int</b> - The month of the employees Termination
        * \param day <b>int</b> - The day of the employees Termination
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfTermination(int year, int month, int day)
        {
            bool dataSaved = true;

            try
            {
                DateTime newDateOfTermination = new DateTime(year, month, day);
                dateOfTermination = newDateOfTermination;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for hourlyRate
        *
        * \details <b>Details</b>
        *
        * \param rate <b>float</b> - The employees hourly rate
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetHourlyRate(float rate)
        {
            bool dateSaved = true;

            if (rate >= 0)
            {
                hourlyRate = rate;
            }
            else
            {
                dateSaved = false;
            }

            return dateSaved;
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
            dateOfHire = date;
            return true;
        }

        /** 
        * \brief Setter for dateOfHire from string
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

                DateTime newDateOfHire = new DateTime(year, month, day);
                dateOfHire = newDateOfHire;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for dateOfHire from ints
        *
        * \details <b>Details</b>
        *
        * \param year <b>int</b> - The year of the employees dateOfHire
        * \param month <b>int</b> - The month of the employees dateOfHire
        * \param day <b>int</b> - The day of the employees dateOfHire
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetDateOfHire(int year, int month, int day)
        {
            bool dataSaved = true;

            try
            {
                DateTime newDateOfHire = new DateTime(year, month, day);
                dateOfHire = newDateOfHire;
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }

        ////*Getters*//////
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
            return String.Format("{0:yyyy-MM-dd}", dateOfTermination);
        }

        /**
        * \brief Getter for hourlyRate
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
    }
}
