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
        private TheCompany.Container employeeRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            employeeRepo = new Container();

        }


        // ======================================= GetFulltimeEmployeeProperties Tests =======================================
        //normal
        [TestMethod]
        public void GetFulltimeEmployeeProperties_ValidProperties_ReturnsValidFulltimeEmployee()
        {
            String dataToPassIn = "Sam\nJones\n212398402\n1990\n09\n10\n0001\n01\n01\n2010\n10\n11\n50000";
            //String dataToPassIn = "Sam\nJones\n212398402\n1990\n09\n10\n2010\n10\n11\n0001\n01\n01\n50000";
            FulltimeEmployee FTEmployee = new FulltimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                FTEmployee = (FulltimeEmployee)privateObject.Invoke("GetFulltimeEmployeeProperties");
                Assert.AreEqual("Sam", FTEmployee.GetFirstName());
            }
        }

        //exception
        [TestMethod]
        public void GetFulltimeEmployeeProperties_InvalidProperties_ReturnsBlankFulltimeEmployee()
        {
            String dataToPassIn = "Sam\nJones\n212398402\n1990\n94\n100\n0001\n01\n01\n2010\n67\n11\n50000";
            //String dataToPassIn = "Sam\nJones\n212398402\n1990\n09\n10\n2010\n90\n11\n0001\n01\n100\n50000";
            FulltimeEmployee FTEmployee = new FulltimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                FTEmployee = (FulltimeEmployee)privateObject.Invoke("GetFulltimeEmployeeProperties");
                Assert.AreEqual("", FTEmployee.GetFirstName());
            }
        }

        // ======================================= GetParttimeEmployeeProperties Tests =======================================
        //normal
        [TestMethod]
        public void GetParttimeEmployeeProperties_ValidProperties_ReturnsValidParttimeEmployee()
        {
            String dataToPassIn = "Mark\nSmith\n432098933\n1987\n06\n22\n0001\n01\n01\n30\n2013\n04\n12\n";
            //String dataToPassIn = "Mark\nSmith\n432098933\n1987\n06\n22\n2013\n04\n12\n0001\n01\n01\n30";
            ParttimeEmployee PTEmployee = new ParttimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                PTEmployee = (ParttimeEmployee)privateObject.Invoke("GetParttimeEmployeeProperties");
                Assert.AreEqual("Mark", PTEmployee.GetFirstName());
            }
        }

        //exception
        [TestMethod]
        public void GetParttimeEmployeeProperties_InvalidProperties_ReturnsBlankParttimeEmployee()
        {
            String dataToPassIn = "Mark\nSmith\n43209893&\n1987\n06\n78\n0001\n01\n01\n30\n2013\n04\n12\n";
            //String dataToPassIn = "Mark\nSmith\n43209893&\n1987\n06\n78\n2013\n04\n12\n0001\n01\n01\n30";
            ParttimeEmployee PTEmployee = new ParttimeEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                PTEmployee = (ParttimeEmployee)privateObject.Invoke("GetParttimeEmployeeProperties");
                Assert.AreEqual("", PTEmployee.GetFirstName());
            }
        }

        // ======================================= GetContractEmployeeProperties Tests =======================================
        //normal
        [TestMethod]
        public void GetContractEmployeeProperties_ValidProperties_ReturnsValidContractEmployee()
        {
            String dataToPassIn = "Anna\nMiller\n892398402\n1989\n07\n02\n2014\n02\n08\n2014\n09\n12\n25000";
            ContractEmployee CTEmployee = new ContractEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                CTEmployee = (ContractEmployee)privateObject.Invoke("GetContractEmployeeProperties");
                Assert.AreEqual("Anna", CTEmployee.GetFirstName());
            }
        }

        //exception
        [TestMethod]
        public void GetContractEmployeeProperties_InvalidProperties_ReturnsBlankContractEmployee()
        {
            String dataToPassIn = "Anna\nMiller\n89CFGH402\n1989\n07\n02\n2014\n34\n08\n2014\n09\n12\n25000";
            ContractEmployee CTEmployee = new ContractEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                CTEmployee = (ContractEmployee)privateObject.Invoke("GetContractEmployeeProperties");
                Assert.AreEqual("", CTEmployee.GetFirstName());
            }
        }



        // ======================================= GetSeasonalEmployeeProperties Tests =======================================
        [TestMethod]
        public void GetSeasonalEmployeeProperties_ValidProperties_ReturnsValidSeasonalEmployee()
        {
            String dataToPassIn = "Jake\nWilliams\n432098933\n1991\n03\n18\nFall\n20000\n";
            SeasonalEmployee SNEmployee = new SeasonalEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                SNEmployee = (SeasonalEmployee)privateObject.Invoke("GetSeasonalEmployeeProperties");
                Assert.AreEqual("Jake", SNEmployee.GetFirstName());
            }
        }

        [TestMethod]
        public void GetSeasonalEmployeeProperties_InvalidProperties_ReturnsBlankSeasonalEmployee()
        {
            String dataToPassIn = "Jake\nWilliams\n432098933\n1800\n23\n55\nFFFF\n20000\n";
            SeasonalEmployee SNEmployee = new SeasonalEmployee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                SNEmployee = (SeasonalEmployee)privateObject.Invoke("GetSeasonalEmployeeProperties");
                Assert.AreEqual("", SNEmployee.GetFirstName());
            }
        }


        // ======================================= AddEmployee Tests =======================================
        [TestMethod]
        public void AddEmployee_ValidProperties_FulltimeEmployeeAddedToList()
        {
            String dataToPassIn = "FT\nSam\nJones\n212398402\n1990\n09\n10\n0001\n01\n01\n2010\n10\n11\n50000";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }

        [TestMethod]
        public void AddEmployee_InvalidProperties_FulltimeEmployeeNotAddedToList()
        {
            String dataToPassIn = "FT\nSam\nJones\n21239*402\n1990\n09\n10\n0001\n01\n01\n2010\n10\n65\n50000";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

        [TestMethod]
        public void AddEmployee_ValidProperties_ParttimeEmployeeAddedToList()
        {
            String dataToPassIn = "PT\nMark\nSmith\n432098933\n1987\n06\n22\n0001\n01\n01\n30\n2013\n04\n12";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }

        [TestMethod]
        public void AddEmployee_InvalidProperties_ParttimeEmployeeNotAddedToList()
        {
            String dataToPassIn = "PT\nMark\nSmith\n432098933\n1987\n33\n122\n0001\n01\n01\n30\n2013\n04\n12";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

        
        [TestMethod]
        public void AddEmployee_ValidProperties_ContractEmployeeAddedToList()
        {
            String dataToPassIn = "CT\nAnna\nMiller\n892398402\n1989\n07\n02\n2014\n02\n08\n2014\n09\n12\n15000";

            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }

        [TestMethod]
        public void AddEmployee_InvalidProperties_ContractEmployeeNotAddedToList()
        {
            String dataToPassIn = "CT\nAnna\nMiller\n892398402\n1989\n07\n02\n2014\n02\n08\n2014\n99\n48\n15000";

            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

        
        [TestMethod]
        public void AddEmployee_ValidProperties_SeasonalEmployeeAddedToList()
        {
            String dataToPassIn = "SN\nJake\nWilliams\n432098933\n1991\n03\n18\nSummer\n10000";

            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(1, employeeList.Count);
            }
        }

        [TestMethod]
        public void AddEmployee_InvalidProperties_SeasonalEmployeeNotAddedToList()
        {
            String dataToPassIn = "SN\nJake\nWilliams\n432098933\n1991\n03\n18\nSumwinter\n10000";

            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

       
        [TestMethod]
        public void AddEmployee_InvalidEmployeeType_EmployeeNotAddedToList()
        {
            String dataToPassIn = "OT\n";

            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("AddEmployee");
                List<Employee> employeeList = (List<Employee>)privateObject.GetField("listOfEmployees");
                Assert.AreEqual(0, employeeList.Count);
            }
        }

    }
}
