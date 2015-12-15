/*
* FILE   : UIMenu.cs
* PROJECT  : INFO 2180 -Software Quality 1 - EMS
* PROGRAMMER : Jennifer Klimova
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the header for the UI Menu class that will allow the user to interact with the rest of the program
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCompany;
using Supporting;
using AllEmployees;

namespace Presentation
{
    /// \class UIMenu
    ///
    /// \brief <b>Brief Description</b> - This class dislays to the user a number of menus where the user then can access the database and either insert, delete, or make changes. 
    /// The UIMenu class is related to the container class as it pulls methods from the class. If the user inputs don't match up to 
    /// what is acceptable, the user will be notified appropriately. The UI Menu will not be unit tested. It will be hand tested. 
    /// \author <i>Jennifer Klimova</i>
    public class UIMenu
    {
        Container company;
        static int menuOptionFlag = 0;
        static bool cancel = false;
        /**
        * \brief The UIMenu constructor sets up a Container object to be used throughout the page.
        * 
        * \details <b>Details</b>
        * 
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return n/a
        */
        public UIMenu()
        {
            company = new Container();
        }

        /**
        * \brief The UIMenu constructor connects Container object to the repo.
        * 
        * \details <b>Details</b>
        * 
        * \param args - <b> Container repo </b> - contains the container repo object
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return n/a
        */
        public UIMenu(Container repo)
        {
            company = repo;
        }

        /**
        * \brief The ShowMainMenu method will display to the user, a UI menu.This menu 
        * allows the user to choose either to manage EMS database files, manage employees,
        * or to quit the program.  
        * 
        * \details <b>Details</b>
        * 
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return n/a
        */
        public bool ShowMainMenu()
        {
            string str;
            do
            {
                Console.WriteLine("Menu 1 : MAIN MENU");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Manage EMS DBase files");
                Console.WriteLine("2. Manage Employees");
                Console.WriteLine("9. Quit");

                str = Console.ReadLine();
                Console.Clear();
                switch (str)
                {
                    case "1":
                        // Goes to the second menu
                        ShowFileManagementMenu();
                        break;
                    case "2":
                        // Goes to the third menu
                        ShowEmployeeManagementMenu();
                        break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice.");
                        break;
                }
            } while (str != "9");
            return true;
        }

        /**
        * \brief The ShowFileManagementMenu method will display to the user, a UI menu.This 
        * menu allows the user to choose either to load the EMS database from the file, save 
        * an employee set to the EMS database, or return to the main menu.
        * 
        * \details <b>Details</b>
        * 
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return n/a
        */
        private void ShowFileManagementMenu()
        {
            string str;
            do
            {

                List<Employee> employeeList = new List<Employee>();

                Console.WriteLine("Menu 2 : FILE MANAGEMENT MENU");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Load EMS DBase from file");
                Console.WriteLine("2. Save Employee Set to EMS DBase file");
                Console.WriteLine("9. Return to Main Menu");

                str = Console.ReadLine();
                Console.Clear();

                switch (str)
                {
                    case "1":
                        // Gets employee list from the database
                        employeeList = FileIO.ReadAllRecords(@"..\..\..\..\DBase.txt");
                        foreach (Employee emp in employeeList)
                        {
                            // Add it to the list
                            company.AddEmployeeToList(emp);
                        }
                        Console.WriteLine(employeeList.Count().ToString() + " record(s) were read.");
                        break;
                    case "2":
                        // Send each individual employee back out to the database
                        employeeList = company.GetEmployeeList();

                        int validEmployee = FileIO.WriteRecord(employeeList, @"..\..\..\..\DBase.txt");
                        Console.WriteLine(validEmployee.ToString() + " employee(s) were saved from " + employeeList.Count().ToString() + " record(s)" );
                        break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice.");
                        break;
                }
            } while (str != "9");
        }

        /**
        * \brief The ShowEmployeeManagementMenu method will display to the user, a UI menu.This 
        * menu allows the user to choose either to display an employee set, create a new employee,
        * modify and exisiting employee, remove an existing employee, or return to the main menu.
        * 
        * \details <b>Details</b>
        * 
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return n/a
        */
        private void ShowEmployeeManagementMenu()
        {
            string str;
            do
            {
                // Employee object
                Employee employee = new Employee();

                Console.WriteLine("Menu 3 : EMPLOYEE MANAGEMENT MENU");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Display Employee Set");
                Console.WriteLine("2. Create a NEW Employee");
                Console.WriteLine("3. Modify an EXISTING Employee");
                Console.WriteLine("4. Remove an EXISTING Employee");
                Console.WriteLine("9. Return to Main Menu");

                str = Console.ReadLine();
                Console.Clear();
                string input;
                switch (str)
                {
                    case "1":
                        // Display the employees
                        company.DisplayAllEmployees();
                        Console.Clear();
                        break;
                    case "2":
                        // Go to menu 4
                        menuOptionFlag = 1;
                        employee = ShowEmployeeDetailsMenu();

                        if (cancel == false)
                        {
                            company.AddEmployeeToList(employee);
                            Console.WriteLine("Employee was successfully added");
                            Console.WriteLine("Press enter to continue");
                            input = Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "3":
                        // Go to menu 4
                        menuOptionFlag = 2;
                        employee = ShowEmployeeDetailsMenu();

                        if (cancel == false)
                        {
                            employee = company.SelectEmployee(employee);

                            if (employee.GetEmployeeType() != "")
                            {
                                company.ModifyEmployee(employee);
                                Console.WriteLine("Employee was successfully modified.");
                                Console.WriteLine("Press enter to continue");
                                input = Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Employee was not successfully modified.");
                                Console.WriteLine("Press enter to continue");
                                input = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        cancel = false;
                        break;
                    case "4":
                        cancel = false;
                        menuOptionFlag = 3;
                        // Give the employee details to the container class, and remove the applicable employee
                        employee = ShowEmployeeDetailsMenu();

                        if (cancel == false)
                        {
                            employee = company.SelectEmployee(employee);

                            if (employee.GetEmployeeType() != "")
                            {
                                company.RemoveEmployee(employee);
                                Console.WriteLine("Employee was successfully removed.");
                                Console.WriteLine("Press enter to continue");
                                input = Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Employee was not successfully removed.");
                                Console.WriteLine("Press enter to continue");
                                input = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice.");
                        break;
                }
            } while (str != "9");
        }

        /**
        * \brief The ShowEmployeeDetailsMenu method will display to the user, a UI menu.This 
        * menu allows the user to choose either to specify base employee details, to specify
        * values for any employee type, or return to the employee management menu.
        * 
        * \details <b>Details</b>
        * 
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return n/a
        */
        private Employee ShowEmployeeDetailsMenu()
        {
            // Variables 
            Employee employee = new Employee();
            string menuOption = "";

            while ((menuOption != "9") && (menuOption != "8"))
            {
                Console.WriteLine("Menu 4 : EMPLOYEE DETAILS MENU");
                Console.WriteLine("---------------------------------");

                if (employee.GetEmployeeType() == "")
                {
                    Console.WriteLine("1. Specify Base Employee Details.");
                    Console.WriteLine("8. Go Back");

                    menuOption = Console.ReadLine();
                    Console.Clear();

                    switch (menuOption)
                    {
                        case "1":
                            employee = GetBaseEmployeeDetails();
                            break;
                        case "8":
                            cancel = true;
                            break;
                        default:
                            Console.WriteLine("Invalid menu choice.");
                            break;
                    }
                }
                else if (employee.GetEmployeeType() == "FT")
                {
                    Console.WriteLine("1. Specify Base Employee Details.");
                    Console.WriteLine("2. Specify Date of Hire.");
                    Console.WriteLine("3. Specify Date of Termination.");
                    Console.WriteLine("4. Specify Employees Salary.");
                    Console.WriteLine("8. Go back.");
                    Console.WriteLine("9. Proceed.");

                    menuOption = Console.ReadLine();
                    Console.Clear();

                    switch (menuOption)
                    {
                        case "1":
                            employee = GetBaseEmployeeDetails();
                            break;
                        case "2":

                            Console.WriteLine("Specify the date of hire YYYY-MM-DD");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((FulltimeEmployee)employee).SetDateOfHire(Console.ReadLine()) == false)
                            {
                                Console.WriteLine("The date was not valid");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Specify the date of termination YYYY-MM-DD");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((FulltimeEmployee)employee).SetDateOfTermination(Console.ReadLine()) == false)
                            {
                                Console.WriteLine("The date was not valid");
                            }
                            break;
                        case "4":
                            Console.WriteLine("Specify the salary");
                            string salaryInput = Console.ReadLine();
                            double salaryAmount;
                            double.TryParse(salaryInput, out salaryAmount);
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((FulltimeEmployee)employee).SetSalary(salaryAmount) == false)
                            {
                                Console.WriteLine("The salary must be greater than 0");
                            }
                            break;
                        case "8":
                            cancel = true;
                            break;
                        case "9":
                            break;
                        default:
                            Console.WriteLine("Invalid menu choice.");
                            break;
                    }
                }
                else if (employee.GetEmployeeType() == "PT")
                {
                    Console.WriteLine("1. Specify Base Employee Details.");
                    Console.WriteLine("2. Specify Date of Hire.");
                    Console.WriteLine("3. Specify Date of Termination.");
                    Console.WriteLine("4. Specify Hourly Rate.");
                    Console.WriteLine("8. Go back.");
                    Console.WriteLine("9. Proceed.");

                    menuOption = Console.ReadLine();
                    Console.Clear();
                    
                    switch (menuOption)
                    {
                        case "1":
                            employee = GetBaseEmployeeDetails();
                            break;
                        case "2":
                            Console.WriteLine("Specify the date of hire YYYY-MM-DD");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((ParttimeEmployee)employee).SetDateOfHire(Console.ReadLine()) == false)
                            {
                                Console.WriteLine("The date was not valid");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Specify the date of termination YYYY-MM-DD");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((ParttimeEmployee)employee).SetDateOfTermination(Console.ReadLine()) == false)
                            {
                                Console.WriteLine("The date was not valid");
                            }
                            break;
                        case "4":
                            Console.WriteLine("Specify the hourly rate");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((ParttimeEmployee)employee).SetHourlyRate(double.Parse(Console.ReadLine())) == false)
                            {
                                Console.WriteLine("The hourly rate must be greater than 0");
                            }
                            break;
                        case "8":
                            cancel = true;
                            break;
                        case "9":
                            break;
                        default:
                            Console.WriteLine("Invalid menu choice.");
                            break;
                    }
                }
                else if (employee.GetEmployeeType() == "CT")
                {
                    Console.WriteLine("1. Specify Base Employee Details.");
                    Console.WriteLine("2. Specify Contract Start Date.");
                    Console.WriteLine("3. Specify Contract Stop Date.");
                    Console.WriteLine("4. Specify Fixed Contract Amount.");
                    Console.WriteLine("8. Go back.");
                    Console.WriteLine("9. Proceed.");

                    menuOption = Console.ReadLine();
                    Console.Clear();

                    switch (menuOption)
                    {
                        case "1":
                            employee = GetBaseEmployeeDetails();
                            break;
                        case "2":
                            Console.WriteLine("Specify the contract's start date YYYY-MM-DD");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((ContractEmployee)employee).SetContractStartDate(Console.ReadLine()) == false)
                            {
                                    Console.WriteLine("The date was not valid");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Specify the contract's stop date YYYY-MM-DD");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((ContractEmployee)employee).SetContractStopDate(Console.ReadLine()) == false)
                            {
                                Console.WriteLine("The date was not valid");
                            }
                            break;
                        case "4":
                            Console.WriteLine("Specify the fixed contract amount");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            string contractInput = Console.ReadLine();
                            double contractAmount;
                            double.TryParse(contractInput, out contractAmount);
                            if (((ContractEmployee)employee).SetFixedContractAmount(contractAmount) == false)
                            // first line get users input instead of try parse, just have the users input, second in if statement use the users input
                            {
                                Console.WriteLine("The fixed contract amount must be greater than 0");
                            }
                            break;
                        case "8":
                            cancel = true;
                            break;
                        case "9":
                            break;
                        default:
                            Console.WriteLine("Invalid menu choice.");
                            break;
                    }
                }
                else if (employee.GetEmployeeType() == "SN")
                {
                    Console.WriteLine("1. Specify Base Employee Details.");
                    Console.WriteLine("2. Specify the Season.");
                    Console.WriteLine("3. Specify the amount the employee receives per item produced.");
                    Console.WriteLine("8. Go back.");
                    Console.WriteLine("9. Proceed.");

                    menuOption = Console.ReadLine();
                    Console.Clear();

                    switch (menuOption)
                    {
                        case "1":
                            employee = GetBaseEmployeeDetails();
                            break;
                        case "2":
                            Console.WriteLine("Specify which season the employee is working in. The seaons can be: Summer, Winter, Fall, or Spring.");
                            // Sets the employee details to the users input and checks if it is in the proper format
                            string userInput = Console.ReadLine();
                            Console.Clear();
                            userInput = userInput.Substring(0, 1).ToUpper() + userInput.Substring(1).ToLower();
                            if (((SeasonalEmployee)employee).SetSeason(userInput) == false)
                            {
                                Console.WriteLine("The season must only be Summer, Winter, Fall, or Spring.");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Specify the piece pay of the employee");

                            string pieceInput = Console.ReadLine();
                            Console.Clear();
                            double pieceAmount;
                            double.TryParse(pieceInput, out pieceAmount);
                            // Sets the employee details to the users input and checks if it is in the proper format
                            if (((SeasonalEmployee)employee).SetPiecePay(pieceAmount) == false)
                            {
                                Console.WriteLine("The piece pay must be greater than 0");
                            }
                            break;
                        case "8":
                            cancel = true;
                            break;
                        case "9":
                            break;
                        default:
                            Console.WriteLine("Invalid menu choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("The employee type was invalid. Valid employee types are: FT, PT, CT, SN");
                }
            }
            return employee;
        }

        /**
        * \brief The GetBaseEmployeeDetails method will get the users input, set it in an employee object and return the employee object
        * to further process it. 
        * 
        * \details <b>Details</b>
        *  
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return - <b> Employee emp </b>- returns the employee with information
        */
        private static Employee GetBaseEmployeeDetails()
        {
            // Variables
            int employeeSIN;
            Employee tempEmp = new Employee();
            string empType;
            string empLName;
            string empFName;
            string empSIN;
            string empDOB;

            FulltimeEmployee FTemp = new FulltimeEmployee();
            ParttimeEmployee PTemp = new ParttimeEmployee();
            ContractEmployee CTemp = new ContractEmployee();
            SeasonalEmployee SNemp = new SeasonalEmployee();

            if (menuOptionFlag == 1)
            {
                Console.WriteLine("Employee Creation");
                Console.WriteLine("__________________");
                Console.WriteLine("Press enter to skip entry.");
            }
            else if (menuOptionFlag == 2)
            {
                Console.WriteLine("Employee Modification");
                Console.WriteLine("______________________");
                Console.WriteLine("Press enter to skip entry.");
            }
            else if (menuOptionFlag == 3)
            {
                Console.WriteLine("Employee Deletion");
                Console.WriteLine("__________________");
                Console.WriteLine("Press enter to skip entry.");
            }
            // Prompt for details
            bool error = false;
            do{
                if(error)
                {
                    Console.WriteLine("Invalid data was put in. Acceptable employee types are 'FT'  'PT'  'CT'  or  'SN'");
                }
                error = true;
                Console.WriteLine("Enter the employee type \n 'FT' for FullTime \n 'PT' for PartTime \n 'CT' for Contract \n 'SN' for Seasonal:");
                empType = Console.ReadLine();
                Console.Clear();
                empType = empType.ToUpper();

            } while (!tempEmp.SetEmployeeType(empType));
            error = false;

            if (tempEmp.GetEmployeeType() == "FT")
            {
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. There must only be letters, dashes, and/or apostrophes");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's last name:");
                    empLName = Console.ReadLine();
                    Console.Clear();
                } while (!((Employee)FTemp).SetLastName(empLName));
                error = false;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. There must only be letters, dashes, and/or apostrophes");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's first name:");
                    empFName = Console.ReadLine();
                    Console.Clear();
                } while (!((Employee)FTemp).SetFirstName(empFName));
                error = false;
                bool valid;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. A SIN number should be in the format of ### ### ###");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's SIN number:");
                    empSIN = Console.ReadLine();
                    Console.Clear();
                    empSIN = empSIN.Replace(" ", "");
                    valid = int.TryParse(empSIN, out employeeSIN);
                } while (!((Employee)FTemp).SetSocialInsuranceNumber(employeeSIN) || (!valid && empSIN != ""));
                error = false;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. The date must be in the format of  YYYY-MM-DD");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's date of birth in the format: YYYY-MM-DD");
                    empDOB = Console.ReadLine();
                    Console.Clear();
                } while (!FTemp.SetDateOfBirth(empDOB));
                error = false;
            }
            else if (tempEmp.GetEmployeeType() == "PT")
            {
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. There must only be letters, dashes, and/or apostrophes");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's last name:");
                    empLName = Console.ReadLine();
                    Console.Clear();
                } while (!((Employee)PTemp).SetLastName(empLName));
                error = false;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. There must only be letters, dashes, and/or apostrophes");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's first name:");
                    empFName = Console.ReadLine();
                    Console.Clear();
                } while (!((Employee)PTemp).SetFirstName(empFName));
                error = false;
                bool valid;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. A SIN number should be in the format of ### ### ###");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's SIN number:");
                    empSIN = Console.ReadLine();
                    Console.Clear();
                    empSIN.Replace(" ", "");
                    valid = int.TryParse(empSIN, out employeeSIN);
                } while (!((Employee)PTemp).SetSocialInsuranceNumber(employeeSIN) || (!valid && empSIN != ""));
                error = false;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. The date must be in the format of  YYYY-MM-DD");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's date of birth in the format: YYYY-MM-DD");
                    empDOB = Console.ReadLine();
                    Console.Clear();
                } while (!PTemp.SetDateOfBirth(empDOB));
                error = false;
            }
            else if (tempEmp.GetEmployeeType() == "CT")
            {
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. There must only be letters, dashes, and/or apostrophes");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's coorporation name:");
                    empLName = Console.ReadLine();
                    Console.Clear();
                } while (!((Employee)CTemp).SetLastName(empLName));
                error = false;
                bool valid;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. A Business Number number should be in the format of #### #####");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's Business Number number:");
                    empSIN = Console.ReadLine();
                    Console.Clear();
                    empSIN.Replace(" ", "");
                    valid = int.TryParse(empSIN, out employeeSIN);
                } while (!((Employee)CTemp).SetSocialInsuranceNumber(employeeSIN) || (!valid && empSIN != ""));
                error = false;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. The date must be in the format of YYYY-MM-DD. \nThe last 2 digits of the year should match the first 2 digits of the Buisness Number");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's date of incorporation in the format: YYYY-MM-DD");
                    empDOB = Console.ReadLine();
                    Console.Clear();
                } while (!CTemp.SetDateOfBirth(empDOB));
                error = false;
            }
            else if (tempEmp.GetEmployeeType() == "SN")
            {
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. There must only be letters, dashes, and/or apostrophes");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's last name:");
                    empLName = Console.ReadLine();
                    Console.Clear();                    
                } while (!((Employee)SNemp).SetLastName(empLName));
                error = false;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. There must only be letters, dashes, and/or apostrophes");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's first name:");
                    empFName = Console.ReadLine();
                    Console.Clear();
                } while (!((Employee)SNemp).SetFirstName(empFName));
                error = false;
                bool valid;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. A SIN number should be in the format of ### ### ###");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's SIN number:");
                    empSIN = Console.ReadLine();
                    Console.Clear();
                    empSIN.Replace(" ", "");
                    valid = int.TryParse(empSIN, out employeeSIN);
                } while (!((Employee)SNemp).SetSocialInsuranceNumber(employeeSIN) || (!valid && empSIN != ""));
                error = false;
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Invalid data was put in. The date must be in the format of  YYYY-MM-DD");
                    }
                    error = true;
                    Console.WriteLine("Enter the employee's date of birth in the format: YYYY-MM-DD");
                    empDOB = Console.ReadLine();
                    Console.Clear();
                } while (!SNemp.SetDateOfBirth(empDOB));
                error = false;
            }

            if (tempEmp.GetEmployeeType() == "FT")
            {
                return FTemp;
            }

            else if (tempEmp.GetEmployeeType() == "PT")
            {
                return PTemp;
            }

            else if (tempEmp.GetEmployeeType() == "CT")
            {
                return CTemp;
            }

            else if (tempEmp.GetEmployeeType() == "SN")
            {
                return SNemp;
            }

            return tempEmp;
        }

        /**
        * \brief The GetInfoFromUser method will get the users input and return it 
        * to further process it. 
        * 
        * \details <b>Details</b>
        *  
        * \param args - <b>string UserPrompt</b> - contains the users input
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return - <b> string UserPrompt</b> - returns the users information
        */
        public static String GetInfoFromUser(String UserPrompt)
        {
            Console.WriteLine(UserPrompt);
            string str = Console.ReadLine();
            return str;
        }

        /**
        * \brief The ShowError method displays an appropriate error message to the user. 
        * 
        * \details <b>Details</b>
        * 
        * \param args - <b> string errorMessage </b> - contains the message
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return - n/a
        */
        public static void ShowError(String errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}