using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    [TestClass]
    public class FullTimeEmployeeTests
    {
        [TestMethod]
        [TestCategory("FulltimeEmployee Base Constructor")]
        //[ExpectedException(typeof(FailedConstructorException))]
        public void BaseConstructorTest()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
        }

        /*
         * Constructor with names Tests
        */

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc'Davies");
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "LeRoy-Davies");
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc/Davies");
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc Davies");
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon2", "Davies");
        }

        /*
         * Constructor with all parameters Tests
        */

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime();
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 20000);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc'Davies", 123456789, DOB, DOH, DOT, 200000);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime();
            DateTime DOH = new DateTime();
            DateTime DOT = new DateTime();
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSIN()
        {
            DateTime DOB = new DateTime();
            DateTime DOH = new DateTime();
            DateTime DOT = new DateTime();
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 1234756789, DOB, DOH, DOT, 230000);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOHBeforeDOB()
        {
            DateTime DOB = new DateTime(2003, 12, 12);
            DateTime DOH = new DateTime(2001, 01, 29);
            DateTime DOT = new DateTime(2006, 05, 21);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOTBoforeDOH()
        {
            DateTime DOB = new DateTime(1993, 11, 14);
            DateTime DOH = new DateTime(2012, 10, 19);
            DateTime DOT = new DateTime(2010, 07, 29);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
        }

        /*
         * Details Tests
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Details")]
        public void DetailsTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            String details = employee.Details();
            Assert.IsTrue(details == "Employee Type: FullTime\nName: Brandon Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1954-08-20\nDate of Hire: 1994-09-03\nDate of Termination: 2014-12-23\nSalary: 230000");
        }

        /*
         * ToString Tests
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee ToString")]
        public void ToStringTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            String toString = employee.ToString();
            Assert.IsTrue(toString == "FT|Brandon|Davies|123456789|1954-8-20|1994-09-03|2014-12-23|230000");
        }

        /*
         * SetDateOfBirth Tests
        */

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthDateTestValidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            DateTime date = new DateTime(1993, 05, 15);
            bool retVal = employee.SetDateOfBirth(date);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthDateTestInvalidDOBafterDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(1998, 05, 15);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            DateTime date = new DateTime(1995, 04, 03);
            bool retVal = employee.SetDateOfBirth(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestValidString()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("1993-04-24");
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestInvalidFormat()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("19930424");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("1993-13-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestInvalidFuture()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("2017-11-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestInvalidDOBafterDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime();
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfBirth("2001-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestInvalidLetter()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("1993-s2-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestValid()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth(1993, 04, 24);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth(1993, 04, 31);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestInvalidFutureDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth(2017, 04, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestInvalidDOBafterDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime();
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfBirth(2001,12,24);
            Assert.IsFalse(retVal);
        }

        /*
         * SetDateOfHire Tests
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireDateTestValidDate()
        {
            DateTime date = new DateTime(2012, 04, 23);
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire(date);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireDateTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            DateTime date = new DateTime(2012, 04, 23);
            bool retVal = employee.SetDateOfHire(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1985, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            DateTime date = new DateTime(1980, 04, 23);
            bool retVal = employee.SetDateOfHire(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestValidString()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-04-24");
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidFormat()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("19930424");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-13-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidFuture()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("2017-11-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfHire("2001-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireDateTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1985, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfHire("1980-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidLetter()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-s2-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestValid()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire(1993, 04, 24);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire(1993, 04, 31);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidFutureDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire(2017, 04, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfHire(2001, 12, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1984, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfHire(1980, 12, 24);
            Assert.IsFalse(retVal);
        }

        /*
         * SetDateOfTermination Tests
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationDateTestValidDate()
        {
            DateTime DOB = new DateTime(1984, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            DateTime date = new DateTime(2012, 04, 23);
            bool retVal = employee.SetDateOfTermination(date);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationDateTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            DateTime date = new DateTime(1992, 04, 23);
            bool retVal = employee.SetDateOfTermination(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationDateTestInvalidDOTnoDOH()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
            DateTime date = new DateTime(1992, 04, 23);
            bool retVal = employee.SetDateOfTermination(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestValidString()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfTermination("1997-04-24");
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidFormat()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfTermination("19930424");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfTermination("1993-13-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidFuture()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfTermination("2017-11-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfTermination("1993-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidDOTnoDOH()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetDateOfTermination("2001-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidLetter()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfTermination("1993-s2-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfTermination(1997, 04, 24);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfTermination(1993, 04, 31);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidFutureDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfTermination(2017, 04, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
            bool retVal = employee.SetDateOfTermination(1992, 12, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidDOTnoDOH()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetDateOfTermination(2001, 12, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetSalary")]
        public void SetSalaryValid()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetSalary(20000);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("FulltimeEmployee SetSalary")]
        public void SetSalaryInvalidNegitive()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetSalary(-20000);
            Assert.IsFalse(retVal);
        }
    }
}
