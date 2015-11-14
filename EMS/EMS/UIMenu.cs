using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    static class UIMenu
    {
        TheCompany company = new TheCompany();
        public static void ShowMainMenu()
        {

        }

        public static void ShowFIleManagmentMenu()
        {

        }

        public static void ShowEmployeeManagmentMenu()
        {

        }

        public static void ShowEmployeeDetailsMenu()
        {

        }

        public static AllEmployees.Employee ShowFindEmployeeMenu()
        {
            //select a method of finding an employee
            return new AllEmployees.Employee();
        }

        public static String GetInfoFromUser(String UserPrompt)
        {

            return " "; //temp to remove errors
        }

        public static void ShowError(String errorMessage)
        {

        }
    }
}
