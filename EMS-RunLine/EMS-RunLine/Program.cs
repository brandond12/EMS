using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation;
using AllEmployees;

namespace EMS_RunLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            ContractEmployee CTemp = new ContractEmployee();

            CTemp = (ContractEmployee)emp;
            //UIMenu EMSMenu = new UIMenu();
            //EMSMenu.ShowMainMenu();
        }
    }
}
