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

        // ======================================= GetFulltimeEmployeeProperties Tests =======================================
        //normal
        [TestMethod]
        public void GetFulltimeEmployeeProperties_ValidProperties_ReturnsValidFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Sam\nJones\n212398402\n1990\n09\n10\n0001\n01\n01\n2010\n10\n11\n50000";
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

        //exception
        [TestMethod]
        public void GetFulltimeEmployeeProperties_InvalidProperties_ReturnsBlankFulltimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Sam\nJones\n212398402\n1990\n94\n100\n0001\n01\n01\n2010\n67\n11\n50000";
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

        // ======================================= GetParttimeEmployeeProperties Tests =======================================
        //normal
        [TestMethod]
        public void GetParttimeEmployeeProperties_ValidProperties_ReturnsValidParttimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Mark\nSmith\n432098933\n1987\n06\n22\n0001\n01\n01\n30\n2013\n04\n12\n";
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

        //exception
        [TestMethod]
        public void GetParttimeEmployeeProperties_InvalidProperties_ReturnsBlankParttimeEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Mark\nSmith\n43209893&\n1987\n06\n78\n0001\n01\n01\n30\n2013\n04\n12\n";
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

        // ======================================= GetContractEmployeeProperties Tests =======================================
        //normal
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

        //exception
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



        // ======================================= GetSeasonalEmployeeProperties Tests =======================================
        [TestMethod]
        public void GetSeasonalEmployeeProperties_ValidProperties_ReturnsValidSeasonalEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Jake\nWilliams\n432098933\n1991\n03\n18\nFall\n20000\n";
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

        [TestMethod]
        public void GetSeasonalEmployeeProperties_InvalidProperties_ReturnsBlankSeasonalEmployee()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "Jake\nWilliams\n432098933\n1800\n23\n55\nFFFF\n20000\n";
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


        // ======================================= AddEmployee Tests =======================================
        //fulltime
        [TestMethod]
        public void AddEmployee_ValidProperties_FulltimeEmployeeAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "FT\nSam\nJones\n212398402\n1990\n09\n10\n0001\n01\n01\n2010\n10\n11\n50000";
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

        [TestMethod]
        public void AddEmployee_InvalidProperties_FulltimeEmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "FT\nSam\nJones\n21239*402\n1990\n09\n10\n0001\n01\n01\n2010\n10\n65\n50000";
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

        //parttime
        [TestMethod]
        public void AddEmployee_ValidProperties_ParttimeEmployeeAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "PT\nMark\nSmith\n432098933\n1987\n06\n22\n0001\n01\n01\n30\n2013\n04\n12";
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

        [TestMethod]
        public void AddEmployee_InvalidProperties_ParttimeEmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "PT\nMark\nSmith\n432098933\n1987\n33\n122\n0001\n01\n01\n30\n2013\n04\n12";
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

        //contract
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

        //seasonal
        [TestMethod]
        public void AddEmployee_ValidProperties_SeasonalEmployeeAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "SN\nJake\nWilliams\n432098933\n1991\n03\n18\nSummer\n10000";
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

        [TestMethod]
        public void AddEmployee_InvalidProperties_SeasonalEmployeeNotAddedToList()
        {
            // Initialize a string with input data and initalize other variables
            String dataToPassIn = "SN\nJake\nWilliams\n432098933\n1991\n03\n18\nSumwinter\n10000";
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

        //fault
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
