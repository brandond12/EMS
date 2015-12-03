using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;
using System.IO;
using TheCompany;

namespace TheCompany.Tests
{
    [TestClass]
    public class ModifyEmployeeTests
    {
        private TheCompany.Container employeeRepo;

        AllEmployees.FulltimeEmployee FTEmployee; // A reference to a full-time employee object to be tested with
        AllEmployees.ParttimeEmployee PTEmployee;
        AllEmployees.ContractEmployee CTEmployee;
        AllEmployees.SeasonalEmployee SNEmployee;

        [TestInitialize]
        public void TestInitialize()
        {
            employeeRepo = new Container();

            DateTime dateOfBirth = new DateTime(1990, 09, 10);
            DateTime dateOfHire = new DateTime(2010, 10, 11);
            DateTime dateOfTermination = new DateTime(0001, 01, 01);
            FTEmployee = new AllEmployees.FulltimeEmployee("Sam", "Jones", 212398402, dateOfBirth, dateOfHire, dateOfTermination, 50000);

            dateOfBirth = new DateTime(1987, 06, 22);
            dateOfHire = new DateTime(2013, 04, 12);
            dateOfTermination = new DateTime(0001, 01, 01);
            PTEmployee = new AllEmployees.ParttimeEmployee("Mark", "Smith", 432098933, dateOfBirth, dateOfHire, dateOfTermination, 30);

            dateOfBirth = new DateTime(1989, 07, 02);
            DateTime contractStartDate = new DateTime(2014, 02, 08);
            DateTime contractStopDate = new DateTime(2014, 09, 12);
            CTEmployee = new AllEmployees.ContractEmployee("Anna", "Miller", 892398402, dateOfBirth, contractStartDate, contractStopDate, 25000);

            dateOfBirth = new DateTime(1991, 03, 18);
            SNEmployee = new AllEmployees.SeasonalEmployee("Jake", "Williams", 432098933, dateOfBirth, "Summer", 20);
        }

        // ======================================= ModifyFirstName Tests =======================================
        [TestMethod]
        // normal
        public void ModifyFirstName_YesWithValidFirstName_UpdatesFirstName()
        {
            String dataToPassIn = "Y\nSamantha";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Samantha", actualFirstName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFirstName_YesWithBlankFirstName_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFirstName_YesWithInvalidFirstName_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n12345";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        [TestMethod]
        // normal
        public void ModifyFirstName_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFirstName_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Sam", actualFirstName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFirstName_InvalidChoiceThenYesWithValidFirstName_LoopsBackAndUpdatesFirstName()
        {
            String dataToPassIn = "no and yes\nY\nSamantha";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFirstName", FTEmployee);
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Samantha", actualFirstName);
            }
        }

