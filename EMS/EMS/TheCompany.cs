using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    class TheCompany
    {
        private List<AllEmployees.Employee> Employees;  // List that holds all of the employees

        /**
        * \brief The Main method is the starting point of code execution. This method 
        * calls the first menu from the UIMenu class, and the method will close the 
        * program when the user chooses to end the program.
        * 
        * \details <b>Details</b>
        * 
        * \param args - <b>string[]</b> - An array containing command line arguments
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return n/a
        */
        static void Main(string[] args)
        {
            //loop until user closes program
               //call first menu option
               //exception thrown then user whats to leave
        }

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
        public void addEmployee()
        {
            //use GetInfoFromUser from UI
            //build a Employee
            //save employee
        }

        /**
        * \brief The removeEmployee method is used to remove a specified employee from a list.
        * 
        * \details <b>Details</b>
        * 
        * \param employee - <b>AllEmployees.Employee</b> - The employee to remove from a list
        * 
        * \return n/a
        */
        public void removeEmployee(AllEmployees.Employee employee)
        {
            //delete the given employee
        }

        /**
        * \brief The modifyEmployee method is used to modify a specified employee. The method goes 
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
        public void modifyEmployee(AllEmployees.Employee employee)
        {
            //given employee
            //show each data member 
        }

        /**
        * \brief The selectEmployee method is used to select an employee from a list. The method 
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
        public AllEmployees.Employee selectEmployee()
        {
            //search all employees
            return new AllEmployees.Employee();
        }

        /**
        * \brief The selectEmployeeByFirstName method is used to select an employee from a list. 
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
        public AllEmployees.Employee selectEmployeeByFirstName(string firstName)
        {

            return new AllEmployees.Employee();
        }

        /**
        * \brief The selectEmployeeByFullName method is used to select an employee from a list. 
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
        public AllEmployees.Employee selectEmployeeByFullName(string firstName, string lastName)
        {

            return new AllEmployees.Employee();
        }

        /**
        * \brief The selectEmployeeBySIN method is used to select an employee from a list. The 
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
        public AllEmployees.Employee selectEmployeeBySIN(int socialInsuranceNumber)
        {

            return new AllEmployees.Employee();
        }

        /**
        * \brief The selectEmployeeByDOB method is used to select an employee from a list. The 
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
        public AllEmployees.Employee selectEmployeeByDOB(DateTime dateOfBirth)
        {

            return new AllEmployees.Employee();
        }
    }
}

