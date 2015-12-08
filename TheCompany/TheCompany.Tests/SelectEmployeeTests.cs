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
    /// \class  SelectEmployeeTests
    ///
    /// \brief <b>Brief Description</b> 
    /// This class is used to test the SelectEmployee methods in the Container class. The methods tested 
    /// include SelectEmployee, IsThisTheDesiredEmployee and DisplayEmployeeDetails. Some of the methods in 
    /// this class require user input for testing (they will have a string called dataToPassIn, and will use 
    /// Console.SetIn() and StringReader). To test the methods with user input, Console.SetIn() and StringReader 
    /// are used to simulate the user input. The idea/code to use the Console.SetIn() and StringReader for user 
    /// input was borrowed from Assaf Stone's post at this link:
    /// http://www.softwareandi.com/2012/02/how-to-write-automated-tests-for.html
    [TestClass]
    public class SelectEmployeeTests
    {
        private Container employeeRepo;         // A reference to a Container object
        private FulltimeEmployee FTEmployee;    // A reference to a FulltimeEmployee object
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
            dateOfBirth = new DateTime(1990, 09, 10);
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

            // Instantiate a seasonal employee
            dateOfBirth = new DateTime(1991, 03, 18);
            SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);

            // Add the employees to a list
            employeeRepo.AddEmployeeToList(FTEmployee);
            employeeRepo.AddEmployeeToList(PTEmployee);
            employeeRepo.AddEmployeeToList(FTEmployee2);
            employeeRepo.AddEmployeeToList(CTEmployee);
            employeeRepo.AddEmployeeToList(SNEmployee);
        }

        // -----------------------------
        //      SelectEmployee Test
        // -----------------------------

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given first name.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetFirstName("Sam");
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void SelectEmployee_GivenFirstName_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given last name.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetLastName("Jones");
        * Input string:
        * "N\nY\n"    
        * 
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Mark.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Mark.
        */
        [TestMethod]
        public void SelectEmployee_GivenLastName_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            var privateObject = new PrivateObject(employeeRepo);
            Employee actualEmployee = new Employee();
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given SIN.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetSocialInsuranceNumber(902398402);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Mark.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Mark.
        */
        [TestMethod]
        public void SelectEmployee_GivenSIN_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given DOB.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetDateOfBirth(1990, 09, 10);
        * Input string:
        * "N\nN\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void SelectEmployee_GivenDOB_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nN\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given type.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetEmployeeType("FT");
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void SelectEmployee_GivenType_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select a full-time employee based on the given DOH.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetDateOfHire(2010, 10, 11);
        * Input string:
        * "Y\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void SelectEmployee_GivenDOH_SelectsValidFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select a full-time employee based on the given DOT.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetDateOfTermination(2013, 03, 04);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void SelectEmployee_GivenDOT_SelectsValidFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given salary.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetSalary(50000);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void SelectEmployee_GivenSalary_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select a part-time employee based on the given DOH.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2014, 05, 13);
        * AllEmployees.ParttimeEmployee PTEmployee2 = new AllEmployees.ParttimeEmployee("Karen", "Walters", 908098731, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Comparing against:
        * ParttimeEmployee givenEmployee = new ParttimeEmployee();
        * givenEmployee.SetDateOfHire(2010, 10, 11);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Karen.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Karen.
        */
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

            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select a part-time employee based on the given DOT.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2014, 05, 13);
        * AllEmployees.ParttimeEmployee PTEmployee2 = new AllEmployees.ParttimeEmployee("Karen", "Walters", 908098731, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Comparing against:
        * ParttimeEmployee givenEmployee = new ParttimeEmployee();
        * givenEmployee.SetDateOfTermination(2014, 05, 13);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Karen.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Karen.
        */
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

            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given hourly rate.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2014, 05, 13);
        * AllEmployees.ParttimeEmployee PTEmployee2 = new AllEmployees.ParttimeEmployee("Karen", "Walters", 908098731, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Comparing against:
        * ParttimeEmployee givenEmployee = new ParttimeEmployee();
        * givenEmployee.SetHourlyRate(30);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Karen.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Karen.
        */
        [TestMethod]
        public void SelectEmployee_GivenHourlyRate_SelectsValidEmployee()
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

            // Set the employee parameters
            ParttimeEmployee givenEmployee = new ParttimeEmployee();
            givenEmployee.SetHourlyRate(30);

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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given contract start date.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1989, 10, 08);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee2 = new AllEmployees.ContractEmployee("Jack", "Phillips", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Comparing against:
        * ContractEmployee givenEmployee = new ContractEmployee();
        * givenEmployee.SetContractStartDate(2014, 02, 08);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Jack.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Jack.
        */
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

            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given contract stop date.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1989, 10, 08);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee2 = new AllEmployees.ContractEmployee("Jack", "Phillips", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Comparing against:
        * ContractEmployee givenEmployee = new ContractEmployee();
        * givenEmployee.SetContractStopDate(2014, 09, 12);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Jack.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Jack.
        */
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

            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given contract amount.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1989, 10, 08);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee2 = new AllEmployees.ContractEmployee("Jack", "Phillips", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * employeeRepo.AddEmployeeToList(CTEmployee2);
        * Comparing against:
        * ContractEmployee givenEmployee = new ContractEmployee();
        * givenEmployee.SetContractStopDate(2014, 09, 12);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Jack.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Jack.
        */
        [TestMethod]
        public void SelectEmployee_GivenContractAmount_SelectsValidEmployee()
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

            // Set the employee parameters
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given season.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1980, 10, 24);
        * SeasonalEmployee SNEmployee2 = new AllEmployees.SeasonalEmployee("Oliver", "Jackson", 809854331, dateOfBirth, "Summer", 15);
        * Comparing against:
        * SeasonalEmployee givenEmployee = new SeasonalEmployee();
        * givenEmployee.SetSeason("Summer");
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Oliver.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Oliver.
        */
        [TestMethod]
        public void SelectEmployee_GivenSeason_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Instantiate a seasonal employee
            DateTime dateOfBirth = new DateTime(1980, 10, 24);
            SeasonalEmployee SNEmployee2 = new AllEmployees.SeasonalEmployee("Oliver", "Jackson", 809854331, dateOfBirth, "Summer", 15);
            employeeRepo.AddEmployeeToList(SNEmployee2);

            // Set the employee parameters
            SeasonalEmployee givenEmployee = new SeasonalEmployee();
            givenEmployee.SetSeason("Summer");

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Oliver", actualEmployee.GetFirstName());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given piece pay.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1980, 10, 24);
        * SeasonalEmployee SNEmployee2 = new AllEmployees.SeasonalEmployee("Oliver", "Jackson", 809854331, dateOfBirth, "Winter", 20);
        * Comparing against:
        * SeasonalEmployee givenEmployee = new SeasonalEmployee();
        * givenEmployee.SetPiecePay(20);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Oliver.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Oliver.
        */
        [TestMethod]
        public void SelectEmployee_GivenPiecePay_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Instantiate a seasonal employee
            DateTime dateOfBirth = new DateTime(1980, 10, 24);
            SeasonalEmployee SNEmployee2 = new AllEmployees.SeasonalEmployee("Oliver", "Jackson", 809854331, dateOfBirth, "Winter", 20);
            employeeRepo.AddEmployeeToList(SNEmployee2);

            // Set the employee parameters
            SeasonalEmployee givenEmployee = new SeasonalEmployee();
            givenEmployee.SetPiecePay(20);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Oliver", actualEmployee.GetFirstName());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given last name and SIN.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Comparing against:
        * FulltimeEmployee givenEmployee = new FulltimeEmployee();
        * givenEmployee.SetLastName("Jones");
        * givenEmployee.SetSocialInsuranceNumber(902398402);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Mark.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Mark.
        */
        [TestMethod]
        public void SelectEmployee_GivenLastNameAndSIN_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            // Set the employee parameters
            FulltimeEmployee givenEmployee = new FulltimeEmployee();
            givenEmployee.SetLastName("Jones");
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

        /**
        * \brief The unit test's purpose is to test if the method SelectEmployee
        * will select an employee based on the given contract start date, contract 
        * stop date, and contract amount.
        * 
        * \<b>Name of Method/b>
        * The method being tested is SelectEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A bunch of employees in the container:
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A part-time employee reference:
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2010, 10, 11);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * A full-time employee reference
        * dateOfBirth = new DateTime(1990, 09, 10);
        * dateOfHire = new DateTime(2011, 02, 18);
        * dateOfTermination = new DateTime(2013, 03, 04);
        * FulltimeEmployee FTEmployee2 = new AllEmployees.FulltimeEmployee("Sam", "Appleton", 904509401, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * A contract employee reference:
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * A seasonal employee reference:
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * An employee created in the method:
        * DateTime dateOfBirth = new DateTime(1989, 10, 08);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee2 = new AllEmployees.ContractEmployee("Jimmy", "Phillips", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Comparing against:
        * ContractEmployee givenEmployee = new ContractEmployee();
        * givenEmployee.SetContractStartDate(2014, 02, 08);
        * givenEmployee.SetContractStopDate(2014, 09, 12);
        * givenEmployee.SetFixedContractAmount(25000);
        * Input string:
        * "N\nY\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Jimmy.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Jimmy.
        */
        [TestMethod]
        public void SelectEmployee_GivenContractStartAndStopDatesAndContractAmount_SelectsValidEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\nY\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);

            // Instantiate a contract employee
            DateTime dateOfBirth = new DateTime(1989, 10, 08);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee2 = new AllEmployees.ContractEmployee("Jimmy", "Phillips", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
            employeeRepo.AddEmployeeToList(CTEmployee2);

            // Set the employee parameters
            ContractEmployee givenEmployee = new ContractEmployee();
            givenEmployee.SetContractStartDate(2014, 02, 08);
            givenEmployee.SetContractStopDate(2014, 09, 12);
            givenEmployee.SetFixedContractAmount(25000);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee", givenEmployee);
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Jimmy", actualEmployee.GetFirstName());
            }
        }

        // ----------------------------------------
        //      IsThisTheDesiredEmployee Tests
        // ----------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method IsThisTheDesiredEmployee
        * will return a valid employee when the user returns yes.
        * 
        * \<b>Name of Method/b>
        * The method being tested is IsThisTheDesiredEmployee.
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
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n"   
        * 
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method IsThisTheDesiredEmployee
        * will return a blank employee when the user returns no.
        * 
        * \<b>Name of Method/b>
        * The method being tested is IsThisTheDesiredEmployee.
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
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n" 
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name will be blank.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name will be blank.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method IsThisTheDesiredEmployee
        * will return a valid employee when the user selects an invalid choice then yes.
        * 
        * \<b>Name of Method/b>
        * The method being tested is IsThisTheDesiredEmployee.
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
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method IsThisTheDesiredEmployee
        * will return a blank employee when the user selects an invalid choice then yes.
        * 
        * \<b>Name of Method/b>
        * The method being tested is IsThisTheDesiredEmployee.
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
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN" 
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employee's name will be blank.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employee's name will be blank.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return yes if the user selects yes and a full-time employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is IsThisTheDesiredEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be Y.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be Y.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return no if the user selects no and a full-time employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A full-time employee reference:
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2013, 03, 04);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be N.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be N.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return yes if the user selects yes and a part-time employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A part-time employee reference:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2013, 04, 12);
        * DateTime dateOfTermination = new DateTime(2015, 06, 17);
        * ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be Y.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be Y.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return no if the user selects no and a part-time employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A part-time employee reference:
        * DateTime dateOfBirth = new DateTime(1987, 06, 22);
        * DateTime dateOfHire = new DateTime(2013, 04, 12);
        * DateTime dateOfTermination = new DateTime(2015, 06, 17);
        * ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "N\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be N.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be N.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return no if the user selects no and a contract employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A contract employee reference:
        * DateTime dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be Y.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be Y.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return no if the user selects no and a contract employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A contract employee reference:
        * DateTime dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * ContractEmployee CTEmployee = new ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "N\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be N.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be N.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return yes if the user selects yes and a seasonal employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A seasonal employee reference:
        * DateTime dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\n"
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be Y.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be Y.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return no if the user selects no and a seasonal employee wil be displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * A seasonal employee reference:
        * DateTime dateOfBirth = new DateTime(1991, 03, 18);
        * SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "N\n"   
        * 
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be N.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be N.
        */
        [TestMethod]
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

        /**
        * \brief The unit test's purpose is to test if the method DisplayEmployeeDetails
        * will return a blank if the user selects a blank and a no employee will be 
        * displayed.
        * 
        * \<b>Name of Method/b>
        * The method being tested is DisplayEmployeeDetails.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted. However, the user has to check the output 
        * of the unit test to ensure the details of the employees being displayed are correct.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * An employee reference:
        * DateTime dateOfBirth = new DateTime(1991, 03, 18);
        * Employee employee = new Employee("Janet", "Moore", 872046045, dateOfBirth, "");
        * Input string:
        * ""
        *    
        * \<b>Expected Result</b>
        * The expected result is that the user's response will be a blank.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the user's response will be a blank.
        */
        [TestMethod]
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
