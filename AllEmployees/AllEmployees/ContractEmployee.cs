using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    class ContractEmployee : Employee
    {
        private DateTime contractStartDate;
        private DateTime contractStopDate;
        private float fixedContractAmount;

        /**
        * \breif default constructor. Sets all values to default
        *
        * \details <b>Details</b>
        *
        * \param n/a
        *
        * \return  n/a
        */
        public ContractEmployee()
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
        public ContractEmployee(string firstName, string lastName)
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
        * \param contractStartDate - <b>DateTime</b> - Contract Start Date of employee contract to add to records
        * \param contractStopDate - <b>DateTime</b> - Contract Stop Date of employee contract to add to records
        * \param fixedContractAmount - <b>float</b> - Fixed Contract Amount of employee contract to add to records
        *
        * \throw <FailedConstructorException> - If the constructor failed to create the object 
        * 
        * \return  n/a
        */
        public ContractEmployee(string firstName, string lastName, int socialInsuranceNumber, DateTime dateOfBirth, DateTime contractStartDate, DateTime contractStopDate, float fixedContractAmount)
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
        * \breif Overriden method ToString used to return a formated string of all data about employee
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


        ////* Setters *////
        /**
        * \breif Setter for contractStartDate
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The start date of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStartDate(DateTime date)
        {
            return true;
        }

        /**
        * \breif Setter for contractStopDate
        *
        * \details <b>Details</b>
        *
        * \param date <b>DateTime</b> - The stop date of the employees contract
        * 
        * \return dataSaved <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetContractStopDate(DateTime date)
        {
            return true;
        }

        /**
        * \breif Setter for fixedContractAmount
        *
        * \details <b>Details</b>
        *
        * \param contractAmount <b>float</b> - The amount the contract is payed
        * 
        * \return dataSaves <b>bool</b> - true if input was valid and data was changed. False it data was not changed
        */
        public bool SetFixedContractAmount(float contractAmount)
        {
            return true;
        }

        ////* Getter *////
        /**
        * \breif Getter for contractStartDate
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
        * \breif Getter for contractStopDate
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
        * \breif Getter for fixedContractAmount
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
