using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class SeasonalEmployee : Employee
    {
        private string season;
        private float piecePay;

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
            season = "";
            piecePay = 0;
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
        * \param season - <b>string</b> - season the employee worked/works
        * \param piecePay - <b>float</b> - the price per unit that the worker is payed
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public SeasonalEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, string season, float piecePay)
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
            if (season != "Spring" && season != "Summer" && season != "Winter" && season != "Fall" && season != "")
            {
                dataValid = false;
            }
            if (piecePay < 0)
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
            return ("Employee Type: Contract\nName: " + GetFirstName() + " " + GetLastName() +
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
            string outputString = "SN" + "|" +
            ToStringBase() +
            season + "|" +
            piecePay.ToString();
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
        * \param piecePay <b>float</b> - The price the employee is payed for each unit created
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetPiecePay(float piecePay)
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
        * \return piecePay <b>float</b>
        */
        public float GetPiecePay()
        {
            return piecePay;
        }
    }
}
