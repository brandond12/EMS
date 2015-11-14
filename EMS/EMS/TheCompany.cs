using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    class TheCompany
    {
        List<AllEmployees.Employee> Employees;
        //starting point for code
        static void Main(string[] args)
        {
            //loop until user closes program
               //call first menu option
               //exception thrown then user whats to leave
        }

        public void addEmployee()
        {
            //use GetInfoFromUser from UI
            //build a Employee
            //save employee
        }

        public void removeEmployee(AllEmployees.Employee employee)
        {
            //delete the given employee
        }

        public void modifyEmployee(AllEmployees.Employee employee)
        {
            //given employee
            //show each data member 
        }

        public AllEmployees.Employee selectEmployee()
        {
            //search all employees
            return new AllEmployees.Employee();
        }

        public AllEmployees.Employee selectEmployeeByFirstName(string firstName)
        {

            return new AllEmployees.Employee();
        }

        public AllEmployees.Employee selectEmployeeByFullName(string firstName, string lastName)
        {

            return new AllEmployees.Employee();
        }

        public AllEmployees.Employee selectEmployeeBySIN(int socialInsuranceNumber)
        {

            return new AllEmployees.Employee();
        }

        public AllEmployees.Employee selectEmployeeByDOB(DateTime dateOfBirth)
        {

            return new AllEmployees.Employee();
        }
    }
}

