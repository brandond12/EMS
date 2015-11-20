/*
* FILE   : UIMenu.cs
* PROJECT  : INFO 2180 -Software Quality 1  - Project - Fall 2015
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


namespace Presentation
{
    /// \class UIMenu
    ///
    /// \brief <b>Brief Description</b> - This class dislays to the user a number of menus where the user then can access the database and either insert, delete, or make changes.
    ///
    /// \author <i>Jennifer Klimova</i>
    public class UIMenu
    {
        Container company;
        //new constructor
        public UIMenu()
        {
            company = new Container();
        }

        //new constructor
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
            Console.WriteLine("Menu 1 : MAIN MENU");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Manage EMS DBase files");
            Console.WriteLine("2. Manage Employees");
            Console.WriteLine("9. Quit");

            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    ShowFileManagementMenu();
                    break;
                case "2":
                    ShowEmployeeManagementMenu();
                    break;
                case "9":
                    break;
            }
            return true;//temp here
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
            Console.WriteLine("Menu 2 : FILE MANAGEMENT MENU");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Load EMS DBase from file");
            Console.WriteLine("2. Save Employee Set to EMS DBase file");
            Console.WriteLine("9. Return to Main Menu");

            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    //load dbs from file
                    break;
                case "2":
                    //save employee
                    break;
                case "9":
                    ShowMainMenu();
                    break;
            }
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
            Console.WriteLine("Menu 3 : EMPLOYEE MANAGEMENT MENU");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Display Employee Set");
            Console.WriteLine("2. Create a NEW Employee");
            Console.WriteLine("3. Modify an EXISTING Employee");
            Console.WriteLine("4. Remove an EXISTING Employee");
            Console.WriteLine("9. Return to Main Menu");

            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    //display employee
                    break;
                case "2":
                    ShowEmployeeDetailsMenu();
                    break;
                case "3":
                    ShowEmployeeDetailsMenu();
                    break;
                case "4":
                    ShowEmployeeDetailsMenu(); //this can change
                    break;
                case "9":
                    ShowMainMenu();
                    break;
            }
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
        private void ShowEmployeeDetailsMenu()
        {
            Console.WriteLine("Menu 4 : EMPLOYEE DETAILS MENU");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Specify Base Employee Details");
            Console.WriteLine("2. Specify Full-Time Employee Details");
            Console.WriteLine("3. Specify Part-Time Employee Details");
            Console.WriteLine("4. Specify Contract Employee Details");
            Console.WriteLine("5. Specify Seasonal Employee Details");
            Console.WriteLine("9. Return to Employee Management Menu");

            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    company.AddEmployee();
                    break;
                case "2":
                    company.AddEmployee();
                    break;
                case "3":
                    company.AddEmployee();
                    break;
                case "4":
                    company.AddEmployee();
                    break;
                case "5":
                    company.AddEmployee();
                    break;
                case "9":
                    ShowEmployeeManagementMenu();
                    break;
            }
        }

        /**
        * \brief The ShowFindEmployeeMenu method will display to the user, a UI menu.This 
        * menu allows the user to search for a specific employee in the database. 
        * 
        * \details <b>Details</b>
        * 
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return - AllEmployees.Employee - returns an employee object 
        */
        public static AllEmployees.Employee ShowFindEmployeeMenu()
        {
            //select a method of finding an employee
            return new AllEmployees.Employee();
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
        * \return - string UserPrompt - returns the users information
        */
        public static String GetInfoFromUser(String UserPrompt)
        {

            return " "; //temp to remove errors
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

        }
    }
}
