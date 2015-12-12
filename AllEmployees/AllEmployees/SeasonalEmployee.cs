/*
* FILE   : ContractEmployee.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the file containing the SeasonalEmployee class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// \class SeasonalEmployee
    ///
    /// \brief <b>Brief Description</b>
    /// The Seasonal Employee class is used to store and manage data about a employee who is hired for a season.
    /// This class is a child to Employee class. It adds the season the employee is hired for and how much the employee is paid per item completed/created.
    /// If the constructor creates a invalid employee, a exception is thrown.
    /// All other errors result in a defined return.
    ///
    /// \author <i>Brandon</i>
    public class SeasonalEmployee : Employee
    {
        private string season;
        private double piecePay;

        /**
        * \brief default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public SeasonalEmployee()
            : base()
        {
            SetEmployeeType("SN");
            season = "";
            piecePay = 0;
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
        public SeasonalEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            SetEmployeeType("SN");
            season = "";
            piecePay = 0;
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
        * \param season - <b>string</b> - season the employee worked/works
        * \param piecePay - <b>double</b> - the price per unit that the worker is payed
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public SeasonalEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, string season, double piecePay)
            : base(firstName, lastName, socialInsuranceNumber, dateOfBirth, "SN")
        {
            this.season = season;
            this.piecePay = piecePay;
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
            if (season != "Spring" && season != "Summer" && season != "Winter" && season != "Fall")
            {
                dataValid = false;
            }
            else if (piecePay <= 0)
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
        * \return  userInfo <b>string</b> - formatted string of employee data
        */
        public string Details()
        {
            return ("Employee Type: Seasonal\nName: " + GetFirstName() + " " + GetLastName() +
                "\nSocial Insurance Number: " + GetSocialInsuranceNumber().ToString().Substring(0, 3) + " " + GetSocialInsuranceNumber().ToString().Substring(3, 3) + " " + GetSocialInsuranceNumber().ToString().Substring(6, 3) +
                "\nDate of Birth: " + GetDateOfBirthString() +
                "\nSeason: " + season +
                "\nPrice per Piece: " + piecePay.ToString());
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
            string outputString = "|SN" + "|" +
            ToStringBase() +
            season + "|" +
            piecePay.ToString() + "|";
            return outputString;
        }

        ////*Setters*//////
        /**
        * \brief Setter for season
        *
        * \details <b>Details</b>
        *
        * \param season <b>string</b> - The season the employee worked/works in
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetSeason(string season)
        {
            bool dataSaved = true;
            if (season != "Spring" && season != "Summer" && season != "Winter" && season != "Fall" && season != "")
            {
                dataSaved = false;
            }
            else
            {
                this.season = season;
            }
            return dataSaved;
        }

        /**
        * \brief Setter for piecePay
        *
        * \details <b>Details</b>
        *
        * \param piecePay <b>double</b> - The price the employee is payed for each unit created
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetPiecePay(double piecePay)
        {
            bool dataSaved = true;

            if (piecePay >= 0)
            {
                this.piecePay = piecePay;
            }
            else
            {
                dataSaved = false;
            }

            return dataSaved;
        }

        ////*Getters*//////
        /**
       * \brief Setter for SetDateOfBirth
       *
       * \details <b>Details</b>
       *
       * \param date <b>DateTime</b> - The employees date of birth
       * 
       * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
       */
        public bool SetDateOfBirth(DateTime date)
        {
            bool dataSaved = true;
            //validate dates
            if (DateTime.Compare(date, DateTime.Now) > 0)
            {
                dataSaved = false;
            }
            else
            {
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
                if (DateTime.Compare(DOB, DateTime.Now) > 0)
                {
                    dataSaved = false;
                }
                else
                {
                    SetDateOfBirthBase(DOB);
                }
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
                DateTime DOB = new DateTime(year, month, day);
                //validate dates
                if (DateTime.Compare(DOB, DateTime.Now) > 0)
                {
                    dataSaved = false;
                }
                else
                {
                    SetDateOfBirthBase(DOB);
                }
            }
            catch (Exception)
            {
                dataSaved = false;
            }
            return dataSaved;
        }
        /**
        * \brief Getter for season
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return season <b>string</b>
        */
        public string GetSeason()
        {
            return season;
        }

        /**
        * \brief Getter for piecePay
        *
        * \details <b>Details</b>
        *
        * \param n/a
        * 
        * \return piecePay <b>double</b>
        */
        public double GetPiecePay()
        {
            return piecePay;
        }
    }
}
