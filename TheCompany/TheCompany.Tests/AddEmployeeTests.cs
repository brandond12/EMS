/*
* FILE   : AddEmployeeTests.cs
* PROJECT  : INFO2180 - Software Quality I - EMS
* PROGRAMMER : Lauren Machan
* FIRST VERSION : 2015-11-29
* DESCRIPTION : 
* This file contains the AddEmployeeTests class, which is used to test methods
* in the Container class that revolve around creating employee objects.
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
    public class AddEmployeeTests
    {
        private Container employeeRepo; // A reference to a Container object

        [TestInitialize]
        public void TestInitialize()
        {
            // Instantiate the container
            employeeRepo = new Container();
        }

        // ---------------------------------------------
        //      GetFulltimeEmployeeProperties Tests
        // ---------------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method GetFulltimeEmployeeProperties
        * creates an employee from the given information and returns that employee.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetFulltimeEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is Sam.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is Sam.
        */
        [TestMethod]
        public void GetFulltimeEmployeeProperties_ValidProperties_ReturnsValidFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Sam\nJones\n902398402\n1990\n09\n10\n2015\n06\n28\n2010\n10\n11\n50000";
            FulltimeEmployee FTEmployee = new FulltimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                FTEmployee = (FulltimeEmployee)privateObject.Invoke("GetFulltimeEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Sam", FTEmployee.GetFirstName());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method GetFulltimeEmployeeProperties
        * will return a blank employee if the given information is invalid.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetFulltimeEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is blank.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is blank.
        */
        [TestMethod]
        public void GetFulltimeEmployeeProperties_InvalidProperties_ReturnsBlankFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Sam\nJones\n902398402\n1990\n94\n100\n1234\n19\n32\n2010\n67\n11\n50000";
            FulltimeEmployee FTEmployee = new FulltimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                FTEmployee = (FulltimeEmployee)privateObject.Invoke("GetFulltimeEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", FTEmployee.GetFirstName());
            }
        }

        // ---------------------------------------------
        //      GetParttimeEmployeeProperties Tests
        // ---------------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method GetParttimeEmployeeProperties
        * creates an employee from the given information and returns that employee.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetParttimeEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is Mark.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is Mark.
        */
        [TestMethod]
        public void GetParttimeEmployeeProperties_ValidProperties_ReturnsValidParttimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Mark\nSmith\n872098933\n1987\n06\n22\n2015\n11\n16\n30\n2013\n04\n12\n";
            ParttimeEmployee PTEmployee = new ParttimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                PTEmployee = (ParttimeEmployee)privateObject.Invoke("GetParttimeEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Mark", PTEmployee.GetFirstName());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method GetParttimeEmployeeProperties
        * will return a blank employee if the given information is invalid.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetParttimeEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is blank.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is blank.
        */
        [TestMethod]
        public void GetParttimeEmployeeProperties_InvalidProperties_ReturnsBlankParttimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Mark\nSmith\n87209893&\n1987\n06\n78\n1800\n04\n01\n30\n2013\n04\n12\n";
            ParttimeEmployee PTEmployee = new ParttimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                PTEmployee = (ParttimeEmployee)privateObject.Invoke("GetParttimeEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", PTEmployee.GetFirstName());
            }
        }

        // ---------------------------------------------
        //      GetContractEmployeeProperties Tests
        // ---------------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method GetContractEmployeeProperties
        * creates an employee from the given information and returns that employee.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetContractEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is Anna.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is Anna.
        */
        [TestMethod]
        public void GetContractEmployeeProperties_ValidProperties_ReturnsValidContractEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Anna\nMiller\n892398402\n1989\n07\n02\n2014\n02\n08\n2014\n09\n12\n25000";
            ContractEmployee CTEmployee = new ContractEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                CTEmployee = (ContractEmployee)privateObject.Invoke("GetContractEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Anna", CTEmployee.GetFirstName());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method GetContractEmployeeProperties
        * will return a blank employee if the given information is invalid.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetContractEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is blank.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is blank.
        */
        [TestMethod]
        public void GetContractEmployeeProperties_InvalidProperties_ReturnsBlankContractEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Anna\nMiller\n89CFGH402\n1989\n07\n02\n2014\n34\n08\n2014\n09\n12\n25000";
            ContractEmployee CTEmployee = new ContractEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                CTEmployee = (ContractEmployee)privateObject.Invoke("GetContractEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", CTEmployee.GetFirstName());
            }
        }

        // ---------------------------------------------
        //      GetSeasonalEmployeeProperties Tests
        // ---------------------------------------------

        /**
        * \brief The unit test's purpose is to test if the method GetSeasonalEmployeeProperties
        * creates an employee from the given information and returns that employee.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetSeasonalEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is Jake.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is Jake.
        */
        [TestMethod]
        public void GetSeasonalEmployeeProperties_ValidProperties_ReturnsValidSeasonalEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Jake\nWilliams\n912098933\n1991\n03\n18\nFall\n20\n";
            SeasonalEmployee SNEmployee = new SeasonalEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                SNEmployee = (SeasonalEmployee)privateObject.Invoke("GetSeasonalEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("Jake", SNEmployee.GetFirstName());
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method GetSeasonalEmployeeProperties
        * will return a blank employee if the given information is invalid.
        * 
        * \<b>Name of Method/b>
        * The method being tested is GetSeasonalEmployeeProperties.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the name of the returned employee is blank.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the name of the returned employee is blank.
        */
        [TestMethod]
        public void GetSeasonalEmployeeProperties_InvalidProperties_ReturnsBlankSeasonalEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Jake\nWilliams\n902098933\n1800\n23\n55\nFFFF\n20\n";
            SeasonalEmployee SNEmployee = new SeasonalEmployee();
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                SNEmployee = (SeasonalEmployee)privateObject.Invoke("GetSeasonalEmployeeProperties");
                // Check if the expected result and actual result are the same
                Assert.AreEqual("", SNEmployee.GetFirstName());
            }
        }

        // ---------------------------
        //      AddEmployee Tests
        // ---------------------------

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * create a full-time employee from the given information and add that employee 
        * to a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 1.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 1.
        */
        [TestMethod]
        public void AddEmployee_ValidProperties_FulltimeEmployeeAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "FT\nSam\nJones\n902398402\n1990\n09\n10\n2015\n01\n02\n2010\n10\n11\n50000";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * not create a full-time employee from the given invalid information and therefore 
        * not add it to the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 0.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 0.
        */
        [TestMethod]
        public void AddEmployee_InvalidProperties_FulltimeEmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "FT\nSam\nJones\n90239*402\n1990\n09\n10\n2015\n06\n04\n2010\n10\n65\n50000";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * create a part-time employee from the given information and add that employee 
        * to a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 1.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 1.
        */
        [TestMethod]
        public void AddEmployee_ValidProperties_ParttimeEmployeeAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "PT\nMark\nSmith\n872098933\n1987\n06\n22\n2014\n08\n14\n30\n2013\n04\n12";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * not create a part-time employee from the given invalid information and therefore 
        * not add it to the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 0.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 0.
        */
        [TestMethod]
        public void AddEmployee_InvalidProperties_ParttimeEmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "PT\nMark\nSmith\n872098933\n1987\n33\n122\n2015\n07\n13\n30\n2013\n04\n12";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * create a contract employee from the given information and add that employee 
        * to a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 1.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 1.
        */
        [TestMethod]
        public void AddEmployee_ValidProperties_ContractEmployeeAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "CT\nAnna\nMiller\n892398402\n1989\n07\n02\n2014\n02\n08\n2014\n09\n12\n15000";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * not create a contract employee from the given invalid information and therefore 
        * not add it to the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 0.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 0.
        */
        [TestMethod]
        public void AddEmployee_InvalidProperties_ContractEmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "CT\nAnna\nMiller\n892398402\n1989\n07\n02\n2014\n02\n08\n2014\n99\n48\n15000";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * create a seasonal employee from the given information and add that employee 
        * to a list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 1.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 1.
        */
        [TestMethod]
        public void AddEmployee_ValidProperties_SeasonalEmployeeAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "SN\nJake\nWilliams\n912098933\n1991\n03\n18\nSummer\n10";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }


        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * not create a seasonal employee from the given invalid information and therefore 
        * not add it to the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 0.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 0.
        */
        [TestMethod]
        public void AddEmployee_InvalidProperties_SeasonalEmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "SN\nJake\nWilliams\n912098933\n1991\n03\n18\nSumwinter\n10";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

        /**
        * \brief The unit test's purpose is to test if the method AddEmployee will
        * not create an employee from the given invalid employee type and therefore 
        * not add it to the employee list.
        * 
        * \<b>Name of Method/b>
        * The method being tested is AddEmployee.
        * 
        * \<b>How test is Conducted/b>
        * The test is automatically conducted.
        * 
        * \<b>Type of Test</b>
        * The type of test is fault/exception.
        * 
        * \<b>Sample Data Sets</b>
        * n/a
        *    
        * \<b>Expected Result</b>
        * The expected result is that the employeeList.Count will return 0.
        * 
        * \<b>Actual Result</b>
        * The actual result is that the employeeList.Count returns 0.
        */
        [TestMethod]
        public void AddEmployee_InvalidEmployeeType_EmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "OT\n";
            var privateObject = new PrivateObject(employeeRepo);

            // Set the console to read input from the input data string
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                // Execute the method that is being tested
                privateObject.Invoke("AddEmployee");
                // Check if the expected result and actual result are the same
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }
    }
}
