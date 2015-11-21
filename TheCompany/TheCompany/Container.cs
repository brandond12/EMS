﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllEmployees;
using Presentation;

namespace TheCompany
{
    public class Container
    {
        private List<AllEmployees.Employee> listOfEmployees = new List<AllEmployees.Employee>(); // List that holds all of the employees

        /**
        * \brief The addEmployee method is used to create an employee and to add the 
        * created employee to a list. While creating the employee, this method uses a 
        * method from the UIMenu class to get user input for the employee's properties.
        * 
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return n/a
        */
        public void AddEmployee()
        {
            String employeeType;    // The employee is either FT, PT, CT, or SN
            String error;           // Data the user typed before hitting the enter key after the error message 

            // Get the employee type from the user
            employeeType = UIMenu.GetInfoFromUser("Enter the employee's type: FT (Full-time), PT (Part-time), CT (Contract), or  SN (Seasonal):");

            // Create a new employee object of the specified type
            switch (employeeType)
            {
                // Full-time Employee
                case "FT":
                    AllEmployees.FulltimeEmployee newFulltimeEmployee = GetFulltimeEmployeeProperties();
                    // If the returned employee is valid, add it to the employee list
                    if ((newFulltimeEmployee.GetFirstName() != "") && (newFulltimeEmployee.GetLastName() != ""))
                    {
                        AddEmployeeToList(newFulltimeEmployee);
                    }
                    break;
                // Part-time Employee
                case "PT":
                    AllEmployees.ParttimeEmployee newParttimeEmployee = GetParttimeEmployeeProperties();
                    // If the returned employee is valid, add it to the employee list
                    if ((newParttimeEmployee.GetFirstName() != "") && (newParttimeEmployee.GetLastName() != ""))
                    {
                        AddEmployeeToList(newParttimeEmployee);
                    }
                    break;
                // Contract Employee
                case "CT":
                    AllEmployees.ContractEmployee newContractEmployee = GetContractEmployeeProperties();
                    // If the returned employee is valid, add it to the employee list
                    if ((newContractEmployee.GetFirstName() != "") && (newContractEmployee.GetLastName() != ""))
                    {
                        AddEmployeeToList(newContractEmployee);
                    }
                    break;
                // Seasonal Employee
                case "SN":
                    AllEmployees.SeasonalEmployee newSeasonalEmployee = GetSeasonalEmployeeProperties();
                    // If the returned employee is valid, add it to the employee list
                    if ((newSeasonalEmployee.GetFirstName() != "") && (newSeasonalEmployee.GetLastName() != ""))
                    {
                        AddEmployeeToList(newSeasonalEmployee);
                    }
                    break;
                // An invalid employee
                default:
                    error = UIMenu.GetInfoFromUser("An invalid employee type was entered, so an employee won't be created.\nHit enter to continue.");
                    break;
            }
        }

        /**
        * \brief The GetFulltimeEmployeeProperties method is used to create a full-time 
        * employee object from the properties the user enters. A valid full-time employee 
        * object is created if the user entered valid data, otherwise a blank object is returned.
        *
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return employee - <b>AllEmployees.FulltimeEmployee</b> - The full-time employee object
        */
        private AllEmployees.FulltimeEmployee GetFulltimeEmployeeProperties()
        {
            String firstName;                   // The first name of the employee
            String lastName;                    // The last name of the employee
            int intSocialInsuranceNumber;       // The int version of the SIN
            String stringSocialInsuranceNumber; // The string version of the SIN
            String stringYear;                  // The string year - used by DOB, date of termination and date of hire
            String stringMonth;                 // The string month - used by DOB, date of termination and date of hire
            String stringDay;                   // The string day - used by DOB, date of termination and date of hire
            int intYear;                        // The int year - used by DOB, date of termination and date of hire
            int intMonth;                       // The int month - used by DOB, date of termination and date of hire
            int intDay;                         // The int day - used by DOB, date of termination and date of hire
            String stringSalary;                // The string version of the salary
            float floatSalary;                  // The float version of the salary
            String error;                       // Data the user typed before hitting the enter key after the error message 
            AllEmployees.FulltimeEmployee newFulltimeEmployee;  // A fulltime employee reference

            try
            {
                // Get the first name from the user
                firstName = UIMenu.GetInfoFromUser("Enter the employee's first name: ");

                // Get the last name from the user
                lastName = UIMenu.GetInfoFromUser("Enter the employee's last name: ");

                // Get the SIN from the user
                stringSocialInsuranceNumber = UIMenu.GetInfoFromUser("Enter the employee's social insurance number: ");
                intSocialInsuranceNumber = Convert.ToInt32(stringSocialInsuranceNumber);

                // Get the DOB from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's birth year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's birth month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's birth day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfBirth = new DateTime(intYear, intMonth, intDay);

                // Get the date of termination from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's termination year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's termination month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's termination day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfTermination = new DateTime(intYear, intMonth, intDay);

                // Get the date of hire from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's hire year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's hire month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's hire day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfHire = new DateTime(intYear, intMonth, intDay);

                // Get the salary from the user
                stringSalary = UIMenu.GetInfoFromUser("Enter the employee's salary, in dollars: ");
                floatSalary = float.Parse(stringSalary);

                // Try to create an employee object with the user's data
                newFulltimeEmployee = new AllEmployees.FulltimeEmployee(firstName, lastName, intSocialInsuranceNumber, dateOfBirth, dateOfHire,
                dateOfTermination, floatSalary);
            }
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("Invalid data was entered, or another error occurred.\nThe employee object could not be created" +
                ".\nHit enter to continue.");
                /* If there was an error, that means an employee object wasn't created, 
                * so create a blank employee object to return to the calling function */
                newFulltimeEmployee = new AllEmployees.FulltimeEmployee();
            }

            return newFulltimeEmployee;
        }