        // ======================================= ModifyLastName Tests =======================================
        [TestMethod]
        // normal
        public void ModifyLastName_YesWithValidLastName_UpdatesLastName()
        {
            String dataToPassIn = "Y\nAnderson";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyLastName", FTEmployee);
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Anderson", actualLastName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyLastName_YesWithBlankLastName_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyLastName", FTEmployee);
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyLastName_YesWithInvalidLastName_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n12345";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyLastName", FTEmployee);
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        [TestMethod]
        // normal
        public void ModifyLastName_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyLastName", FTEmployee);
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyLastName_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyLastName", FTEmployee);
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jones", actualLastName);
            }
        }

        [TestMethod]
        // fault
        public void ModifyLastName_InvalidChoiceThenYesWithValidLastName_LoopsBackAndUpdatesLastName()
        {
            String dataToPassIn = "no and yes\nY\nAnderson";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyLastName", FTEmployee);
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Anderson", actualLastName);
            }
        }


        // ======================================= ModifySocialInsuranceNumber Tests =======================================
        [TestMethod]
        // normal
        public void ModifySocialInsuranceNumber_YesWithValidSIN_UpdatesSIN()
        {
            String dataToPassIn = "Y\n212098301";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(212098301, actualSIN);
            }
        }

        [TestMethod]
        // fault
        public void ModifySocialInsuranceNumber_YesWithBlankSIN_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(212398402, actualSIN);
            }
        }

        [TestMethod]
        // fault
        public void ModifySocialInsuranceNumber_YesWithInvalidSIN_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n21H098GO1";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(212398402, actualSIN);
            }
        }

        [TestMethod]
        // normal
        public void ModifySocialInsuranceNumber_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(212398402, actualSIN);
            }
        }

        [TestMethod]
        // fault
        public void ModifySocialInsuranceNumber_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(212398402, actualSIN);
            }
        }

        [TestMethod]
        // fault
        public void ModifySocialInsuranceNumber_InvalidChoiceThenYesWithValidSIN_LoopsBackAndUpdatesSIN()
        {
            String dataToPassIn = "no and yes\nY\n306098301";
            int actualSIN = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySocialInsuranceNumber", FTEmployee);
                actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(306098301, actualSIN);
            }
        }


        // ======================================= ModifyDateOfBirth Tests =======================================
        [TestMethod]
        // normal
        public void ModifyDateOfBirth_YesWithValidDOB_UpdatesDOB()
        {
            String dataToPassIn = "Y\n1991\n09\n21";
            DateTime expectedDOB = new DateTime(1991, 09, 21);
            DateTime actualDOB = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfBirth_YesWithBlankDOB_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }


        [TestMethod]
        // fault
        public void ModifyDateOfBirth_YesWithInvalidDOB_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n1900\n40\n67";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        [TestMethod]
        // normal
        public void ModifyDateOfBirth_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfBirth_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            DateTime expectedDOB = new DateTime(1990, 09, 10);
            DateTime actualDOB = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfBirth_InvalidChoiceThenYesWithValidDOB_LoopsBackAndUpdatesDOB()
        {
            String dataToPassIn = "no and yes\nY\n1992\n10\n09";
            DateTime expectedDOB = new DateTime(1992, 10, 09);
            DateTime actualDOB = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfBirth", FTEmployee);
                actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        // ======================================= ModifyEmployeeType Tests =======================================
        [TestMethod]
        // normal
        public void ModifyEmployeeType_YesWithValidType_UpdatesType()
        {
            String dataToPassIn = "Y\nPT";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("PT", actualType);
            }
        }

        [TestMethod]
        // fault
        public void ModifyEmployeeType_YesWithBlankType_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        [TestMethod]
        // fault
        public void ModifyEmployeeType_YesWithInvalidType_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\nOT";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployeeType_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        [TestMethod]
        // fault
        public void ModifyEmployeeType_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }

        [TestMethod]
        // fault
        public void ModifyEmployeeType_InvalidChoiceThenYesWithValidType_LoopsBackAndUpdatesType()
        {
            String dataToPassIn = "no and yes\nY\nSN";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployeeType", FTEmployee);
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("SN", actualType);
            }
        }

        // ======================================= ModifyDateOfHire Tests =======================================
        [TestMethod]
        // normal
        public void ModifyDateOfHire_YesWithValidDOH_UpdatesDOH()
        {
            String dataToPassIn = "Y\n2015\n03\n22";
            DateTime expectedDOH = new DateTime(2015, 03, 22);
            DateTime actualDOH = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfHire_YesWithBlankDOH_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfHire_YesWithInvalidDOH_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n1900\n40\n67";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        [TestMethod]
        // normal
        public void ModifyDateOfHire_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfHire_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            DateTime expectedDOH = new DateTime(2010, 10, 11);
            DateTime actualDOH = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfHire_InvalidChoiceThenYesWithValidDOH_LoopsBackAndUpdatesDOH()
        {
            String dataToPassIn = "no and yes\nY\n2014\n01\n29";
            DateTime expectedDOH = new DateTime(2014, 01, 29);
            DateTime actualDOH = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfHire", FTEmployee);
                actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }


        // ======================================= ModifyDateOfTermination Tests =======================================
        [TestMethod]
        // normal
        public void ModifyDateOfTermination_YesWithValidDOT_UpdatesDOT()
        {
            String dataToPassIn = "Y\n2015\n11\n30";
            DateTime expectedDOT = new DateTime(2015, 11, 30);
            DateTime actualDOT = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfTermination_YesWithBlankDOT_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            DateTime expectedDOT = new DateTime(0001, 01, 01);
            DateTime actualDOT = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfTermination_YesWithInvalidDOT_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n1900\n40\n67";
            DateTime expectedDOT = new DateTime(0001, 01, 01);
            DateTime actualDOT = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        [TestMethod]
        // normal
        public void ModifyDateOfTermination_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            DateTime expectedDOT = new DateTime(0001, 01, 01);
            DateTime actualDOT = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfTermination_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            DateTime expectedDOT = new DateTime(0001, 01, 01);
            DateTime actualDOT = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        [TestMethod]
        // fault
        public void ModifyDateOfTermination_InvalidChoiceThenYesWithValidDOT_LoopsBackAndUpdatesDOT()
        {
            String dataToPassIn = "no and yes\nY\n2015\n05\n13";
            DateTime expectedDOT = new DateTime(2015, 05, 13);
            DateTime actualDOT = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyDateOfTermination", FTEmployee);
                actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }


        // ======================================= ModifySalary Tests =======================================
        [TestMethod]
        // normal
        public void ModifySalary_YesWithValidSalary_UpdatesSalary()
        {
            String dataToPassIn = "Y\n65000";
            float actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySalary", FTEmployee);
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(65000, actualSalary);
            }
        }

        [TestMethod]
        // fault
        public void ModifySalary_YesWithBlankSalary_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            float actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySalary", FTEmployee);
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }

        [TestMethod]
        // fault
        public void ModifySalary_YesWithInvalidSalary_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n-999999";
            float actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySalary", FTEmployee);
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }

        [TestMethod]
        // normal
        public void ModifySalary_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            float actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySalary", FTEmployee);
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }


        [TestMethod]
        // fault
        public void ModifySalary_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            float actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySalary", FTEmployee);
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(50000, actualSalary);
            }
        }

        [TestMethod]
        // fault
        public void ModifySalary_InvalidChoiceThenYesWithValidSalary_LoopsBackAndUpdatesSalary()
        {
            String dataToPassIn = "no and yes\nY\n70000";
            float actualSalary = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySalary", FTEmployee);
                actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(70000, actualSalary);
            }
        }


        // ======================================= ModifyHourlyRate Tests =======================================
        [TestMethod]
        // normal
        public void ModifyHourlyRate_YesWithValidRate_UpdatesRate()
        {
            String dataToPassIn = "Y\n35.50";
            float actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(35.50, actualHourlyRate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyHourlyRate_YesWithBlankRate_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            float actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyHourlyRate_YesWithInvalidRate_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n-15";
            float actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }

        [TestMethod]
        // normal
        public void ModifyHourlyRate_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            float actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }


        [TestMethod]
        // fault
        public void ModifyHourlyRate_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            float actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(30, actualHourlyRate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyHourlyRate_InvalidChoiceThenYesWithValidRate_LoopsBackAndUpdatesRate()
        {
            String dataToPassIn = "no and yes\nY\n25.00";
            float actualHourlyRate = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyHourlyRate", PTEmployee);
                actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(25.00, actualHourlyRate);
            }
        }


        // ======================================= ModifyContractStartDate Tests =======================================
        [TestMethod]
        // normal
        public void ModifyContractStartDate_YesWithValidStartDate_UpdatesStartDate()
        {
            String dataToPassIn = "Y\n2013\n01\n16";
            DateTime expectedStartDate = new DateTime(2013, 01, 16);
            DateTime actualStartDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyContractStartDate_YesWithBlankStartDate_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyContractStartDate_YesWithInvalidStartDate_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n1600\n37\n88";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        [TestMethod]
        // normal
        public void ModifyContractStartDate_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }


        [TestMethod]
        // fault
        public void ModifyContractStartDate_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            DateTime expectedStartDate = new DateTime(2014, 02, 08);
            DateTime actualStartDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }


        [TestMethod]
        // fault
        public void ModifyContractStartDate_InvalidChoiceThenYesWithValidDate_LoopsBackAndUpdatesDate()
        {
            String dataToPassIn = "no and yes\nY\n2013\n01\n25";
            DateTime expectedStartDate = new DateTime(2013, 01, 25);
            DateTime actualStartDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStartDate", CTEmployee);
                actualStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedStartDate, actualStartDate);
            }
        }

        // ======================================= ModifyContractStopDate Tests =======================================
        [TestMethod]
        // normal
        public void ModifyContractStopDate_YesWithValidStopDate_UpdatesStopDate()
        {
            String dataToPassIn = "Y\n2013\n07\n27";
            DateTime expectedStopDate = new DateTime(2013, 07, 27);
            DateTime actualStopDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyContractStopDate_YesWithBlankStopDate_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyContractStopDate_YesWithInvalidStopDate_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n1400\n90\n36";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        [TestMethod]
        // normal
        public void ModifyContractStopDate_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyContractStopDate_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            DateTime expectedStopDate = new DateTime(2014, 09, 12);
            DateTime actualStopDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        [TestMethod]
        // fault
        public void ModifyContractStopDate_InvalidChoiceThenYesWithValidDate_LoopsBackAndUpdatesDate()
        {
            String dataToPassIn = "no and yes\nY\n2014\n08\n01";
            DateTime expectedStopDate = new DateTime(2014, 08, 01);
            DateTime actualStopDate = new DateTime(0001, 01, 01);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyContractStopDate", CTEmployee);
                actualStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedStopDate, actualStopDate);
            }
        }

        // ======================================= ModifyFixedContractAmount Tests =======================================
        [TestMethod]
        // normal
        public void ModifyFixedContractAmount_YesWithValidContractAmount_UpdatesContractAmount()
        {
            String dataToPassIn = "Y\n30000";
            float actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(30000, actualContractAmount);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFixedContractAmount_YesWithBlankContractAmount_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            float actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFixedContractAmount_YesWithInvalidContractAmount_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n-123456";
            float actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        [TestMethod]
        // normal
        public void ModifyFixedContractAmount_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            float actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFixedContractAmount_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            float actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(25000, actualContractAmount);
            }
        }

        [TestMethod]
        // fault
        public void ModifyFixedContractAmount_InvalidChoiceThenYesWithValidAmount_LoopsBackAndUpdatesAmount()
        {
            String dataToPassIn = "no and yes\nY\n15000";
            float actualContractAmount = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyFixedContractAmount", CTEmployee);
                actualContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(15000, actualContractAmount);
            }
        }


        // ======================================= ModifySeason Tests =======================================
        [TestMethod]
        // normal
        public void ModifySeason_YesWithValidSeason_UpdatesSeason()
        {
            String dataToPassIn = "Y\nFall";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySeason", SNEmployee);
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Fall", actualSeason);
            }
        }

        [TestMethod]
        // fault
        public void ModifySeason_YesWithBlankSeason_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySeason", SNEmployee);
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        [TestMethod]
        // fault
        public void ModifySeason_YesWithInvalidSeason_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\nSumminter";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySeason", SNEmployee);
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        [TestMethod]
        // normal
        public void ModifySeason_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySeason", SNEmployee);
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        [TestMethod]
        // fault
        public void ModifySeason_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySeason", SNEmployee);
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Summer", actualSeason);
            }
        }

        [TestMethod]
        // fault
        public void ModifySeason_InvalidChoiceThenYesWithValidSeason_LoopsBackAndUpdatesSeason()
        {
            String dataToPassIn = "no and yes\nY\nSpring";
            String actualSeason = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifySeason", SNEmployee);
                actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Spring", actualSeason);
            }
        }


        // ======================================= ModifyPiecePay Tests =======================================
        [TestMethod]
        // normal
        public void ModifyPiecePay_YesWithValidPiecePay_UpdatesPiecePay()
        {
            String dataToPassIn = "Y\n25";
            float actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(25, actualPiecePay);
            }
        }

        [TestMethod]
        // fault
        public void ModifyPiecePay_YesWithBlankPiecePay_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n ";
            float actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        [TestMethod]
        // fault
        public void ModifyPiecePay_YesWithInvalidPiecePay_NoUpdateOccurs()
        {
            String dataToPassIn = "Y\n-10";
            float actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        [TestMethod]
        // normal
        public void ModifyPiecePay_No_NoUpdateOccurs()
        {
            String dataToPassIn = "N\n";
            float actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        [TestMethod]
        // fault
        public void ModifyPiecePay_InvalidChoiceThenNo_LoopsBackAndNoUpdateOccurs()
        {
            String dataToPassIn = "no and yes\nN";
            float actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(20, actualPiecePay);
            }
        }

        [TestMethod]
        // fault
        public void ModifyPiecePay_InvalidChoiceThenYesWithValidPay_LoopsBackAndUpdatesPay()
        {
            String dataToPassIn = "no and yes\nY\n30";
            float actualPiecePay = 0;
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyPiecePay", SNEmployee);
                actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(30, actualPiecePay);
            }
        }

        // ======================================= ModifyEmployee Tests =======================================
        // more like integration of all the modify methods
        [TestMethod]
        // normal
        public void ModifyEmployee_ValidFirstName_ModifiesEmployeeFirstName()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            String actualFirstName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                actualFirstName = FTEmployee.GetFirstName();
                Assert.AreEqual("Samantha", actualFirstName);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidLastName_ModifiesEmployeeLastName()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            String actualLastName = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                actualLastName = FTEmployee.GetLastName();
                Assert.AreEqual("Jamieson", actualLastName);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidSIN_ModifiesEmployeeSIN()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                int actualSIN = FTEmployee.GetSocialInsuranceNumber();
                Assert.AreEqual(432098933, actualSIN);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidDOB_ModifiesEmployeeDOB()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            DateTime expectedDOB = new DateTime(1990, 09, 20);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                DateTime actualDOB = FTEmployee.GetDateOfBirth();
                Assert.AreEqual(expectedDOB, actualDOB);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidType_ModifiesEmployeeType()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            String actualType = "";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                actualType = FTEmployee.GetEmployeeType();
                Assert.AreEqual("FT", actualType);
            }
        }


        // Fulltime Employee
        [TestMethod]
        // normal
        public void ModifyEmployee_ValidDateOfHire_ModifiesFulltimeEmployeeDateOfHire()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            DateTime expectedDOH = new DateTime(2012, 10, 11);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                DateTime actualDOH = FTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }


        [TestMethod]
        // normal
        public void ModifyEmployee_ValidDateOfTermination_ModifiesFulltimeEmployeeDateOfTermination()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            DateTime expectedDOT = new DateTime(2012, 12, 02);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                DateTime actualDOT = FTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidSalary_ModifiesEmployeeSalary()
        {
            String dataToPassIn = "Y\nSamantha\nY\nJamieson\nY\n432098933\nY\n1990\n09\n20\nN\nY\n2012\n10\n11\nY\n2012\n12\n02\nY\n70000\n";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", FTEmployee);
                float actualSalary = FTEmployee.GetSalary();
                Assert.AreEqual(70000, actualSalary);
            }
        }



        // Parttime
        [TestMethod]
        // normal
        public void ModifyEmployee_ValidDateOfHire_ModifiesParttimeEmployeeDateOfHire()
        {
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n490398988\nY\n1990\n09\n09\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n";
            DateTime expectedDOH = new DateTime(2011, 10, 11);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", PTEmployee);
                DateTime actualDOH = PTEmployee.GetDateOfHire();
                Assert.AreEqual(expectedDOH, actualDOH);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidDateOfTermination_ModifiesParttimeEmployeeDateOfTermination()
        {
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n490398988\nY\n1990\n09\n09\nN\nY\n2011\n10\n11\nY\n2012\n12\n02\nY\n35\n";
            DateTime expectedDOT = new DateTime(2012, 12, 02);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", PTEmployee);
                DateTime actualDOT = PTEmployee.GetDateOfTermination();
                Assert.AreEqual(expectedDOT, actualDOT);
            }
        }


        [TestMethod]
        // normal
        public void ModifyEmployee_ValidHourlyRate_ModifiesEmployeeHourlyRate()
        {
            String dataToPassIn = "Y\nMarcus\nY\nSmithy\nY\n490398988\nY\n1990\n09\n09\nN\nY\n2010\n10\n11\nY\n2012\n12\n02\nY\n35\n";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", PTEmployee);
                float actualHourlyRate = PTEmployee.GetHourlyRate();
                Assert.AreEqual(35, actualHourlyRate);
            }
        }




     
        [TestMethod]
        // normal
        public void ModifyEmployee_ValidContractStartDate_ModifiesEmployeeContractStartDate()
        {
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n";
            DateTime expectedContractStartDate = new DateTime(2014, 03, 08);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", CTEmployee);
                DateTime actualContractStartDate = CTEmployee.GetContractStartDate();
                Assert.AreEqual(expectedContractStartDate, actualContractStartDate);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidContractStopDate_ModifiesEmployeeContractStopDate()
        {
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n";
            DateTime expectedContractStopDate = new DateTime(2014, 10, 12);
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", CTEmployee);
                DateTime actualContractStopDate = CTEmployee.GetContractStopDate();
                Assert.AreEqual(expectedContractStopDate, actualContractStopDate);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidFixedContractAmount_ModifiesEmployeeFixedContractAmount()
        {
            String dataToPassIn = "Y\nAnnie\nY\nMillerton\nY\n892398400\nY\n1989\n08\n02\nN\nY\n2014\n03\n08\nY\n2014\n10\n12\nY\n10000\n";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", CTEmployee);
                float actualFixedContractAmount = CTEmployee.GetFixedContractAmount();
                Assert.AreEqual(10000, actualFixedContractAmount);
            }
        }







        [TestMethod]
        // normal
        public void ModifyEmployee_ValidSeason_ModifiesEmployeeSeason()
        {
            String dataToPassIn = "Y\nJacob\nY\nWilliams\nY\n432098988\nY\n1990\n09\n20\nN\nY\nFall\nY\n15000";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", SNEmployee);
                String actualSeason = SNEmployee.GetSeason();
                Assert.AreEqual("Fall", actualSeason);
            }
        }

        [TestMethod]
        // normal
        public void ModifyEmployee_ValidPiecePay_ModifiesEmployeePiecePay()
        {
            String dataToPassIn = "Y\nJacob\nY\nWilliams\nY\n432098988\nY\n1990\n09\n20\nN\nY\nFall\nY\n15000";
            var privateObject = new PrivateObject(employeeRepo);
            using (var input = new StringReader(dataToPassIn))
            {
                Console.SetIn(input);
                privateObject.Invoke("ModifyEmployee", SNEmployee);
                float actualPiecePay = SNEmployee.GetPiecePay();
                Assert.AreEqual(15000, actualPiecePay);
            }
        }
    }
}
