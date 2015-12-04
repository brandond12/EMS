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

        [TestInitialize]
        public void TestInitialize()
        {
            // Instantiate the container and a full-time employee
            employeeRepo = new Container();
            DateTime dateOfBirth = new DateTime(1990, 09, 10);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 212398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
            // Add the employee to a list
            employeeRepo.AddEmployeeToList(FTEmployee);
        }

        // ======================================= SelectEmployee Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndYes_SelectsValidEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndNo_ReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughBlankList_ReturnsBlankEmployee()
        {
            // Instantiate a blank container, blank employee, and a private object
            Container testRepo = new Container();
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(testRepo);

            // Execute the method that is being tested
            actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
            // Check if the expected result and actual result are the same
            Assert.AreEqual("", actualEmployee.GetFirstName());
        }


        // ======================================= SelectEmployeeByFirstName Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithYes_SelectsValidEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithNo_ReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeByFirstName_FirstNameNotFound_ReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Michelle");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= SelectEmployeeByFullName Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithYes_SelectsValidEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithNo_ReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeByFullName_FullNameNotFound_ReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Williams");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= SelectEmployeeBySIN Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithYes_SelectsValidEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithNo_ReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
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
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeBySIN_SINNotFound_ReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 173498562);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= SelectEmployeeByDOB Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithYes_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n"; 
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithNo_ReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }


        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY";
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeByDOB_DOBNotFound_ReturnsBlankEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "";
            DateTime dateToSearch = new DateTime(1991, 08, 24);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= IsThisTheDesiredEmployee Tests =======================================
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

        // ======================================= DisplayEmployeeDetails Tests =======================================
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
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 432098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
          
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
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 432098933, dateOfBirth, dateOfHire, dateOfTermination, 30);

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
            SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 432098933, dateOfBirth, "Summer", 20);

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
            SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 432098933, dateOfBirth, "Summer", 20);

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
            Employee employee = new Employee("Janet", "Moore", 122046045, dateOfBirth, "");

            // Execute the method that is being tested
            actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", employee);
            // Check if the expected result and actual result are the same
            Assert.AreEqual("", actualString);
        }

    }
}
