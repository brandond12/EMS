/*
* FILE   : SelectEmployeeTests.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Lauren Machan
* FIRST VERSION : 2015-11-29
* DESCRIPTION : 
* This file contains the SelectEmployeeTests class, which is used to test methods
* in the Container class that revolve around selecting existing employee objects.
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;
using System.IO;
using TheCompany;

namespace TheCompany.Tests
{
    [TestClass]
    public class SelectEmployeeTests
    {
        private Container employeeRepo;         // A reference to a Container object
        private FulltimeEmployee FTEmployee;    // A reference to a FulltimeEmployee object
        private FulltimeEmployee FTEmployee2;   // A reference to a FulltimeEmployee object
        private ParttimeEmployee PTEmployee;    // A reference to a ParttimeEmployee object

        [TestInitialize]
        public void TestInitialize()
        {
            // Instantiate the container and a full-time employee
            employeeRepo = new Container();
            DateTime dateOfBirth = new DateTime(1990, 09, 10);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(2013, 03, 04);
            FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);

            // Instantiate a part-time employee
            dateOfBirth = new DateTime(1987, 06, 22);
            dateOfHire = new DateTime(2010, 10, 11);
            dateOfTermination = new DateTime(2014, 05, 13);
            PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);

            // Instantiate a full-time employee
            dateOfBirth = new DateTime(1990, 09, 10);
            dateOfHire = new DateTime(2011, 02, 18);
            dateOfTermination = new DateTime(2013, 03, 04);
            FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);

            // Instantiate a contract employee
            dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
            
            // Add the employees to a list
            employeeRepo.AddEmployeeToList(FTEmployee);
            employeeRepo.AddEmployeeToList(PTEmployee);
            employeeRepo.AddEmployeeToList(FTEmployee2);
            employeeRepo.AddEmployeeToList(CTEmployee);
        }

        // -----------------------------
        //      SelectEmployee Test
        // -----------------------------

        [TestMethod]
        public void SelectEmployee_GivenFirstName_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetFirstName("Sam");

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenLastName_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            var privateObject = new PrivateObject(employeeRepo);
            Employee actualEmployee = new Employee();

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetLastName("Jones");

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Mark", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenSIN_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetSocialInsuranceNumber(902398402);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Mark", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenDOB_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetDateOfBirth(1990, 09, 10);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenType_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetEmployeeType("FT");

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenDOH_SelectsValidFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetDateOfHire(2010, 10, 11);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenDOT_SelectsValidFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetDateOfTermination(2013, 03, 04);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenSalary_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetSalary(50000);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenDOH_SelectsValidParttimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Instantiate a part-time employee
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(2014, 05, 13);
            AllEmployees.ParttimeEmployee PTEmployee2 = new AllEmployees.ParttimeEmployee("Karen", "Walters", 908098731, dateOfBirth, dateOfHire, dateOfTermination, 30);
            employeeRepo.AddEmployeeToList(PTEmployee2);

            ParttimeEmployee givenEmployee = new ParttimeEmployee();
            givenEmployee.SetDateOfHire(2010, 10, 11);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Karen", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenDOT_SelectsValidParttimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Instantiate a part-time employee
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(2014, 05, 13);
            AllEmployees.ParttimeEmployee PTEmployee2 = new AllEmployees.ParttimeEmployee("Karen", "Walters", 908098731, dateOfBirth, dateOfHire, dateOfTermination, 30);
            employeeRepo.AddEmployeeToList(PTEmployee2);

            ParttimeEmployee givenEmployee = new ParttimeEmployee();
            givenEmployee.SetDateOfTermination(2014, 05, 13);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Karen", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenHourlyRate_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            ParttimeEmployee givenEmployee = new ParttimeEmployee();
            givenEmployee.SetHourlyRate(30);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Mark", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenContractStartDate_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Instantiate a contract employee
            DateTime dateOfBirth = new DateTime(1989, 10, 08);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee2 = new AllEmployees.ContractEmployee("Jack", "Phillips", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
            employeeRepo.AddEmployeeToList(CTEmployee2);

            ContractEmployee givenEmployee = new ContractEmployee();
            givenEmployee.SetContractStartDate(2014, 02, 08);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Jack", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void SelectEmployee_GivenContractStopDate_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Instantiate a contract employee
            DateTime dateOfBirth = new DateTime(1989, 10, 08);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee2 = new AllEmployees.ContractEmployee("Jack", "Phillips", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
            employeeRepo.AddEmployeeToList(CTEmployee2);

            ContractEmployee givenEmployee = new ContractEmployee();
            givenEmployee.SetContractStopDate(2014, 09, 12);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Jack", actualEmployee.GetFirstName());
            }
        }




        // ----------------------------------------
        //      IsThisTheDesiredEmployee Tests
        // ----------------------------------------
        

        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithYes_ReturnsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithNo_ReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ---------------------------------------
        //      DisplayEmployeeDetails Tests
        // ---------------------------------------
        // have to have special instructions here stating that the unit tests can't test that the details being displayed
        // to the user are correct, so they have to look at the test output
        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidFulltimeEmployeeWithYes_ReturnsYes()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", FTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidFulltimeEmployeeWithNo_ReturnsNo()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", FTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("N", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidParttimeEmployeeWithYes_ReturnsYes()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(2015, 06, 17);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
          
            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", PTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidParttimeEmployeeWithNo_ReturnsNo()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(2015, 06, 17);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", PTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("N", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidContractEmployeeWithYes_ReturnsYes()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            DateTime dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee = new ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", CTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidContractEmployeeWithNo_ReturnsNo()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            DateTime dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee = new ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", CTEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("N", actualString);
            }
        }


        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidSeasonalEmployeeWithYes_ReturnsYes()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            DateTime dateOfBirth = new DateTime(1991, 03, 18);
            SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", SNEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidSeasonalEmployeeWithNo_ReturnsNo()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            DateTime dateOfBirth = new DateTime(1991, 03, 18);
            SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", SNEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("N", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidEmployee_ReturnsBlankString()
        {
            // Instantiate a private object and an Employee object
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            DateTime dateOfBirth = new DateTime(1987, 11, 29);
            Employee employee = new Employee("Janet", "Moore", 872046045, dateOfBirth, "");

            // Execute the method that is being tested
            actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", employee);
            // Check if the expected result and actual result are the same
            Assert.AreEqual("", actualString);
        }

    }
}
