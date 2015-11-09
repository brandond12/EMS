using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    class TheCompany
    {
        //starting point for code
        static void Main(string[] args)
        {
            //loop until user closes program
               //call first menu option
               //exception thrown then user whats to leave
        }

        public void addEmployee(AllEmployees.Employee employee)
        {
            //use GetInfoFromUser from UI
            //build a Employee
            //save employee
        }

        public void removeEmployee(AllEmployees.Employee employee)
        {
            //show user Employees individualy
            //if user wants to delete, delete it
        }

        public void modifyEmployee(AllEmployees.Employee employee)
        {
            //show user Employees individualy
            //if user wants to modify
            //show each data member
        }

        //start travers through employees / reset travers
        public static AllEmployees.Employee showFirstEmployee()
        {
            return new AllEmployees.Employee();//temp to remove errors
        }

        //keep traversing through employees
        public static AllEmployees.Employee showNextEmployee()
        {
            return new AllEmployees.Employee();//temp to remove errors
        }
    }
}
