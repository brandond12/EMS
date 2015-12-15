/*
* FILE   : ModifyEmployeeTests.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Lauren Machan
* FIRST VERSION : 2015-11-29
* DESCRIPTION : 
* This file contains the ModifyEmployeeTests class, which is used to test methods
* in the Container class that revolve around modifying properties of existing employee objects.
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;
using System.IO;
using TheCompany;
using System.Collections.Generic;

namespace TheCompany.Tests
{
    /// \class  ModifyEmployeeTests
    ///
    /// \brief  <b> Brief Description</b> 
    /// This class is used to test the ModifyEmployee methods in the Container class. The methods tested 
    /// include ModifyFirstName, ModifyLastName, ModifySocialInsuranceNumber, ModifyDateOfBirth, ModifyDateOfHire, 
    /// ModifyEmployeeType, ModifyDateOfTermination, ModifySalary, ModifyHourlyRate, ModifyContractStartDate, 
    /// ModifyContractStopDate, ModifyFixedContractAmount, ModifySeason, ModifyPiecePay and ModifyEmployee.
    /// Some of the methods in this class require user input for testing (they will have a string called dataToPassIn, 
    /// and will use Console.SetIn() and StringReader). To test the methods with user input, Console.SetIn() and 
    /// StringReader are used to simulate the user input. The idea/code to use the Console.SetIn() and StringReader 
    /// for user input was borrowed from Assaf Stone's post at this link:
    /// http://www.softwareandi.com/2012/02/how-to-write-automated-tests-for.html
    [TestClass]
    public class ModifyEmployeeTests
    {
        private Container employeeRepo;             // A reference to a Container object
        private FulltimeEmployee FTEmployee;        // A reference to a FulltimeEmployee object
        private ParttimeEmployee PTEmployee;        // A reference to a ParttimeEmployee object
        private ContractEmployee CTEmployee;        // A reference to a ContractEmployee object
        private SeasonalEmployee SNEmployee;        // A reference to a SeasonalEmployee object

        [TestInitialize]
        public void TestInitialize()
        {
            // Instantiate the container
            employeeRepo = new Container();

            // Instantiate a full-time employee
            DateTime dateOfBirth = new DateTime(1990, 09, 10);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(2012, 02, 19);
            FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);

            // Instantiate a part-time employee
            dateOfBirth = new DateTime(1987, 06, 22);
            dateOfHire = new DateTime(2013, 04, 12);
            dateOfTermination = new DateTime(2014, 05, 13);
            PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);

            // Instantiate a contract employee
            dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);

            // Instantiate a seasonal employee
            dateOfBirth = new DateTime(1991, 03, 18);
            SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        }

        // -------------------------------
        //      ModifyFirstName Tests
        // -------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyFirstName
        * will modify the first name of an employee if the given first name is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFirstName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Samantha.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Samantha.
        */
        [TestMethod]
        public void ModifyFirstName_YesWithValidFirstName_UpdatesFirstName()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Samantha", actualFirstName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFirstName
        * will not modify the first name of an employee if the given first name is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFirstName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void ModifyFirstName_YesWithBlankFirstName_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFirstName
        * will not modify the first name of an employee if the given first name is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFirstName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n12345"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void ModifyFirstName_YesWithInvalidFirstName_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n12345";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFirstName
        * will not modify the first name of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFirstName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void ModifyFirstName_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFirstName
        * will not modify the first name of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFirstName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Sam.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Sam.
        */
        [TestMethod]
        public void ModifyFirstName_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFirstName
        * will modify the first name of an employee if an invalid choice is 
        * made and then the user says yes with a valid name.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFirstName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\nSamantha"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Samantha.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Samantha.
        */
        [TestMethod]
        public void ModifyFirstName_InvalidChoiceThenYesWithValidFirstName_LoopsBackAndUpdatesFirstName()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\nSamantha";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Samantha", actualFirstName);
            }
        }

        // -------------------------------
        //      ModifyLastName Tests
        // -------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyLastName
        * will modify the last name of an employee if the given last name is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyLastName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nAnderson"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Anderson.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Anderson.
        */
        [TestMethod]
        public void ModifyLastName_YesWithValidLastName_UpdatesLastName()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nAnderson";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyLastName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Anderson", actualLastName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyLastName
        * will not modify the last name of an employee if the given last name is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyLastName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Jones.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Jones.
        */
        [TestMethod]
        public void ModifyLastName_YesWithBlankLastName_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyLastName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyLastName
        * will not modify the last name of an employee if the given last name is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyLastName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n12345"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Jones.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Jones.
        */
        [TestMethod]
        public void ModifyLastName_YesWithInvalidLastName_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n12345";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyLastName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyLastName
        * will not modify the last name of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFirstName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's name is Jones.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's name is Jones.
        */
        [TestMethod]
        public void ModifyLastName_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyLastName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyLastName
        * will not modify the last name of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyLastName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's last name is Jones.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's last name is Jones.
        */
        [TestMethod]
        public void ModifyLastName_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyLastName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyLastName
        * will modify the last name of an employee if an invalid choice is 
        * made and then the user says yes with a valid name.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyLastName.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\nAnderson"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's last name is Anderson.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's last name is Anderson.
        */
        [TestMethod]
        public void ModifyLastName_InvalidChoiceThenYesWithValidLastName_LoopsBackAndUpdatesLastName()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\nAnderson";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyLastName", FTEmployee);
                // Check if the expected result and actual result are the same
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Anderson", actualLastName);
            }
        }

        // -------------------------------------------
        //      ModifySocialInsuranceNumber Tests
        // -------------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifySocialInsuranceNumber
        * will modify the SIN of an employee if the given SIN is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySocialInsuranceNumber.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n902398433"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's SIN is 902398433.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's SIN is 902398433.
        */
        [TestMethod]
        public void ModifySocialInsuranceNumber_YesWithValidSIN_UpdatesSIN()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n902398433";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(902398433, actualSIN);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySocialInsuranceNumber
        * will not modify the SIN of an employee if the given SIN is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySocialInsuranceNumber.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's SIN is 902398402.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's SIN is 902398402.
        */
        [TestMethod]
        public void ModifySocialInsuranceNumber_YesWithBlankSIN_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(902398402, actualSIN);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySocialInsuranceNumber
        * will not modify the SIN of an employee if the given SIN is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySocialInsuranceNumber.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n90H098GO1"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's SIN is 902398402.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's SIN is 902398402.
        */
        [TestMethod]
        public void ModifySocialInsuranceNumber_YesWithInvalidSIN_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n90H098GO1";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(902398402, actualSIN);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySocialInsuranceNumber
        * will not modify the SIN of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySocialInsuranceNumber.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's SIN is 902398402.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's SIN is 902398402.
        */
        [TestMethod]
        public void ModifySocialInsuranceNumber_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(902398402, actualSIN);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySocialInsuranceNumber
        * will not modify the SIN of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySocialInsuranceNumber.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's SIN is 902398402.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's SIN is 902398402.
        */
        [TestMethod]
        public void ModifySocialInsuranceNumber_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(902398402, actualSIN);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySocialInsuranceNumber
        * will modify the SIN of an employee if an invalid choice is 
        * made and then the user says yes with a valid SIN.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySocialInsuranceNumber.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\n902398461"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's SIN is 902398461.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's SIN is 902398461.
        */
        [TestMethod]
        public void ModifySocialInsuranceNumber_InvalidChoiceThenYesWithValidSIN_LoopsBackAndUpdatesSIN()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n902398461";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(902398461, actualSIN);
            }
        }

        // ---------------------------------
        //      ModifyDateOfBirth Tests
        // ---------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfBirth
        * will modify the DOB of an employee if the given DOB is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfBirth.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n1991\n09\n21"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOB is 1991-09-21.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOB is 1991-09-21.
        */
        [TestMethod]
        public void ModifyDateOfBirth_YesWithValidDOB_UpdatesDOB()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n1991\n09\n21";
            DateTime expectedDOB = new DateTime(1991, 09, 21);
            DateTime actualDOB = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfBirth
        * will not modify the DOB of an employee if the given DOB is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfBirth.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOB is 1990-09-10.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOB is 1990-09-10.
        */
        [TestMethod]
        public void ModifyDateOfBirth_YesWithBlankDOB_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfBirth
        * will not modify the DOB of an employee if the given DOB is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfBirth.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n1900\n40\n67"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOB is 1990-09-10.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOB is 1990-09-10.
        */
        [TestMethod]
        public void ModifyDateOfBirth_YesWithInvalidDOB_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n1900\n40\n67";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfBirth
        * will not modify the DOB of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfBirth.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOB is 1990-09-10.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOB is 1990-09-10.
        */
        [TestMethod]
        public void ModifyDateOfBirth_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfBirth
        * will not modify the DOB of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfBirth.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOB is 1990-09-10.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOB is 1990-09-10.
        */
        [TestMethod]
        public void ModifyDateOfBirth_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfBirth
        * will modify the DOB of an employee if an invalid choice is 
        * made and then the user says yes with a valid DOB.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfBirth.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\n1992\n10\n09"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOB is 1992-10-09.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOB is 1992-10-09.
        */
        [TestMethod]
        public void ModifyDateOfBirth_InvalidChoiceThenYesWithValidDOB_LoopsBackAndUpdatesDOB()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n1992\n10\n09";
            DateTime expectedDOB = new DateTime(1992, 10, 09);
            DateTime actualDOB = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        // ----------------------------------
        //      ModifyEmployeeType Tests
        // ----------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployeeType
        * will modify the type of an employee if the given type is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployeeType.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nPT"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is PT (part-time).
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's is PT (part-time).
        */
        [TestMethod]
        public void ModifyEmployeeType_YesWithValidType_UpdatesType()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nPT";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                // Check if the expected result and actual result are the same
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("PT", actualType);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployeeType
        * will not modify the type of an employee if the given type is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployeeType.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is FT (full-time).
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is FT (full-time).
        */
        [TestMethod]
        public void ModifyEmployeeType_YesWithBlankType_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                // Check if the expected result and actual result are the same
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployeeType
        * will not modify the type of an employee if the given type is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployeeType.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nOT"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is FT (full-time).
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is FT (full-time).
        */
        [TestMethod]
        public void ModifyEmployeeType_YesWithInvalidType_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nOT";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                // Check if the expected result and actual result are the same
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployeeType
        * will not modify the type of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployeeType.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is FT (full-time).
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is FT (full-time).
        */
        [TestMethod]
        public void ModifyEmployeeType_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                // Check if the expected result and actual result are the same
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployeeType
        * will not modify the DOB of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployeeType.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is FT (full-time).
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is FT (full-time).
        */
        [TestMethod]
        public void ModifyEmployeeType_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                // Check if the expected result and actual result are the same
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployeeType
        * will modify the type of an employee if an invalid choice is 
        * made and then the user says yes with a valid type.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployeeType.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\nSN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is SN (seasonal).
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is SN (seasonal).
        */
        [TestMethod]
        public void ModifyEmployeeType_InvalidChoiceThenYesWithValidType_LoopsBackAndUpdatesType()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\nSN";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                // Check if the expected result and actual result are the same
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("SN", actualType);
            }
        }

        // ---------------------------------
        //      ModifyDateOfHire Tests
        // ---------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfHire
        * will modify the DOH of an employee if the given DOH is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfHire.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n2010\n03\n22"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2010-03-22.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2010-03-22.
        */
        [TestMethod]
        public void ModifyDateOfHire_YesWithValidDOH_UpdatesDOH()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n2010\n03\n22";
            DateTime expectedDOH = new DateTime(2010, 03, 22);
            DateTime actualDOH = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfHire
        * will not modify the DOH of an employee if the given DOH is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfHire.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2010-10-11.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2010-10-11.
        */
        [TestMethod]
        public void ModifyDateOfHire_YesWithBlankDOH_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfHire
        * will not modify the DOH of an employee if the given DOH is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfHire.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n1900\n40\n67"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2010-10-11.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2010-10-11.
        */
        [TestMethod]
        public void ModifyDateOfHire_YesWithInvalidDOH_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n1900\n40\n67";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfHire
        * will not modify the DOH of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfHire.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2010-10-11.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2010-10-11.
        */
        [TestMethod]
        public void ModifyDateOfHire_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfHire
        * will not modify the DOH of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfHire.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2010-10-11.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2010-10-11.
        */
        [TestMethod]
        public void ModifyDateOfHire_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfHire
        * will modify the DOH of an employee if an invalid choice is 
        * made and then the user says yes with a valid DOH.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfHire.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\n2011\n01\n29"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2011-01-29.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2011-01-29.
        */
        [TestMethod]
        public void ModifyDateOfHire_InvalidChoiceThenYesWithValidDOH_LoopsBackAndUpdatesDOH()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n2011\n01\n29";
            DateTime expectedDOH = new DateTime(2011, 01, 29);
            DateTime actualDOH = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        // ---------------------------------------
        //      ModifyDateOfTermination Tests
        // ---------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfTermination
        * will modify the DOT of an employee if the given DOT is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfTermination.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n2015\n11\n30"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2015-11-30.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2015-11-30.
        */
        [TestMethod]
        public void ModifyDateOfTermination_YesWithValidDOT_UpdatesDOT()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n2015\n11\n30";
            DateTime expectedDOT = new DateTime(2015, 11, 30);
            DateTime actualDOT = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfTermination
        * will not modify the DOT of an employee if the given DOT is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfTermination.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2012-02-19.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2012-02-19.
        */
        [TestMethod]
        public void ModifyDateOfTermination_YesWithBlankDOT_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            DateTime expectedDOT = new DateTime(2012, 02, 19);
            DateTime actualDOT = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfTermination
        * will not modify the DOT of an employee if the given DOT is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfTermination.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n1900\n40\n67"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2012-02-19.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2012-02-19.
        */
        [TestMethod]
        public void ModifyDateOfTermination_YesWithInvalidDOT_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n1900\n40\n67";
            DateTime expectedDOT = new DateTime(2012, 02, 19);
            DateTime actualDOT = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfTermination
        * will not modify the DOT of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfTermination.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2012-02-19.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2012-02-19.
        */
        [TestMethod]
        public void ModifyDateOfTermination_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            DateTime expectedDOT = new DateTime(2012, 02, 19);
            DateTime actualDOT = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfTermination
        * will not modify the DOT of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfTermination.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2012-02-19.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2012-02-19.
        */
        [TestMethod]
        public void ModifyDateOfTermination_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            DateTime expectedDOT = new DateTime(2012, 02, 19);
            DateTime actualDOT = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyDateOfTermination
        * will modify the DOT of an employee if an invalid choice is 
        * made and then the user says yes with a valid DOT.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyDateOfTermination.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\n2015\n05\n13"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2015-05-13.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2011-05-13.
        */
        [TestMethod]
        public void ModifyDateOfTermination_InvalidChoiceThenYesWithValidDOT_LoopsBackAndUpdatesDOT()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n2015\n05\n13";
            DateTime expectedDOT = new DateTime(2015, 05, 13);
            DateTime actualDOT = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                // Check if the expected result and actual result are the same
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        // ----------------------------
        //      ModifySalary Tests
        // ----------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifySalary
        * will modify the salary of an employee if the given salary is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySalary.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n65000"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's salary is 65000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's salary is 65000.
        */
        [TestMethod]
        public void ModifySalary_YesWithValidSalary_UpdatesSalary()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n65000";
            double actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySalary", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(65000, actualSalary);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySalary
        * will not modify the salary of an employee if the given salary is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySalary.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's salary is 50000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's salary is 50000.
        */
        [TestMethod]
        public void ModifySalary_YesWithBlankSalary_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            double actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySalary", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySalary
        * will not modify the salary of an employee if the given salary is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySalary.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\n-999999"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's salary is 50000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's salary is 50000.
        */
        [TestMethod]
        public void ModifySalary_YesWithInvalidSalary_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n-999999";
            double actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySalary", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySalary
        * will not modify the salary of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySalary.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's salary is 50000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's salary is 50000.
        */
        [TestMethod]
        public void ModifySalary_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            double actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySalary", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySalary
        * will not modify the salary of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySalary.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's salary is 50000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's salary is 50000.
        */
        [TestMethod]
        public void ModifySalary_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            double actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySalary", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySalary
        * will modify the salary of an employee if an invalid choice is 
        * made and then the user says yes with a valid salary.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySalary.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "no and yes\nY\n70000"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's salary is 70000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's salary is 70000.
        */
        [TestMethod]
        public void ModifySalary_InvalidChoiceThenYesWithValidSalary_LoopsBackAndUpdatesSalary()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n70000";
            double actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySalary", FTEmployee);
                // Check if the expected result and actual result are the same
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(70000, actualSalary);
            }
        }

        // --------------------------------
        //      ModifyHourlyRate Tests
        // --------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyHourlyRate
        * will modify the hourly rate of an employee if the given hourly rate is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyHourlyRate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\n35.50"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's hourly rate is 35.50.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's hourly rate is 35.50.
        */
        [TestMethod]
        public void ModifyHourlyRate_YesWithValidRate_UpdatesRate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n35.50";
            double actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                // Check if the expected result and actual result are the same
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(35.50, actualHourlyRate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyHourlyRate
        * will not modify the hourly rate of an employee if the given hourly rate is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyHourlyRate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's hourly rate is 30.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's hourly rate is 30.
        */
        [TestMethod]
        public void ModifyHourlyRate_YesWithBlankRate_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            double actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                // Check if the expected result and actual result are the same
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyHourlyRate
        * will not modify the hourly rate of an employee if the given hourly rate is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyHourlyRate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\n-15"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's hourly rate is 30.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's hourly rate is 30.
        */
        [TestMethod]
        public void ModifyHourlyRate_YesWithInvalidRate_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n-15";
            double actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                // Check if the expected result and actual result are the same
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyHourlyRate
        * will not modify the hourly rate of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyHourlyRate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\n-15"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's hourly rate is 30.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's hourly rate is 30.
        */
        [TestMethod]
        public void ModifyHourlyRate_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            double actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                // Check if the expected result and actual result are the same
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyHourlyRate
        * will not modify the hourly rate of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyHourlyRate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's hourly rate is 30.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's hourly rate is 30.
        */
        [TestMethod]
        public void ModifyHourlyRate_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            double actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                // Check if the expected result and actual result are the same
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyHourlyRate
        * will modify the hourly rate of an employee if an invalid choice is 
        * made and then the user says yes with a valid hourly rate.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyHourlyRate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "no and yes\nY\n25.00"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's hourly rate is 25.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's hourly rate is 25.
        */
        [TestMethod]
        public void ModifyHourlyRate_InvalidChoiceThenYesWithValidRate_LoopsBackAndUpdatesRate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n25.00";
            double actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                // Check if the expected result and actual result are the same
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(25.00, actualHourlyRate);
            }
        }

        // ---------------------------------------
        //      ModifyContractStartDate Tests
        // ---------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStartDate
        * will modify the contract start date of an employee if the given date is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStartDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n2013\n01\n16"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract start date is 2013-01-16.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract start date is 2013-01-16.
        */
        [TestMethod]
        public void ModifyContractStartDate_YesWithValidStartDate_UpdatesStartDate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n2013\n01\n16";
            DateTime expectedStartDate = new DateTime(2013, 01, 16);
            DateTime actualStartDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStartDate
        * will not modify the contract start date of an employee if the given date is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStartDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract start date is 2014-02-08.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract start date is 2014-02-08.
        */
        [TestMethod]
        public void ModifyContractStartDate_YesWithBlankStartDate_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStartDate
        * will not modify the contract start date of an employee if the given date is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStartDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n1600\n37\n88"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract start date is 2014-02-08.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract start date is 2014-02-08.
        */
        [TestMethod]
        public void ModifyContractStartDate_YesWithInvalidStartDate_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n1600\n37\n88";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStartDate
        * will not modify the contract start date of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStartDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract start date is 2014-02-08.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract start date is 2014-02-08.
        */
        [TestMethod]
        public void ModifyContractStartDate_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStartDate
        * will not modify the contract start date of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStartDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract start date is 2014-02-08.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract start date is 2014-02-08.
        */
        [TestMethod]
        public void ModifyContractStartDate_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStartDate
        * will modify the contract start date of an employee if an invalid choice is 
        * made and then the user says yes with a valid date.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStartDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "no and yes\nY\n2013\n01\n25"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract start date is 2013-01-25.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract start date is 2013-01-25.
        */
        [TestMethod]
        public void ModifyContractStartDate_InvalidChoiceThenYesWithValidDate_LoopsBackAndUpdatesDate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n2013\n01\n25";
            DateTime expectedStartDate = new DateTime(2013, 01, 25);
            DateTime actualStartDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        // --------------------------------------
        //      ModifyContractStopDate Tests
        // --------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStopDate
        * will modify the contract stop date of an employee if the given date is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStopDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n2014\n10\n27"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract stop date is 2014-10-27.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract stop date is 2014-10-27.
        */
        [TestMethod]
        public void ModifyContractStopDate_YesWithValidStopDate_UpdatesStopDate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n2014\n10\n27";
            DateTime expectedStopDate = new DateTime(2014, 10, 27);
            DateTime actualStopDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStopDate
        * will not modify the contract stop date of an employee if the given date is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStopDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract stop date is 2014-09-12.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract stop date is 2014-09-12.
        */
        [TestMethod]
        public void ModifyContractStopDate_YesWithBlankStopDate_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStopDate
        * will not modify the contract stop date of an employee if the given date is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStopDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n1400\n90\n36"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract stop date is 2014-09-12.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract stop date is 2014-09-12.
        */
        [TestMethod]
        public void ModifyContractStopDate_YesWithInvalidStopDate_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n1400\n90\n36";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStopDate
        * will not modify the contract stop date of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStopDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract stop date is 2014-09-12.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract stop date is 2014-09-12.
        */
        [TestMethod]
        public void ModifyContractStopDate_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStopDate
        * will not modify the contract stop date of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStopDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract stop date is 2014-09-12.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract stop date is 2014-09-12.
        */
        [TestMethod]
        public void ModifyContractStopDate_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyContractStopDate
        * will modify the contract stop date of an employee if an invalid choice is 
        * made and then the user says yes with a valid date.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyContractStopDate.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "no and yes\nY\n2014\n08\n01"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract stop date is 2014-08-01.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract stop date is 2014-08-01.
        */
        [TestMethod]
        public void ModifyContractStopDate_InvalidChoiceThenYesWithValidDate_LoopsBackAndUpdatesDate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n2014\n08\n01";
            DateTime expectedStopDate = new DateTime(2014, 08, 01);
            DateTime actualStopDate = new DateTime();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                // Check if the expected result and actual result are the same
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        // -----------------------------------------
        //      ModifyFixedContractAmount Tests
        // -----------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyFixedContractAmount
        * will modify the contract amount of an employee if the given amount is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFixedContractAmount.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n30000"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract amount is 30000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract amount is 30000.
        */
        [TestMethod]
        public void ModifyFixedContractAmount_YesWithValidContractAmount_UpdatesContractAmount()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n30000";
            double actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                // Check if the expected result and actual result are the same
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(30000, actualContractAmount);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFixedContractAmount
        * will not modify the contract amount of an employee if the given amount is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFixedContractAmount.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract amount is 25000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract amount is 25000.
        */
        [TestMethod]
        public void ModifyFixedContractAmount_YesWithBlankContractAmount_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            double actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                // Check if the expected result and actual result are the same
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFixedContractAmount
        * will not modify the contract amount of an employee if the given amount is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFixedContractAmount.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\n-123456"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract amount is 25000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract amount is 25000.
        */
        [TestMethod]
        public void ModifyFixedContractAmount_YesWithInvalidContractAmount_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n-123456";
            double actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                // Check if the expected result and actual result are the same
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFixedContractAmount
        * will not modify the contract amount of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFixedContractAmount.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract amount is 25000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract amount is 25000.
        */
        [TestMethod]
        public void ModifyFixedContractAmount_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            double actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                // Check if the expected result and actual result are the same
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFixedContractAmount
        * will not modify the contract amount of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFixedContractAmount.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract amount is 25000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract amount is 25000.
        */
        [TestMethod]
        public void ModifyFixedContractAmount_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            double actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                // Check if the expected result and actual result are the same
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyFixedContractAmount
        * will modify the contract amount of an employee if an invalid choice is 
        * made and then the user says yes with a valid amount.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyFixedContractAmount.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "no and yes\nY\n15000"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract amount is 15000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract amount is 15000.
        */
        [TestMethod]
        public void ModifyFixedContractAmount_InvalidChoiceThenYesWithValidAmount_LoopsBackAndUpdatesAmount()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n15000";
            double actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                // Check if the expected result and actual result are the same
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(15000, actualContractAmount);
            }
        }

        // ----------------------------
        //      ModifySeason Tests
        // ----------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifySeason
        * will modify the season of an employee if the given season is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySeason.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\nFall"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's season is Fall.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's season is Fall.
        */
        [TestMethod]
        public void ModifySeason_YesWithValidSeason_UpdatesSeason()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nFall";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySeason", SNEmployee);
                // Check if the expected result and actual result are the same
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Fall", actualSeason);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySeason
        * will not modify the season of an employee if the given season is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySeason.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's season is Summer.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's season is Summer.
        */
        [TestMethod]
        public void ModifySeason_YesWithBlankSeason_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySeason", SNEmployee);
                // Check if the expected result and actual result are the same
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySeason
        * will not modify the season of an employee if the given season is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySeason.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\nSumminter"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's season is Summer.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's season is Summer.
        */
        [TestMethod]
        public void ModifySeason_YesWithInvalidSeason_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSumminter";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySeason", SNEmployee);
                // Check if the expected result and actual result are the same
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySeason
        * will not modify the season of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySeason.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's season is Summer.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's season is Summer.
        */
        [TestMethod]
        public void ModifySeason_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySeason", SNEmployee);
                // Check if the expected result and actual result are the same
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySeason
        * will not modify the season of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySeason.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's season is Summer.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's season is Summer.
        */
        [TestMethod]
        public void ModifySeason_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySeason", SNEmployee);
                // Check if the expected result and actual result are the same
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifySeason
        * will modify the season of an employee if an invalid choice is 
        * made and then the user says yes with a valid season.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifySeason.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "no and yes\nY\nSpring"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's season is Spring.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's season is Spring.
        */
        [TestMethod]
        public void ModifySeason_InvalidChoiceThenYesWithValidSeason_LoopsBackAndUpdatesSeason()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\nSpring";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifySeason", SNEmployee);
                // Check if the expected result and actual result are the same
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Spring", actualSeason);
            }
        }

        // ------------------------------
        //      ModifyPiecePay Tests
        // ------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyPiecePay
        * will modify the piece pay of an employee if the given pay is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyPiecePay.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\n25"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's piece pay is 25.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's piece pay is 25.
        */
        [TestMethod]
        public void ModifyPiecePay_YesWithValidPiecePay_UpdatesPiecePay()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n25";
            double actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                // Check if the expected result and actual result are the same
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(25, actualPiecePay);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyPiecePay
        * will not modify the piece pay of an employee if the given season is blank.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyPiecePay.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\n "
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's piece pay is 20.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's piece pay is 20.
        */
        [TestMethod]
        public void ModifyPiecePay_YesWithBlankPiecePay_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n ";
            double actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                // Check if the expected result and actual result are the same
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyPiecePay
        * will not modify the piece pay of an employee if the given season is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyPiecePay.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\n-10"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's piece pay is 20.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's piece pay is 20.
        */
        [TestMethod]
        public void ModifyPiecePay_YesWithInvalidPiecePay_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\n-10";
            double actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                // Check if the expected result and actual result are the same
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyPiecePay
        * will not modify the piece pay of an employee if the user selects no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyPiecePay.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "N\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's piece pay is 20.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's piece pay is 20.
        */
        [TestMethod]
        public void ModifyPiecePay_No_NoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "N\n";
            double actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                // Check if the expected result and actual result are the same
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyPiecePay
        * will not modify the piece pay of an employee if an invalid choice is 
        * made and then the user says no.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyPiecePay.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "no and yes\nN"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's piece pay is 20.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's piece pay is 20.
        */
        [TestMethod]
        public void ModifyPiecePay_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nN";
            double actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                // Check if the expected result and actual result are the same
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyPiecePay
        * will modify the piece pay of an employee if an invalid choice is 
        * made and then the user says yes with a valid piece pay.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyPiecePay.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is fault/exception then normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "no and yes\nY\n30"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's piece pay is 30.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's piece pay is 30.
        */
        [TestMethod]
        public void ModifyPiecePay_InvalidChoiceThenYesWithValidPay_LoopsBackAndUpdatesPay()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "no and yes\nY\n30";
            double actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                // Check if the expected result and actual result are the same
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(30, actualPiecePay);
            }
        }

        // ------------------------------
        //      ModifyEmployee Tests
        // ------------------------------

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the first name of an employee if the given name is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's first name is Samantha.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's first name is Samantha.
        */
        [TestMethod]
        public void ModifyEmployee_ValidFirstName_ModifiesEmployeeFirstName()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Samantha", actualFirstName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the last name of an employee if the given name is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's last name is Jamieson.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's last name is Jamieson.
        */
        [TestMethod]
        public void ModifyEmployee_ValidLastName_ModifiesEmployeeLastName()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jamieson", actualLastName);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the SIN of an employee if the SIN is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's SIN is 902098933.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's SIN is 902098933.
        */
        [TestMethod]
        public void ModifyEmployee_ValidSIN_ModifiesEmployeeSIN()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                int actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(902098933, actualSIN);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the DOB of an employee if the DOB is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOB is 1990-09-02.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOB is 1990-09-02.
        */
        [TestMethod]
        public void ModifyEmployee_ValidDOB_ModifiesEmployeeDOB()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            DateTime expectedDOB = new DateTime(1990, 09, 20);
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                DateTime actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the type of a full-time employee if the type is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n900398933\nY\n1990\n09\n09\nY\nPT\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is PT.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is PT.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifiesFTEmployeeToPTEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n900398933\nY\n1990\n09\n09\nY\nPT\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(FTEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("PT", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will not modify the type of a full-time employee if entered data is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n900398933\nY\n1990\n09\n09\nY\nPT\nY\n2011\n45\n11\n\nY\n2012\n12\n66\n\nY\n35\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is FT.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is FT.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifyFTEmployeeToPTEmployeeFails()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n900398933\nY\n1990\n09\n09\nY\nPT\nY\n2011\n45\n11\n\nY\n2012\n12\n66\n\nY\n35\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(FTEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("FT", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the type of a part-time employee if the type is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\nMarcus\nY\nSmithy\nY\n872098934\nY\n1987\n07\n22\nY\nCT\nY\n2014\n02\n09\nY\n2014\n09\n13\nY\n25000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is CT.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is CT.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifiesPTEmployeeToCTEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n872098934\nY\n1987\n07\n22\nY\nCT\nY\n2014\n02\n09\nY\n2014\n09\n13\nY\n25000\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(PTEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", PTEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("CT", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will not modify the type of a part-time employee if entered data is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\nMarcus\nY\nSmithy\nY\n872098934\nY\n1987\n07\n22\nY\nCT\nY\n2014\n02\n09\nY\n2014\n09\n13\nY\n0\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is PT.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is PT.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifyPTEmployeeToCTEmployeeFails()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n872098934\nY\n1987\n07\n22\nY\nCT\nY\n2014\n02\n09\nY\n2014\n09\n13\nY\n0\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(PTEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", PTEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("PT", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the type of a contract employee if the type is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\nAnnie\nY\nMillerton\nY\n892398402\nY\n1989\n03\n04\nY\nSN\nY\nWinter\nY\n10000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is SN.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is SN.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifiesCTEmployeeToSNEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398402\nY\n1989\n03\n04\nY\nSN\nY\nWinter\nY\n10000\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(CTEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", CTEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("SN", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will not modify the type of a contract employee if entered data is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\nAnnie\nY\nMillerton\nY\n892398402\nY\n1989\n03\n04\nY\nSN\nY\nFalummer\n\nY\n10000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is CT.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is CT.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifyCTEmployeeToSNEmployeeFails()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398402\nY\n1989\n03\n04\nY\nSN\nY\nFalummer\n\nY\n10000\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(CTEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", CTEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("CT", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the type of a seasonal employee if the type is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\nJake\nY\nWilliams\nY\n902198934\nY\n1990\n09\n08\nY\nFT\nY\n2010\n03\n12\nY\n2014\n05\n23\nY\n85000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is FT.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is FT.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifiesSNEmployeeToFTEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nJake\nY\nWilliams\nY\n902198934\nY\n1990\n09\n08\nY\nFT\nY\n2010\n03\n12\nY\n2014\n05\n23\nY\n85000\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(SNEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", SNEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("FT", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will not modify the type of a seasonal employee if entered data is invalid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\nJake\nY\nWilliams\nY\n902198934\nY\n1990\n09\n08\nY\nFT\nY\n2010\n03\n12\nY\n2014\n05\n23\nY\n0\n\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's type is SN.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's type is SN.
        */
        [TestMethod]
        public void ModifyEmployee_ValidType_ModifySNEmployeeToFTEmployeeFails()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nJake\nY\nWilliams\nY\n902198934\nY\n1990\n09\n08\nY\nFT\nY\n2010\n03\n12\nY\n2014\n05\n23\nY\n0\n\n";
            var privateObject = new PrivateObject(employeeRepo);
            employeeRepo.AddEmployeeToList(SNEmployee);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", SNEmployee);

                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual("SN", employeeList[0].GetEmployeeType());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the DOH of a full-time employee if the DOH is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2011-10-11.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2011-10-11.
        */
        [TestMethod]
        public void ModifyEmployee_ValidDateOfHire_ModifiesFulltimeEmployeeDateOfHire()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            DateTime expectedDOH = new DateTime(2011, 10, 11);
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                DateTime actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the DOT of a full-time employee if the DOT is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n900989332\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2012-12-02.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2012-12-02.
        */
        [TestMethod]
        public void ModifyEmployee_ValidDateOfTermination_ModifiesFulltimeEmployeeDateOfTermination()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n900989332\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            DateTime expectedDOT = new DateTime(2012, 12, 02);
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                DateTime actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the salary of an employee if the salary is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A full-time employee reference: 
        * DateTime dateOfBirth = new DateTime(1990, 09, 10);
        * DateTime dateOfHire = new DateTime(2010, 10, 11);
        * DateTime dateOfTermination = new DateTime(2012, 02, 19);
        * FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 902398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);
        * Input string:
        * "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's salary is 70000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's salary is 70000.
        */
        [TestMethod]
        public void ModifyEmployee_ValidSalary_ModifiesEmployeeSalary()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n902098933\nY\n1990\n09\n20\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                // Check if the expected result and actual result are the same
                double actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(70000, actualSalary);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the DOH of a part-time employee if the DOH is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\nMarcus\nY\nSmithy\nY\n900398988\nY\n1990\n09\n09\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOH is 2011-10-11.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOH is 2011-10-11.
        */
        [TestMethod]
        public void ModifyEmployee_ValidDateOfHire_ModifiesParttimeEmployeeDateOfHire()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n900398988\nY\n1990\n09\n09\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n";
            DateTime expectedDOH = new DateTime(2011, 10, 11);
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", PTEmployee);
                // Check if the expected result and actual result are the same
                DateTime actualDOH = PTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the DOT of a part-time employee if the DOT is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\nMarcus\nY\nSmithy\nY\n900398988\nY\n1990\n09\n09\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's DOT is 2011-10-11.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's DOT is 2011-10-11.
        */
        [TestMethod]
        public void ModifyEmployee_ValidDateOfTermination_ModifiesParttimeEmployeeDateOfTermination()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n900398988\nY\n1990\n09\n09\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n";
            DateTime expectedDOT = new DateTime(2012, 12, 02);
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", PTEmployee);
                // Check if the expected result and actual result are the same
                DateTime actualDOT = PTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the hourly rate of an employee if the hourly rate is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A part-time employee reference: 
        * dateOfBirth = new DateTime(1987, 06, 22);
        * dateOfHire = new DateTime(2013, 04, 12);
        * dateOfTermination = new DateTime(2014, 05, 13);
        * PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 872098933, dateOfBirth, dateOfHire, dateOfTermination, 30);
        * Input string:
        * "Y\nMarcus\nY\nSmithy\nY\n900398988\nY\n1990\n09\n09\nN\nY\n2010\n10\n11\nY\n2012\n12\n02\nY\n35\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's hourly rate is 35.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's hourly rate is 35.
        */
        [TestMethod]
        public void ModifyEmployee_ValidHourlyRate_ModifiesEmployeeHourlyRate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n900398988\nY\n1990\n09\n09\nN\nY\n2010\n10\n11\nY\n2012\n12\n02\nY\n35\n";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", PTEmployee);
                // Check if the expected result and actual result are the same
                double actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(35, actualHourlyRate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the contract start date of an employee if the date is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract start date is 2014-03-08.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract start date is 2014-03-08.
        */
        [TestMethod]
        public void ModifyEmployee_ValidContractStartDate_ModifiesEmployeeContractStartDate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n";
            DateTime expectedContractStartDate = new DateTime(2014, 03, 08);
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", CTEmployee);
                // Check if the expected result and actual result are the same
                DateTime actualContractStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedContractStartDate, actualContractStartDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the contract stop date of an employee if the date is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract stop date is 2014-10-12.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract stop date is 2014-10-12.
        */
        [TestMethod]
        public void ModifyEmployee_ValidContractStopDate_ModifiesEmployeeContractStopDate()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n";
            DateTime expectedContractStopDate = new DateTime(2014, 10, 12);
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", CTEmployee);
                // Check if the expected result and actual result are the same
                DateTime actualContractStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedContractStopDate, actualContractStopDate);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the contract amount of an employee if the amount is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A contract employee reference: 
        * dateOfBirth = new DateTime(1989, 07, 02);
        * DateTime contractStartDate = new DateTime(2014, 02, 08);
        * DateTime contractStopDate = new DateTime(2014, 09, 12);
        * CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);
        * Input string:
        * "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's contract amount is 10000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's contract amount is 10000.
        */
        [TestMethod]
        public void ModifyEmployee_ValidFixedContractAmount_ModifiesEmployeeFixedContractAmount()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", CTEmployee);
                // Check if the expected result and actual result are the same
                double actualFixedContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(10000, actualFixedContractAmount);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the season of an employee if the season is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\nJacob\nY\nWilliams\nY\n902098988\nY\n1990\n09\n20\nN\nY\nFall\nY\n15000"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's season is Fall.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's season is Fall.
        */
        [TestMethod]
        public void ModifyEmployee_ValidSeason_ModifiesEmployeeSeason()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nJacob\nY\nWilliams\nY\n902098988\nY\n1990\n09\n20\nN\nY\nFall\nY\n15000";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", SNEmployee);
                // Check if the expected result and actual result are the same
                String actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Fall", actualSeason);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method ModifyEmployee
        * will modify the piece pay of an employee if the piece pay is valid.
        * 
        * \ <b> Name of Method</b>
        * The method being tested is ModifyEmployee.
        * 
        * \ <b> How test is Conducted</b>
        * The test is automatically conducted.
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * A seasonal employee reference: 
        * dateOfBirth = new DateTime(1991, 03, 18);
        * SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 912098933, dateOfBirth, "Summer", 20);
        * Input string:
        * "Y\nJacob\nY\nWilliams\nY\n902098988\nY\n1990\n09\n20\nN\nY\nFall\nY\n15000"
        *    
        * \ <b> Expected Result</b>
        * The expected result is that the employee's piece pay is 15000.
        * 
        * \ <b> Actual Result</b>
        * The actual result is that the employee's piece pay is 15000.
        */
        [TestMethod]
        public void ModifyEmployee_ValidPiecePay_ModifiesEmployeePiecePay()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Y\nJacob\nY\nWilliams\nY\n902098988\nY\n1990\n09\n20\nN\nY\nFall\nY\n15000";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("ModifyEmployee", SNEmployee);
                // Check if the expected result and actual result are the same
                double actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(15000, actualPiecePay);
            }
        }
    }
}