        /**
        * \brief The GetParttimeEmployeeProperties method is used to create a part-time 
        * employee object from the properties the user enters. A valid part-time employee 
        * object is created if the user entered valid data, otherwise a blank object is returned.
        *
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return employee - <b>AllEmployees.ParttimeEmployee</b> - The part-time employee object
        */
        private AllEmployees.ParttimeEmployee GetParttimeEmployeeProperties()
        {
            String firstName;                   // The first name of the employee
            String lastName;                    // The last name of the employee
            int intSocialInsuranceNumber;       // The int version of the SIN
            String stringSocialInsuranceNumber; // The string version of the SIN
            String stringYear;                  // The string year - used by DOB, date of termination and date of hire
            String stringMonth;                 // The string month - used by DOB, date of termination and date of hire
            String stringDay;                   // The string day - used by DOB, date of termination and date of hire
            int intYear;                        // The int year - used by DOB, date of termination and date of hire
            int intMonth;                       // The int month - used by DOB, date of termination and date of hire
            int intDay;                         // The int day - used by DOB, date of termination and date of hire
            String stringHourlyRate;            // The string version of the hourly rate
            float floatHourlyRate;              // The float version of the hourly rate
            String error;                       // Data the user typed before hitting the enter key after the error message 
            AllEmployees.ParttimeEmployee newParttimeEmployee;  // A parttime employee reference

            try
            {
                // Get the first name from the user
                firstName = UIMenu.GetInfoFromUser("Enter the employee's first name: ");

                // Get the last name from the user
                lastName = UIMenu.GetInfoFromUser("Enter the employee's last name: ");

                // Get the SIN from the user
                stringSocialInsuranceNumber = UIMenu.GetInfoFromUser("Enter the employee's social insurance number: ");
                intSocialInsuranceNumber = Convert.ToInt32(stringSocialInsuranceNumber);

                // Get the DOB from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's birth year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's birth month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's birth day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfBirth = new DateTime(intYear, intMonth, intDay);

                // Get the date of termination from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's termination year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's termination month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's termination day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfTermination = new DateTime(intYear, intMonth, intDay);

                // Get the hourly rate from the user
                stringHourlyRate = UIMenu.GetInfoFromUser("Enter the employee's hourly rate: ");
                floatHourlyRate = float.Parse(stringHourlyRate);

                // Get the date of hire from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's hire year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's hire month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's hire day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfHire = new DateTime(intYear, intMonth, intDay);

                // Try to create an employee object with the user's data
                newParttimeEmployee = new AllEmployees.ParttimeEmployee(firstName, lastName, intSocialInsuranceNumber, dateOfBirth, dateOfHire,
                dateOfTermination, floatHourlyRate);
            }
            // An exception will be thrown if invalid or out-of-range data is entered, or if the constructor fails
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("Invalid data was entered, or another error occurred.\nThe employee object could not be created" +
                ".\nHit enter to continue.");
                /* If there was an error, that means an employee object wasn't created, 
                * so create a blank employee object to return to the calling function */
                newParttimeEmployee = new AllEmployees.ParttimeEmployee();
            }

