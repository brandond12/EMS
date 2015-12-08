/*
* FILE   : OtherTests.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Lauren Machan
* FIRST VERSION : 2015-11-29
* DESCRIPTION : 
* This file contains the OtherTests class, which is used to test 
* miscellaneous methods in the Container class.
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;
using System.IO;
using TheCompany;
using System.Collections.Generic;

namespace TheCompany.Tests
{
    [TestClass]
    public class OtherTests
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
            DateTime dateOfTermination = new DateTime(2011, 03, 19);
            FTEmployee = new FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        }

        // ---------------------------------
        //      AddEmployeeToList Tests
        // ---------------------------------

        /**
        * \brief The unit test's purpose is to test if the method AddEmployeeToList 
        * actually adds an employee to the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployeeToList.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2011, 03, 19);
        * FTEmployee = new FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 1.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 1.
        */
        [TestMethod]
        public void AddEmployeeToList_ValidEmployee_AddsEmployeeToList()
        {
            // Instantiate a private object 
            var privateObject = new PrivateObject(employeeRepo);
            // Execute the method that is being tested
            privateObject.Invoke("AddEmployeeToList", FTEmployee);
            // Check if the expected result and actual result are the same
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
            Assert.AreEqual(1, employeeList.Count);
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployeeToList 
        * will not add an invalid employee to the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployeeToList.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * Employee employee = new Employee("Janet", "Moore", 872046045, dateOfBirth, "");
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 0.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 0.
        */
        [TestMethod]
        public void AddEmployeeToList_InvalidEmployee_EmployeeNotAddedToList()
        {
            // Instantiate an Employee object and a private object
            DateTime dateOfBirth = new DateTime(1987, 11, 29);
            Employee employee = new Employee("Janet", "Moore", 872046045, dateOfBirth, "");
            var privateObject = new PrivateObject(employeeRepo);

            // Execute the method that is being tested
            privateObject.Invoke("AddEmployeeToList", employee);
            // Check if the expected result and actual result are the same
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
            Assert.AreEqual(0, employeeList.Count);
        }

        // ------------------------------
        //      RemoveEmployee Tests
        // ------------------------------

        /**
        * \brief The unit test's purpose is to test if the method RemoveEmployee
        * will remove an employee from the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is RemoveEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2011, 03, 19);
        * FTEmployee = new FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 0.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 0.
        */
        [TestMethod]
        public void RemoveEmployee_ValidEmployeeInList_RemovesEmployee()
        {
            // Instantiate a private object 
            var privateObject = new PrivateObject(employeeRepo);
            // Add an employee to the list before attempting to remove it
            employeeRepo.AddEmployeeToList(FTEmployee);

            // Execute the method that is being tested
            privateObject.Invoke("RemoveEmployee", FTEmployee);
            // Check if the expected result and actual result are the same
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
            Assert.AreEqual(0, employeeList.Count);
        }

        /**
        * \brief The unit test's purpose is to test if the method RemoveEmployee
        * will not remove an invalid employee from the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is RemoveEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2011, 03, 19);
        * FTEmployee = new FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * And a part-time employee reference:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2013, 04, 12);
        * DateTime dateOfTermination = new DateTime(2015, 01, 25);
        * ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 1.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 1.
        */
        [TestMethod]
        public void RemoveEmployee_InvalidEmployeeNotInList_EmployeeIsNotRemoved()
        {
            // Instantiate a ParttimeEmployee object and a private object
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(2015, 01, 25);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
            var privateObject = new PrivateObject(employeeRepo);
            // Add an employee to the list before attempting to remove one
            employeeRepo.AddEmployeeToList(FTEmployee);

            // Execute the method that is being tested
            privateObject.Invoke("RemoveEmployee", PTEmployee);
            // Check if the expected result and actual result are the same
            List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
            Assert.AreEqual(1, employeeList.Count);
        }

        // -----------------------------------
        //      DisplayAllEmployees Tests
        // -----------------------------------

        /**
        * \brief The unit test's purpose is to test if the method DisplayAllEmployees
        * displays the employee details of all employees in the list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayAllEmployees.
        * 
        * \<b>How test is Conducted/b>
        * The test is run automatically, but the user has to view the output of the test 
        * to make sure that all of the employees were displayed with the correct data.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A part-time employee reference:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2013, 04, 12);
        * DateTime dateOfTermination = new DateTime(2014, 05, 13);
        * ParttimeEmployee PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        *    
        * \<b>Expected Result</b>
        * The expected result is that all of the employees will be be displayed to the user 
        * with the correct details.
        * 
        * \<b>Actual Result</b>
        * The actual result is that all of the employees are displayed to the user 
        * with the correct details.
        */
        [TestMethod]
        public void DisplayAllEmployees_ValidEmployeesInList_DisplaysAllEmployees()
        {
            // Add the full-time employee to the container
            employeeRepo.AddEmployeeToList(FTEmployee);

            // Instantiate a part-time employee and add it to the container
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(2014, 05, 13);
            ParttimeEmployee PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
            employeeRepo.AddEmployeeToList(PTEmployee);

            // Instantiate a contract employee and add it to the container
            dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
            employeeRepo.AddEmployeeToList(CTEmployee);

            // Instantiate a seasonal employee and add it to the container
            dateOfBirth = new DateTime(1991, 03, 18);
            SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
            employeeRepo.AddEmployeeToList(SNEmployee);

            // Initialize a string with input data and initalize other variables
            var privateObject = new PrivateObject(employeeRepo);
            String dataToPassIn = "\n\n\n\n";
            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("DisplayAllEmployees");
                /* There is no assert, since the user has to view the 
                * output to make sure the method is operating properly */
            }
        }

        // -------------------------------
        //      GetEmployeeList Tests
        // -------------------------------

        /**
        * \brief The unit test's purpose is to test if the method 
        * GetEmployeeList returns the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetEmployeeList.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2011, 03, 19);
        * FTEmployee = new FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2013, 04, 12);
        * DateTime dateOfTermination = new DateTime(2014, 05, 13);
        * ParttimeEmployee PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 2.
        * 
        * \<b>Actual Result</b>
        * The expected result is that the employeeList.Count will return 2.
        */
        [TestMethod]
        public void GetEmployeeList_ValidEmployeesInList_ReturnsAnEmployeeList()
        {
            // Add the full-time employee to the container
            employeeRepo.AddEmployeeToList(FTEmployee);

            // Instantiate a part-time employee and add it to the container
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(2014, 05, 13);
            ParttimeEmployee PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
            employeeRepo.AddEmployeeToList(PTEmployee);

            var privateObject = new PrivateObject(employeeRepo);
            // Execute the method that is being tested
            List<Employee> employeeList = (List<Employee>)privateObject.Invoke("GetEmployeeList");
            // Check if the expected result and actual result are the same
            Assert.AreEqual(2, employeeList.Count);
        }
    }
}
