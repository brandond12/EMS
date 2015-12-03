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
        private TheCompany.Container employeeRepo;
        AllEmployees.FulltimeEmployee FTEmployee; // A reference to a full-time employee object to be tested with

        [TestInitialize]
        public void TestInitialize()
        {
            employeeRepo = new Container();

            DateTime dateOfBirth = new DateTime(1990, 09, 10);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 212398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);

            employeeRepo.AddEmployeeToList(FTEmployee);
        }

        // ======================================= SelectEmployee Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndYes_SelectsValidEmployee()
        {
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndNo_ReturnsBlankEmployee()
        {
            String dataToPassIn = "N\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            String dataToPassIn = "no and yes\nY";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughListAndInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            String dataToPassIn = "no and yes\nN";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployee_GoesThroughBlankList_ReturnsBlankEmployee()
        {
            Container testRepo = new Container();
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(testRepo);
            actualEmployee = (Employee)privateObject.Invoke("SelectEmployee");
            Assert.AreEqual("", actualEmployee.GetFirstName());
        }


        // ======================================= SelectEmployeeByFirstName Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithYes_SelectsValidEmployee()
        {
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithNo_ReturnsBlankEmployee()
        {
            String dataToPassIn = "N\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            String dataToPassIn = "no and yes\nY";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFirstName_ValidFirstNameWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            String dataToPassIn = "no and yes\nN";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Sam");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeByFirstName_FirstNameNotFound_ReturnsBlankEmployee()
        {
            String dataToPassIn = "";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFirstName", "Michelle");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= SelectEmployeeByFullName Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithYes_SelectsValidEmployee()
        {
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithNo_ReturnsBlankEmployee()
        {
            String dataToPassIn = "N\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            String dataToPassIn = "no and yes\nY";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByFullName_ValidFullNameWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            String dataToPassIn = "no and yes\nN";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Jones");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeByFullName_FullNameNotFound_ReturnsBlankEmployee()
        {
            String dataToPassIn = "";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByFullName", "Sam", "Williams");
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= SelectEmployeeBySIN Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithYes_SelectsValidEmployee()
        {
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithNo_ReturnsBlankEmployee()
        {
            String dataToPassIn = "N\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            String dataToPassIn = "no and yes\nY";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeBySIN_ValidSINWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            String dataToPassIn = "no and yes\nN";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 212398402);
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeBySIN_SINNotFound_ReturnsBlankEmployee()
        {
            String dataToPassIn = "";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeBySIN", 173498562);
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= SelectEmployeeByDOB Tests =======================================
        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithYes_SelectsValidEmployee()
        {
            String dataToPassIn = "Y\n"; 
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithNo_ReturnsBlankEmployee()
        {
            String dataToPassIn = "N\n";
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }


        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            String dataToPassIn = "no and yes\nY";
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void SelectEmployeeByDOB_ValidDOBWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            String dataToPassIn = "no and yes\nN";
            DateTime dateToSearch = new DateTime(1990, 09, 10);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // fault
        public void SelectEmployeeByDOB_DOBNotFound_ReturnsBlankEmployee()
        {
            String dataToPassIn = "";
            DateTime dateToSearch = new DateTime(1991, 08, 24);
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("SelectEmployeeByDOB", dateToSearch);
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        // ======================================= IsThisTheDesiredEmployee Tests =======================================
        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithYes_ReturnsValidEmployee()
        {
            String dataToPassIn = "Y\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithNo_ReturnsBlankEmployee()
        {
            String dataToPassIn = "N\n";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
                Assert.AreEqual("", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithInvalidChoiceThenYes_LoopsBackAndSelectsEmployee()
        {
            String dataToPassIn = "no and yes\nY";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
                Assert.AreEqual("Sam", actualEmployee.GetFirstName());
            }
        }

        [TestMethod]
        // normal
        public void IsThisTheDesiredEmployee_ValidEmployeeWithInvalidChoiceThenNo_LoopsBackAndReturnsBlankEmployee()
        {
            String dataToPassIn = "no and yes\nN";
            Employee actualEmployee = new Employee();
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualEmployee = (Employee)privateObject.Invoke("IsThisTheDesiredEmployee", FTEmployee);
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
            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", FTEmployee);
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidFulltimeEmployeeWithNo_ReturnsNo()
        {
            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", FTEmployee);
                Assert.AreEqual("N", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidParttimeEmployeeWithYes_ReturnsYes()
        {
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 432098933, dateOfBirth, dateOfHire, dateOfTermination, 30);

            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", PTEmployee);
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidParttimeEmployeeWithNo_ReturnsNo()
        {
            DateTime dateOfBirth = new DateTime(1987, 06, 22);
            DateTime dateOfHire = new DateTime(2013, 04, 12);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            ParttimeEmployee PTEmployee = new ParttimeEmployee("Mark", "Smith", 432098933, dateOfBirth, dateOfHire, dateOfTermination, 30);

            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", PTEmployee);
                Assert.AreEqual("N", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidContractEmployeeWithYes_ReturnsYes()
        {
            DateTime dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee = new ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);

            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", CTEmployee);
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidContractEmployeeWithNo_ReturnsNo()
        {
            DateTime dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            ContractEmployee CTEmployee = new ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);

            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", CTEmployee);
                Assert.AreEqual("N", actualString);
            }
        }


        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidSeasonalEmployeeWithYes_ReturnsYes()
        {
            DateTime dateOfBirth = new DateTime(1991, 03, 18);
            SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 432098933, dateOfBirth, "Summer", 20);

            String dataToPassIn = "Y\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", SNEmployee);
                Assert.AreEqual("Y", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidSeasonalEmployeeWithNo_ReturnsNo()
        {
            DateTime dateOfBirth = new DateTime(1991, 03, 18);
            SeasonalEmployee SNEmployee = new SeasonalEmployee("Jake", "Williams", 432098933, dateOfBirth, "Summer", 20);

            String dataToPassIn = "N\n";
            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", SNEmployee);
                Assert.AreEqual("N", actualString);
            }
        }

        [TestMethod]
        // normal
        public void DisplayEmployeeDetails_ValidEmployee_ReturnsBlankString()
        {
            DateTime dateOfBirth = new DateTime(1987, 11, 29);
            Employee employee = new Employee("Janet", "Moore", 122046045, dateOfBirth, "");

            String actualString = "";
            var privateObject = new PrivateObject(employeeRepo);
            actualString = (String)privateObject.Invoke("DisplayEmployeeDetails", employee);
            Assert.AreEqual("", actualString);
        }

    }
}