            return newParttimeEmployee;
        }

        /**
        * \brief The GetContractEmployeeProperties method is used to create a contract 
        * employee object from the properties the user enters. A valid contract employee 
        * object is created if the user entered valid data, otherwise a blank object is returned.
        *
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return employee - <b>AllEmployees.ContractEmployee</b> - The contract employee object
        */
        private AllEmployees.ContractEmployee GetContractEmployeeProperties()
        {
            String firstName;                   // The first name of the employee
            String lastName;                    // The last name of the employee
            int intSocialInsuranceNumber;       // The int version of the SIN
            String stringSocialInsuranceNumber; // The string version of the SIN
            String stringYear;                  // The string year - used by DOB, contract start date and contract end date
            String stringMonth;                 // The string month - used by DOB, contract start date and contract end date
            String stringDay;                   // The string day - used by DOB, contract start date and contract end date
            int intYear;                        // The int year - used by DOB, contract start date and contract end date
            int intMonth;                       // The int month - used by DOB, contract start date and contract end date
            int intDay;                         // The int day - used by DOB, contract start date and contract end date
            String stringFixedContractAmount;   // The string version of the fixed contract amount
            float floatFixedContractAmount;     // The float version of the fixed contract amount
            String error;                       // Data the user typed before hitting the enter key after the error message 
            AllEmployees.ContractEmployee newContractEmployee;  // A contract employee reference

            try
            {
                // Get the first name from the user
                firstName = UIMenu.GetInfoFromUser("Enter the employee's first name: ");

                // Get the last name from the user
                lastName = UIMenu.GetInfoFromUser("Enter the employee's last name: ");

                // Get the SIN from the user
                stringSocialInsuranceNumber = UIMenu.GetInfoFromUser("Enter the employee's social insurance number: ");
                intSocialInsuranceNumber = Convert.ToInt32(stringSocialInsuranceNumber);

                // Get the DOB from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's birth year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's birth month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's birth day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfBirth = new DateTime(intYear, intMonth, intDay);

                // Get the contract start date from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's contract start year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's contract start month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's contract start day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime contractStartDate = new DateTime(intYear, intMonth, intDay);

                // Get the contract stop date from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's contract stop year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's contract stop month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's contract stop day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime contractStopDate = new DateTime(intYear, intMonth, intDay);

                // Get the fixed contract amount from the user
                stringFixedContractAmount = UIMenu.GetInfoFromUser("Enter the employee's fixed contract amount, in dollars: ");
                floatFixedContractAmount = float.Parse(stringFixedContractAmount);

                // Try to create an employee object with the user's data
                newContractEmployee = new AllEmployees.ContractEmployee(firstName, lastName, intSocialInsuranceNumber,
                dateOfBirth, contractStartDate, contractStopDate, floatFixedContractAmount);
            }
            // An exception will be thrown if invalid or out-of-range data is entered, or if the constructor fails
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("Invalid data was entered, or another error occurred.\nThe employee object could not be created" +
                ".\nHit enter to continue.");
                /* If there was an error, that means an employee object wasn't created, 
                * so create a blank employee object to return to the calling function */
                newContractEmployee = new AllEmployees.ContractEmployee();
            }

            return newContractEmployee;
        }

        /**
        * \brief The GetSeasonalEmployeeProperties method is used to create a seasonal 
        * employee object from the properties the user enters. A valid seasonal employee 
        * object is created if the user entered valid data, otherwise a blank object is returned.
        *
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return employee - <b>AllEmployees.SeasonalEmployee</b> - The seasonal employee object
        */
        private AllEmployees.SeasonalEmployee GetSeasonalEmployeeProperties()
        {
            String firstName;                   // The first name of the employee
            String lastName;                    // The last name of the employee
            int intSocialInsuranceNumber;       // The int version of the SIN
            String stringSocialInsuranceNumber; // The string version of the SIN
            String stringYear;                  // The string year for date of birth
            String stringMonth;                 // The string month for date of birth
            String stringDay;                   // The string day for date of birth
            int intYear;                        // The int year for date of birth
            int intMonth;                       // The int month for date of birth
            int intDay;                         // The int day for date of birth
            String season;                      // The season the employee works in
            String stringPiecePay;              // String version of the piece pay
            float floatPiecePay;                // The float version of the piece pay
            String error;                       // Data the user typed before hitting the enter key after the error message 
            AllEmployees.SeasonalEmployee newSeasonalEmployee;  // A seasonal employee reference

            try
            {
                // Get the first name from the user
                firstName = UIMenu.GetInfoFromUser("Enter the employee's first name: ");

                // Get the last name from the user
                lastName = UIMenu.GetInfoFromUser("Enter the employee's last name: ");

                // Get the SIN from the user
                stringSocialInsuranceNumber = UIMenu.GetInfoFromUser("Enter the employee's social insurance number: ");
                intSocialInsuranceNumber = Convert.ToInt32(stringSocialInsuranceNumber);

                // Get the DOB from the user
                stringYear = UIMenu.GetInfoFromUser("Enter the employee's birth year (yyyy): ");
                intYear = Convert.ToInt32(stringYear);
                stringMonth = UIMenu.GetInfoFromUser("Enter the employee's birth month (mm): ");
                intMonth = Convert.ToInt32(stringMonth);
                stringDay = UIMenu.GetInfoFromUser("Enter the employee's birth day (dd): ");
                intDay = Convert.ToInt32(stringDay);
                DateTime dateOfBirth = new DateTime(intYear, intMonth, intDay);

                // Get the season from the user
                season = UIMenu.GetInfoFromUser("Enter the employee's work season: ");

                // Get the piece pay from the user 
                stringPiecePay = UIMenu.GetInfoFromUser("Enter the employee's piece pay, in dollars: ");
                floatPiecePay = float.Parse(stringPiecePay);

                // Try to create an employee object with the user's data
                newSeasonalEmployee = new AllEmployees.SeasonalEmployee(firstName, lastName, intSocialInsuranceNumber, dateOfBirth, season, floatPiecePay);
            }
            // An exception will be thrown if invalid or out-of-range data is entered, or if the constructor fails
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("Invalid data was entered, or another error occurred.\nThe employee object could not be created" +
                ".\nHit enter to continue.");
                /* If there was an error, that means an employee object wasn't created, 
                * so create a blank employee object to return to the calling function */
                newSeasonalEmployee = new AllEmployees.SeasonalEmployee();
            }

            return newSeasonalEmployee;
        }

        /**
        * \brief The AddEmployeeToList method is used to add a specified employee to the employee list.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to add to the list
        * 
        * \return n/a
        */
        public void AddEmployeeToList(AllEmployees.Employee employee)
        {
            listOfEmployees.Add(employee);
        }

        /**
        * \brief The RemoveEmployee method is used to remove a specified employee from a list.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to remove from a list
        * 
        * \return n/a
        */
        public void RemoveEmployee(AllEmployees.Employee employee)
        {
            listOfEmployees.Remove(employee);
        }

        /**
        * \brief The DisplayAllEmployees method is used to traverse 
        * through all employee objects in the employee list.
        *
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return n/a
        */
        public void DisplayAllEmployees()
        {
            String response;    // The key the user hits to display the next employee

            // Loop through all of the employees
            foreach (AllEmployees.Employee employee in listOfEmployees)
            {
                if (employee.GetEmployeeType() == "FT")
                {
                    response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.FulltimeEmployee)employee).Details()
                    + "\nHit enter to see the next employee.");
                }
                else if (employee.GetEmployeeType() == "PT")
                {
                    response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.ParttimeEmployee)employee).Details()
                    + "\nHit enter to see the next employee.");
                }
                else if (employee.GetEmployeeType() == "CT")
                {
                    response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.ContractEmployee)employee).Details()
                    + "\nHit enter to see the next employee.");
                }
                else if (employee.GetEmployeeType() == "SN")
                {
                    response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.SeasonalEmployee)employee).Details()
                    + "\nHit enter to see the next employee.");
                }
            }
        }

        /**
        * \brief The ModifyEmployee method is used to modify a specified employee. The method goes 
        * through each of the employee's properties and asks the user, by using a method from the 
        * UIMenu class, if they would like to update the property. If the user chooses to update 
        * a property, the method gets an updated property value from the user by using a method in 
        * the UIMenu class.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        public void ModifyEmployee(AllEmployees.Employee employee)
        {
            // Modify basic properties
            ModifyFirstName(employee);
            ModifyLastName(employee);
            ModifySocialInsuranceNumber(employee);
            ModifyDateOfBirth(employee);
            ModifyEmployeeType(employee);

            // Modify properties depending on the employee's type
            if (employee.GetEmployeeType() == "FT")
            {
                ModifyDateOfHire(employee);
                ModifyDateOfTermination(employee);
                ModifySalary(employee);
            }
            else if (employee.GetEmployeeType() == "PT")
            {
                ModifyDateOfHire(employee);
                ModifyDateOfTermination(employee);
                ModifyHourlyRate(employee);
            }
            else if (employee.GetEmployeeType() == "CT")
            {
                ModifyContractStartDate(employee);
                ModifyContractStopDate(employee);
                ModifyFixedContractAmount(employee);
            }
            else if (employee.GetEmployeeType() == "SN")
            {
                ModifySeason(employee);
                ModifyPiecePay(employee);
            }
        }

        /**
        * \brief The ModifyFirstName method is used to modify the first name of the specified employee. 
        * The method asks the user if they would like to modify the first name, and the user can choose 
        * yes or no. If the user enters yes, they will be prompted for a new name. If the name is invalid, 
        * the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyFirstName(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message  
            String newFirstName;                // The new first name of the employee
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            /* Keep looping over the employee property until the user 
            * chooses to modify or not modify the propery */
            while (wasQuestionAnswered == false)
            {
                // Display the employee property and a question, then get a response from the user
                response = UIMenu.GetInfoFromUser("First Name: " + employee.GetFirstName()
                + "\nWould you like to modify the first name?\nType 'Y' for yes, and 'N' for no.");

                // Check if the response was 'Y', 'N', or neither
                if (response == "Y")
                {
                    /* If 'Y' is the reponse, ask the user for a first name, 
                    and try to set the employee's first name to the new name */
                    newFirstName = UIMenu.GetInfoFromUser("Enter a new first name: ");
                    didModifyWork = employee.SetFirstName(newFirstName);
                    // Check if the employee's first name has been changed
                    if (didModifyWork == false)
                    {
                        /* If didModifyWork is false, that means the user's entered value 
                        * was invalid, so inform the user that the value will remain unchanged */
                        error = UIMenu.GetInfoFromUser("The first name you entered was invalid, so the first name will remain unchanged.\nHit enter to continue.");
                    }
                    wasQuestionAnswered = true;
                }
                else if (response == "N")
                {
                    /* If 'N' is the response, then the user has chosen not 
                    * to modify this property, so leave the while loop */
                    wasQuestionAnswered = true;
                }
                else
                {
                    /* If invalid characters were entered, then the question 
                    * wasn't answered, so stay in the while loop */
                    wasQuestionAnswered = false;
                }
            }
        }

        /**
        * \brief The ModifyLastName method is used to modify the last name of the specified employee. 
        * The method asks the user if they would like to modify the last name, and the user can choose 
        * yes or no. If the user enters yes, they will be prompted for a new name. If the name is invalid, 
        * the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyLastName(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newLastName;                 // The new last name of the employee
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            /* Keep looping over the employee property until the user 
            * chooses to modify or not modify the propery */
            while (wasQuestionAnswered == false)
            {
                // Display the employee property and a question, then get a response from the user
                response = UIMenu.GetInfoFromUser("Last Name: " + employee.GetLastName()
                + "\nWould you like to modify the last name?\nType 'Y' for yes, and 'N' for no.");

                // Check if the response was 'Y', 'N', or neither
                if (response == "Y")
                {
                    /* If 'Y' is the reponse, ask the user for a last name, 
                    and try to set the employee's last name to the new name */
                    newLastName = UIMenu.GetInfoFromUser("Enter a new last name: ");
                    didModifyWork = employee.SetLastName(newLastName);
                    // Check if the employee's last name has been changed
                    if (didModifyWork == false)
                    {
                        /* If didModifyWork is false, that means the user's entered value 
                        * was invalid, so inform the user that the value will remain unchanged */
                        error = UIMenu.GetInfoFromUser("The last name you entered was invalid, so the last name will remain unchanged.\nHit enter to continue.");
                    }
                    wasQuestionAnswered = true;
                }
                else if (response == "N")
                {
                    /* If 'N' is the response, then the user has chosen not 
                    * to modify this property, so leave the while loop */
                    wasQuestionAnswered = true;
                }
                else
                {
                    /* If invalid characters were entered, then the question 
                    * wasn't answered, so stay in the while loop */
                    wasQuestionAnswered = false;
                }
            }
        }

        /**
        * \brief The ModifySocialInsuranceNumber method is used to modify the SIN of the specified 
        * employee. The method asks the user if they would like to modify the SIN, and the user can 
        * choose yes or no. If the user enters yes, they will be prompted for a SIN. If the SIN is 
        * invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifySocialInsuranceNumber(AllEmployees.Employee employee)
        {
            String response;                        // The user's response
            String error;                           // Data the user typed before hitting the enter key after the error message 
            String newStringSocialInsuranceNumber;  // String version of the new social insurance number
            int newSocialInsuranceNumber;           // The new social insurance number
            bool wasQuestionAnswered = false;       // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;             // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Social Insurance Number: " + employee.GetSocialInsuranceNumber().ToString()
                    + "\nWould you like to modify the social insurance number?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a social insurance number, 
                        and try to set the employee's social insurance number to the new number */
                        newStringSocialInsuranceNumber = UIMenu.GetInfoFromUser("Enter a new social insurance number: ");
                        newSocialInsuranceNumber = Convert.ToInt32(newStringSocialInsuranceNumber);
                        didModifyWork = employee.SetSocialInsuranceNumber(newSocialInsuranceNumber);
                        // Check if the employee's social insurance number has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The social insurance number you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // An exception is thrown if the string social insurance number isn't a number
            catch (FormatException)
            {
                error = UIMenu.GetInfoFromUser("The social insurance number you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifyDateOfBirth method is used to modify the date of birth of the specified 
        * employee. The method asks the user if they would like to modify the date of birth, and the 
        * user can choose yes or no. If the user enters yes, they will be prompted for a year, month 
        * and day. If the date of birth is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyDateOfBirth(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newStringYear;               // The string birth year
            String newStringMonth;              // The string birth month
            String newStringDay;                // The string birth date
            int newIntYear;                     // The int birth year
            int newIntMonth;                    // The int birth month
            int newIntDay;                      // The int birth date
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Date Of Birth: " + employee.GetDateOfBirthString()
                    + "\nWould you like to modify the date of birth?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a year, month, and day 
                        * and try to set the employee's date of birth to the new date of birth */
                        newStringYear = UIMenu.GetInfoFromUser("Enter a new birth year (yyyy): ");
                        newIntYear = Convert.ToInt32(newStringYear);
                        newStringMonth = UIMenu.GetInfoFromUser("Enter a new birth month (mm): ");
                        newIntMonth = Convert.ToInt32(newStringMonth);
                        newStringDay = UIMenu.GetInfoFromUser("Enter a new birth day (dd): ");
                        newIntDay = Convert.ToInt32(newStringDay);

                        DateTime newDateOfBirth = new DateTime(newIntYear, newIntMonth, newIntDay);
                        didModifyWork = employee.SetDateOfBirth(newDateOfBirth);
                        // Check if the employee's date of birth has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The date of birth has invalid values, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // Exceptions are thrown if the date of birth has invalid or out-of-range values
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("The date of birth has invalid values, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifyEmployeeType method is used to modify the type of the specified 
        * employee. The method asks the user if they would like to modify the type, and the 
        * user can choose yes or no. If the user enters yes, they will be prompted for a type. 
        * If the type is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyEmployeeType(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newEmployeeType;             // The new employee type
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            /* Keep looping over the employee property until the user 
            * chooses to modify or not modify the propery */
            while (wasQuestionAnswered == false)
            {
                // Display the employee property and a question, then get a response from the user
                response = UIMenu.GetInfoFromUser("Employee Type: " + employee.GetEmployeeType()
                + "\nWould you like to modify the employee type?\nType 'Y' for yes, and 'N' for no.");

                // Check if the response was 'Y', 'N', or neither
                if (response == "Y")
                {
                    /* If 'Y' is the reponse, ask the user for a new employee type, 
                    * and try to set the employee's type to the new type */
                    newEmployeeType = UIMenu.GetInfoFromUser("Enter a new employee type (FT, PT, CT, or SN): ");
                    didModifyWork = employee.SetEmployeeType(newEmployeeType);
                    // Check if the employee's type has been changed
                    if (didModifyWork == false)
                    {
                        /* If didModifyWork is false, that means the user's entered value 
                        * was invalid, so inform the user that the value will remain unchanged */
                        error = UIMenu.GetInfoFromUser("The employee type you entered was invalid, so the type will remain unchanged.\nHit enter to continue.");
                    }
                    wasQuestionAnswered = true;
                }
                else if (response == "N")
                {
                    /* If 'N' is the response, then the user has chosen not 
                    * to modify this property, so leave the while loop */
                    wasQuestionAnswered = true;
                }
                else
                {
                    /* If invalid characters were entered, then the question 
                    * wasn't answered, so stay in the while loop */
                    wasQuestionAnswered = false;
                }
            }
        }

        /**
        * \brief The ModifyDateOfHire method is used to modify the date of hire of the specified 
        * employee. The method asks the user if they would like to modify the date of hire, and the 
        * user can choose yes or no. If the user enters yes, they will be prompted for a year, month 
        * and day. If the date of hire is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyDateOfHire(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newStringYear;               // The string hire year
            String newStringMonth;              // The string hire month
            String newStringDay;                // The string hire date
            int newIntYear;                     // The int hire year
            int newIntMonth;                    // The int hire month
            int newIntDay;                      // The int hire date
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Date Of Hire: " + ((AllEmployees.FulltimeEmployee)employee).GetDateOfHire().ToString()
                    + "\nWould you like to modify the date of hire?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a year, month, and day 
                        * and try to set the employee's date of hire to the new date of hire */
                        newStringYear = UIMenu.GetInfoFromUser("Enter a new hire year (yyyy): ");
                        newIntYear = Convert.ToInt32(newStringYear);
                        newStringMonth = UIMenu.GetInfoFromUser("Enter a new hire month (mm): ");
                        newIntMonth = Convert.ToInt32(newStringMonth);
                        newStringDay = UIMenu.GetInfoFromUser("Enter a new hire day (dd): ");
                        newIntDay = Convert.ToInt32(newStringDay);

                        DateTime newDateOfHire = new DateTime(newIntYear, newIntMonth, newIntDay);
                        didModifyWork = ((AllEmployees.FulltimeEmployee)employee).SetDateOfHire(newDateOfHire);
                        // Check if the employee's date of hire has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The date of hire has invalid values, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // Exceptions are thrown if the date of hire has invalid or out-of-range values
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("The date of hire has invalid values, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifyDateOfTermination method is used to modify the date of termination of the 
        * specified employee. The method asks the user if they would like to modify the date of termination, 
        * and the user can choose yes or no. If the user enters yes, they will be prompted for a year, month 
        * and day. If the date of termination is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyDateOfTermination(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newStringYear;               // The string termination year
            String newStringMonth;              // The string termination month
            String newStringDay;                // The string termination date
            int newIntYear;                     // The int termination year
            int newIntMonth;                    // The int termination month
            int newIntDay;                      // The int termination date
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Date Of Termination: " + ((AllEmployees.FulltimeEmployee)employee).GetDateOfTermination().ToString()
                    + "\nWould you like to modify the date of termination?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a year, month, and day and try 
                        * to set the employee's date of termination to the new date of termination */
                        newStringYear = UIMenu.GetInfoFromUser("Enter a new termination year (yyyy): ");
                        newIntYear = Convert.ToInt32(newStringYear);
                        newStringMonth = UIMenu.GetInfoFromUser("Enter a new termination month (mm): ");
                        newIntMonth = Convert.ToInt32(newStringMonth);
                        newStringDay = UIMenu.GetInfoFromUser("Enter a new termination day (dd): ");
                        newIntDay = Convert.ToInt32(newStringDay);

                        DateTime newDateOfTermination = new DateTime(newIntYear, newIntMonth, newIntDay);
                        didModifyWork = ((AllEmployees.FulltimeEmployee)employee).SetDateOfTermination(newDateOfTermination);
                        // Check if the employee's date of termination has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The date of termination has invalid values, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // Exceptions are thrown if the date of termination has invalid or out-of-range values
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("The date of termination has invalid values, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifySalary method is used to modify the salary of the specified 
        * employee. The method asks the user if they would like to modify the salary, 
        * and the user can choose yes or no. If the user enters yes, they will be prompted 
        * for a new salary. If the salary is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifySalary(AllEmployees.Employee employee)
        {
            String response;                        // The user's response
            String error;                           // Data the user typed before hitting the enter key after the error message  
            String newStringSalary;                 // String version of the new salary
            float newFloatSalary;                   // The new float salary
            bool wasQuestionAnswered = false;       // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;             // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Salary: " + ((AllEmployees.FulltimeEmployee)employee).GetSalary().ToString()
                    + "\nWould you like to modify the salary?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a salary, 
                        and try to set the employee's salary to the new salary */
                        newStringSalary = UIMenu.GetInfoFromUser("Enter a new salary, in dollars: ");
                        newFloatSalary = float.Parse(newStringSalary);
                        didModifyWork = ((AllEmployees.FulltimeEmployee)employee).SetSalary(newFloatSalary);
                        // Check if the employee's salary has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The salary you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // An exception is thrown if the salary isn't a number
            catch (FormatException)
            {
                error = UIMenu.GetInfoFromUser("The salary you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifyHourlyRate method is used to modify the hourly rate of the specified 
        * employee. The method asks the user if they would like to modify the hourly rate, 
        * and the user can choose yes or no. If the user enters yes, they will be prompted 
        * for a new hourly rate. If the hourly rate is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyHourlyRate(AllEmployees.Employee employee)
        {
            String response;                        // The user's response
            String error;                           // Data the user typed before hitting the enter key after the error message 
            String newStringHourlyRate;             // String version of the new hourly rate
            float newFloatHourlyRate;               // The new float hourly rate
            bool wasQuestionAnswered = false;       // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;             // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Hourly Rate: " + ((AllEmployees.ParttimeEmployee)employee).GetHourlyRate().ToString()
                    + "\nWould you like to modify the hourly rate?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for an hourly rate
                        and try to set the employee's hourly rate to the new rate */
                        newStringHourlyRate = UIMenu.GetInfoFromUser("Enter a new hourly rate, in dollars: ");
                        newFloatHourlyRate = float.Parse(newStringHourlyRate);
                        didModifyWork = ((AllEmployees.ParttimeEmployee)employee).SetHourlyRate(newFloatHourlyRate);
                        // Check if the employee's hourly rate has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The hourly rate you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // An exception is thrown if the string hourly rate isn't a number
            catch (FormatException)
            {
                error = UIMenu.GetInfoFromUser("The hourly rate you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifyContractStartDate method is used to modify the contract start date of 
        * the specified employee. The method asks the user if they would like to modify the contract 
        * start date, and the user can choose yes or no. If the user enters yes, they will be prompted 
        * for a new contract start date. If the new date is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyContractStartDate(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newStringYear;               // The string contract start year
            String newStringMonth;              // The string contract start month
            String newStringDay;                // The string contract start date
            int newIntYear;                     // The int contract start year
            int newIntMonth;                    // The int contract start month
            int newIntDay;                      // The int contract start date
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Contract Start Date: " + ((AllEmployees.ContractEmployee)employee).GetContractStartDateString()
                    + "\nWould you like to modify the contract start date?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a year, month, and day and try 
                        * to set the employee's contract start date to the new contract start date */
                        newStringYear = UIMenu.GetInfoFromUser("Enter a new contract start year (yyyy): ");
                        newIntYear = Convert.ToInt32(newStringYear);
                        newStringMonth = UIMenu.GetInfoFromUser("Enter a new contract start month (mm): ");
                        newIntMonth = Convert.ToInt32(newStringMonth);
                        newStringDay = UIMenu.GetInfoFromUser("Enter a new contract start day (dd): ");
                        newIntDay = Convert.ToInt32(newStringDay);

                        DateTime newContractStartDate = new DateTime(newIntYear, newIntMonth, newIntDay);
                        didModifyWork = ((AllEmployees.ContractEmployee)employee).SetContractStartDate(newContractStartDate);
                        // Check if the employee's contract start date has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The contract start date has invalid values, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // Exceptions are thrown if the contract start date has invalid or out-of-range values
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("The contract start date has invalid values, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifyContractStopDate method is used to modify the contract stop date of 
        * the specified employee. The method asks the user if they would like to modify the contract 
        * stop date, and the user can choose yes or no. If the user enters yes, they will be prompted 
        * for a new contract stop date. If the new date is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyContractStopDate(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newStringYear;               // The string contract stop year
            String newStringMonth;              // The string contract stop month
            String newStringDay;                // The string contract stop date
            int newIntYear;                     // The int contract stop year
            int newIntMonth;                    // The int contract stop month
            int newIntDay;                      // The int contract stop date
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Contract Stop Date: " + ((AllEmployees.ContractEmployee)employee).GetContractStopDateString()
                    + "\nWould you like to modify the contract stop date?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a year, month, and day and try 
                        * to set the employee's contract stop date to the new contract stop date */
                        newStringYear = UIMenu.GetInfoFromUser("Enter a new contract stop year (yyyy): ");
                        newIntYear = Convert.ToInt32(newStringYear);
                        newStringMonth = UIMenu.GetInfoFromUser("Enter a new contract stop month (mm): ");
                        newIntMonth = Convert.ToInt32(newStringMonth);
                        newStringDay = UIMenu.GetInfoFromUser("Enter a new contract stop day (dd): ");
                        newIntDay = Convert.ToInt32(newStringDay);

                        DateTime newContractStopDate = new DateTime(newIntYear, newIntMonth, newIntDay);
                        didModifyWork = ((AllEmployees.ContractEmployee)employee).SetContractStopDate(newContractStopDate);
                        // Check if the employee's contract start date has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The contract stop date has invalid values, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // Exceptions are thrown if the contract stop date has invalid or out-of-range values
            catch (Exception)
            {
                error = UIMenu.GetInfoFromUser("The contract stop date has invalid values, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifyFixedContractAmount method is used to modify the fixed contract amount of 
        * the specified employee. The method asks the user if they would like to modify the contract 
        * amount, and the user can choose yes or no. If the user enters yes, they will be prompted 
        * for a new fixed contract amount. If the new amount is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyFixedContractAmount(AllEmployees.Employee employee)
        {
            String response;                        // The user's response
            String error;                           // Data the user typed before hitting the enter key after the error message 
            String newStringContractAmount;         // String version of the new fixed contract amount
            float newFloatContractAmount;           // The new float fixed contract amount
            bool wasQuestionAnswered = false;       // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;             // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Fixed Contract Amount: " + ((AllEmployees.ContractEmployee)employee).GetFixedContractAmount().ToString()
                    + "\nWould you like to modify the fixed contract amount?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a fixed contract amount and 
                        * try to set the employee's fixed contract amount to the new contract amount */
                        newStringContractAmount = UIMenu.GetInfoFromUser("Enter a new fixed contract amount, in dollars: ");
                        newFloatContractAmount = float.Parse(newStringContractAmount);
                        didModifyWork = ((AllEmployees.ContractEmployee)employee).SetFixedContractAmount(newFloatContractAmount);
                        // Check if the employee's fixed contract amount has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The fixed contract amount you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // An exception is thrown if the string hourly rate isn't a number
            catch (FormatException)
            {
                error = UIMenu.GetInfoFromUser("The fixed contract amount you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The ModifySeason method is used to modify the season of the specified 
        * employee. The method asks the user if they would like to modify the season, 
        * and the user can choose yes or no. If the user enters yes, they will be prompted 
        * for a new season. If the new season is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifySeason(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message 
            String newSeason;                   // The new season the employee works in
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            /* Keep looping over the employee property until the user 
            * chooses to modify or not modify the propery */
            while (wasQuestionAnswered == false)
            {
                // Display the employee property and a question, then get a response from the user
                response = UIMenu.GetInfoFromUser("Season: " + ((AllEmployees.SeasonalEmployee)employee).GetSeason()
                + "\nWould you like to modify the season?\nType 'Y' for yes, and 'N' for no.");

                // Check if the response was 'Y', 'N', or neither
                if (response == "Y")
                {
                    /* If 'Y' is the reponse, ask the user for a season, 
                    and try to set the employee's season to the new season */
                    newSeason = UIMenu.GetInfoFromUser("Enter a new season: ");
                    didModifyWork = ((AllEmployees.SeasonalEmployee)employee).SetSeason(newSeason);
                    // Check if the employee's season has been changed
                    if (didModifyWork == false)
                    {
                        /* If didModifyWork is false, that means the user's entered value 
                        * was invalid, so inform the user that the value will remain unchanged */
                        error = UIMenu.GetInfoFromUser("The season you entered was invalid, so the season will remain unchanged.\nHit enter to continue.");
                    }
                    wasQuestionAnswered = true;
                }
                else if (response == "N")
                {
                    /* If 'N' is the response, then the user has chosen not 
                    * to modify this property, so leave the while loop */
                    wasQuestionAnswered = true;
                }
                else
                {
                    /* If invalid characters were entered, then the question 
                    * wasn't answered, so stay in the while loop */
                    wasQuestionAnswered = false;
                }
            }
        }

        /**
        * \brief The ModifyPiecePay method is used to modify the piece pay of the specified 
        * employee. The method asks the user if they would like to modify the piece pay, 
        * and the user can choose yes or no. If the user enters yes, they will be prompted 
        * for a new piece pay. If the new piece pay is invalid, the user will be informed.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to modify
        * 
        * \return n/a
        */
        private void ModifyPiecePay(AllEmployees.Employee employee)
        {
            String response;                    // The user's response
            String error;                       // Data the user typed before hitting the enter key after the error message  
            String newStringPiecePay;           // String version of the piece pay
            float newFloatPiecePay;             // The new float piece pay
            bool wasQuestionAnswered = false;   // Did the user choose 'Y' or 'N' yet?
            bool didModifyWork = false;         // Did the modify on the employee property work?

            try
            {
                /* Keep looping over the employee property until the user 
                * chooses to modify or not modify the propery */
                while (wasQuestionAnswered == false)
                {
                    // Display the employee property and a question, then get a response from the user
                    response = UIMenu.GetInfoFromUser("Piece Pay: " + ((AllEmployees.SeasonalEmployee)employee).GetPiecePay().ToString()
                    + "\nWould you like to modify the piece pay?\nType 'Y' for yes, and 'N' for no.");

                    // Check if the response was 'Y', 'N', or neither
                    if (response == "Y")
                    {
                        /* If 'Y' is the reponse, ask the user for a piece pay and 
                        * try to set the employee's piece pay to the new piece pay */
                        newStringPiecePay = UIMenu.GetInfoFromUser("Enter a new piece pay, in dollars: ");
                        newFloatPiecePay = float.Parse(newStringPiecePay);
                        didModifyWork = ((AllEmployees.SeasonalEmployee)employee).SetPiecePay(newFloatPiecePay);
                        // Check if the employee's piece pay has been changed
                        if (didModifyWork == false)
                        {
                            /* If didModifyWork is false, that means the user's entered value 
                            * was invalid, so inform the user that the value will remain unchanged */
                            error = UIMenu.GetInfoFromUser("The piece pay you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
                        }
                        wasQuestionAnswered = true;
                    }
                    else if (response == "N")
                    {
                        /* If 'N' is the response, then the user has chosen not 
                        * to modify this property, so leave the while loop */
                        wasQuestionAnswered = true;
                    }
                    else
                    {
                        /* If invalid characters were entered, then the question 
                        * wasn't answered, so stay in the while loop */
                        wasQuestionAnswered = false;
                    }
                }
            }
            // An exception is thrown if the  piece pay isn't a number
            catch (FormatException)
            {
                error = UIMenu.GetInfoFromUser("The piece pay you entered was invalid, so it will remain unchanged.\nHit enter to continue.");
            }
        }

        /**
        * \brief The SelectEmployee method is used to select an employee from a list. The method 
        * loops through an employee list and displays each employee individually to the user. When 
        * an employee is displayed to the user, the user will decide if they want to select the 
        * displayed employee or not.
        * 
        * \details <b>Details</b>
        * 
        * \param n/a
        * 
        * \return employee - <b>AllEmployees.Employee</b> - The selected employee
        */
        public AllEmployees.Employee SelectEmployee()
        {
            AllEmployees.Employee selectedEmployee = new AllEmployees.Employee();   // A variable to save the selected employee

            // Go through all employees in the list
            foreach (AllEmployees.Employee employee in listOfEmployees)
            {
                selectedEmployee = IsThisTheDesiredEmployee(employee);
                // Check if the returned employee is the employee the user selected
                if ((selectedEmployee.GetFirstName() != "") && (selectedEmployee.GetLastName() != ""))
                {
                    /* If properties of the selectedEmployee aren't blank, 
                    * that means this is the selected employee */
                    break;
                }
            }
            return selectedEmployee;    // Return the selected employee
        }

        /**
        * \brief The SelectEmployeeByFirstName method is used to select an employee from a list. 
        * The method loops through an employee list and displays each employee individually to the 
        * user that has a first name that matches the firstName parameter. The user will decide if 
        * they want to select a displayed employee or not.
        * 
        * \details <b>Details</b>
        * 
        * \param firstName - <b>string</b> - The first name of the employee to select
        * 
        * \return employee - <b>AllEmployees.Employee</b> - The selected employee
        */
        public AllEmployees.Employee SelectEmployeeByFirstName(string firstName)
        {
            AllEmployees.Employee selectedEmployee = new AllEmployees.Employee();   // A variable to save the selected employee

            // Go through all employees in the list
            foreach (AllEmployees.Employee employee in listOfEmployees)
            {
                // Only loop through employees that have a first name that matches the firstName parameter
                if (employee.GetFirstName() == firstName)
                {
                    selectedEmployee = IsThisTheDesiredEmployee(employee);
                    // Check if the returned employee is the employee the user selected
                    if ((selectedEmployee.GetFirstName() != "") && (selectedEmployee.GetLastName() != ""))
                    {
                        /* If properties of the selectedEmployee aren't blank, 
                        * that means this is the selected employee */
                        break;
                    }
                }
            }
            return selectedEmployee;    // Return the selected employee
        }

        /**
        * \brief The SelectEmployeeByFullName method is used to select an employee from a list. 
        * The method loops through an employee list and displays each employee individually to the 
        * user that has a first name and last name that matches the firstName and lastName parameter. 
        * The user will decide if they want to select a displayed employee or not.
        * 
        * \details <b>Details</b>
        * 
        * \param firstName - <b>string</b> - The first name of the employee to select
        * \param lastName - <b>string</b> - The last name of the employee to select
        * 
        * \return employee - <b>AllEmployees.Employee</b> - The selected employee
        */
        public AllEmployees.Employee SelectEmployeeByFullName(string firstName, string lastName)
        {
            AllEmployees.Employee selectedEmployee = new AllEmployees.Employee();   // A variable to save the selected employee

            // Go through all employees in the list
            foreach (AllEmployees.Employee employee in listOfEmployees)
            {
                /* Only loop through employees that have a first name that matches the firstName 
                * parameter and a last name that matches the last name parameter */
                if ((employee.GetFirstName() == firstName) && (employee.GetLastName() == lastName))
                {
                    selectedEmployee = IsThisTheDesiredEmployee(employee);
                    // Check if the returned employee is the employee the user selected
                    if ((selectedEmployee.GetFirstName() != "") && (selectedEmployee.GetLastName() != ""))
                    {
                        /* If properties of the selectedEmployee aren't blank, 
                        * that means this is the selected employee */
                        break;
                    }
                }
            }
            return selectedEmployee;    // Return the selected employee
        }

        /**
        * \brief The SelectEmployeeBySIN method is used to select an employee from a list. The 
        * method loops through an employee list and displays each employee individually to the 
        * user that has a SIN that matches the socialInsuranceNumber parameter. The user will 
        * decide if they want to select a displayed employee or not.
        * 
        * \details <b>Details</b>
        * 
        * \param socialInsuranceNumber - <b>int</b> - The SIN of the employee to select
        * 
        * \return employee - <b>AllEmployees.Employee</b> - The selected employee
        */
        public AllEmployees.Employee SelectEmployeeBySIN(int socialInsuranceNumber)
        {
            AllEmployees.Employee selectedEmployee = new AllEmployees.Employee();   // A variable to save the selected employee

            // Go through all employees in the list
            foreach (AllEmployees.Employee employee in listOfEmployees)
            {
                // Only loop through employees that have a first name that matches the firstName parameter
                if (employee.GetSocialInsuranceNumber() == socialInsuranceNumber)
                {
                    selectedEmployee = IsThisTheDesiredEmployee(employee);
                    // Check if the returned employee is the employee the user selected
                    if ((selectedEmployee.GetFirstName() != "") && (selectedEmployee.GetLastName() != ""))
                    {
                        /* If properties of the selectedEmployee aren't blank, 
                        * that means this is the selected employee */
                        break;
                    }
                }
            }
            return selectedEmployee;    // Return the selected employee
        }

        /**
        * \brief The SelectEmployeeByDOB method is used to select an employee from a list. The 
        * method loops through an employee list and displays each employee individually to the 
        * user that has a DOB that matches the dateOfBirth parameter. The user will decide if 
        * they want to select a displayed employee or not.
        * 
        * \details <b>Details</b>
        * 
        * \param dateOfBirth - <b>DateTime</b> - The DOB of the employee to select
        * 
        * \return employee - <b>AllEmployees.Employee</b> - The selected employee
        */
        public AllEmployees.Employee SelectEmployeeByDOB(DateTime dateOfBirth)
        {
            AllEmployees.Employee selectedEmployee = new AllEmployees.Employee();   // A variable to save the selected employee

            // Go through all employees in the list
            foreach (AllEmployees.Employee employee in listOfEmployees)
            {
                // Only loop through employees that have a date of birth that matches the dateOfBirth parameter
                if (employee.GetDateOfBirth() == dateOfBirth)
                {
                    selectedEmployee = IsThisTheDesiredEmployee(employee);
                    // Check if the returned employee is the employee the user selected
                    if ((selectedEmployee.GetFirstName() != "") && (selectedEmployee.GetLastName() != ""))
                    {
                        /* If properties of the selectedEmployee aren't blank, 
                        * that means this is the selected employee */
                        break;
                    }
                }
            }

            return selectedEmployee;    // Return the selected employee
        }

        /**
        * \brief The IsThisTheDesiredEmployee method is used to determine if the user wants the 
        * specified employee. An employee's details are displayed to the user, and the user chooses 
        * whether or not they want to select that employee.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to check
        * 
        * \return employee - <b>AllEmployees.Employee</b> - The selected employee
        */
        private AllEmployees.Employee IsThisTheDesiredEmployee(AllEmployees.Employee employee)
        {
            String response = "";               // The user's response
            bool wasQuestionAnswered = false;   // Was the selection question answered?
            AllEmployees.Employee selectedEmployee = new AllEmployees.Employee();   // A variable to save the selected employee

            /* Keep looping over the same employee until the user 
            * chooses to select or not select the employee */
            while (wasQuestionAnswered == false)
            {
                // Display the employee details and a question, then get a response from the user
                response = DisplayEmployeeDetails(employee);

                // Check if the response was 'Y', 'N', or neither
                if (response == "Y")
                {
                    /* If 'Y' is the response, then the user has selected 
                    * this employee, so leave the while loop */
                    selectedEmployee = employee;
                    wasQuestionAnswered = true;
                }
                else if (response == "N")
                {
                    /* If 'N' is the response, then the user has not selected 
                    * this employee, so leave the while loop */
                    wasQuestionAnswered = true;
                }
                else
                {
                    /* If invalid characters were entered, then the question 
                    * wasn't answered, so stay in the while loop */
                    wasQuestionAnswered = false;
                }
            }

            /* Return the selected employee (or an employee 
            * with blank properties if the response was 'N') */
            return selectedEmployee;
        }

        /**
        * \brief The DisplayEmployeeDetail method is used to display a specified employee's details, 
        * and then ask the user if they would like to select the employee.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee that will be displayed
        * 
        * \return response - <b>String</b> - If the user wants to select the employee or not
        */
        private String DisplayEmployeeDetails(AllEmployees.Employee employee)
        {
            String response = "";

            // Determine the employee details to display depending on the employeeType, and get a response from the user
            if (employee.GetEmployeeType() == "FT")
            {
                response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.FulltimeEmployee)employee).Details()
                + "\nIs this the employee you would like to select?\nType 'Y' for yes, or 'N' for no:");
            }
            else if (employee.GetEmployeeType() == "PT")
            {
                response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.ParttimeEmployee)employee).Details()
                + "\nIs this the employee you would like to select?\nType 'Y' for yes, or 'N' for no:");
            }
            else if (employee.GetEmployeeType() == "CT")
            {
                response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.ContractEmployee)employee).Details()
                + "\nIs this the employee you would like to select?\nType 'Y' for yes, or 'N' for no:");
            }
            else if (employee.GetEmployeeType() == "SN")
            {
                response = UIMenu.GetInfoFromUser("Current Employee:\n" + ((AllEmployees.SeasonalEmployee)employee).Details()
                + "\nIs this the employee you would like to select?\nType 'Y' for yes, or 'N' for no:");
            }

            return response;
        }
    }
}
