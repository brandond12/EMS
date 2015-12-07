using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    [TestClass]
    public class ParttimeEmployeeTests
    {
        /*
         * Constructor with names Tests
        */

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies");
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Mc'Davies");
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "LeRoy-Davies");
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Mc/Davies");
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Mc Davies");
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon2", "Davies");
        }

        /*
         * Constructor with all parameters Tests
        */

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime();
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Mc'Davies", 123456789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1830, 07, 29);
            DateTime DOH = new DateTime(2013, 05, 12);
            DateTime DOT = new DateTime();
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSIN()
        {
            DateTime DOB = new DateTime(1984, 02, 15);
            DateTime DOH = new DateTime(1986, 02, 15);
            DateTime DOT = new DateTime();
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 1234756789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOHBeforeDOB()
        {
            DateTime DOB = new DateTime(2003, 12, 12);
            DateTime DOH = new DateTime(2001, 02, 27);
            DateTime DOT = new DateTime(2002, 05, 21);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOTBoforeDOH()
        {
            DateTime DOB = new DateTime(1993, 11, 14);
            DateTime DOH = new DateTime(2012, 10, 19);
            DateTime DOT = new DateTime(2010, 07, 29);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidNoDOH()
        {
            DateTime DOB = new DateTime(1993, 11, 14);
            DateTime DOH = new DateTime();
            DateTime DOT = new DateTime();
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 180000);
        }

        /*
         * Details Tests
        */
        [TestMethod]
        [TestCategory("ParttimeEmployee Details")]
        public void DetailsTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            String details = employee.Details();
            Assert.IsTrue(details == "Employee Type: ParttimeEmployee\nName: Brandon Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1954-08-20\nDate of Hire: 1994-09-03\nDate of Termionation2014-12-23\nHourly Rate: 18");
        }

        /*
         * ToString Tests
        */
        [TestMethod]
        [TestCategory("ParttimeEmployee ToString")]
        public void ToStringTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            String toString = employee.ToString();
            Assert.IsTrue(toString == "|PT|Brandon|Davies|123456789|1954-08-20|1994-09-03|2014-12-23|18|");
        }

        /*
         * SetDateOfHire Tests
        */
        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireDateTestValidDate()
        {
            DateTime date = new DateTime(2012, 04, 23);
            ParttimeEmployee employee = new ParttimeEmployee();
            bool retVal = employee.SetDateOfHire(date);
            Assert.IsTrue(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireDateTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(2012, 04, 23);
            bool retVal = employee.SetDateOfHire(date);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1985, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(1980, 04, 23);
            bool retVal = employee.SetDateOfHire(date);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestValidString()
        {
            ParttimeEmployee employee = new ParttimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-04-24");
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidFormat()
        {
            ParttimeEmployee employee = new ParttimeEmployee();
            bool retVal = employee.SetDateOfHire("19930424");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidDate()
        {
            ParttimeEmployee employee = new ParttimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-13-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfHire("2001-12-24");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireDateTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1985, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfHire("1980-12-24");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidLetter()
        {
            ParttimeEmployee employee = new ParttimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-s2-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestValid()
        {
            ParttimeEmployee employee = new ParttimeEmployee();
            bool retVal = employee.SetDateOfHire(1993, 04, 24);
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidDate()
        {
            ParttimeEmployee employee = new ParttimeEmployee();
            bool retVal = employee.SetDateOfHire(1993, 04, 31);
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfHire(2001, 12, 24);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1984, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfHire(1980, 12, 24);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /*
         * SetDateOfTermination Tests
        */
        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationDateTestValidDate()
        {
            DateTime DOB = new DateTime(1984, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(2012, 04, 23);
            bool retVal = employee.SetDateOfTermination(date);
            Assert.IsTrue(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationDateTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(1992, 04, 23);
            bool retVal = employee.SetDateOfTermination(date);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationDateTestInvalidDOTnoDOH()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies");
            DateTime date = new DateTime(1992, 04, 23);
            bool retVal = employee.SetDateOfTermination(date);
            Assert.IsFalse(retVal);

            date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestValidString()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfTermination("1999-04-24");
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1999, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidFormat()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfTermination("19930424");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidDate()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);

            bool retVal = employee.SetDateOfTermination("1993-13-24");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfTermination("1991-12-24");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidDOTnoDOH()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetDateOfTermination("2001-12-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidLetter()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);

            bool retVal = employee.SetDateOfTermination("1993-s2-24");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfTermination(1999, 04, 24);
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1999, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidDate()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);

            bool retVal = employee.SetDateOfTermination(1993, 04, 31);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetDateOfTermination(1991, 12, 24);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidDOTnoDOH()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetDateOfTermination(2001, 12, 24);
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetSalary")]
        public void SetSalaryValid()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetHourlyRate(18);
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetHourlyRate(), 18);
        }

        [TestMethod]
        [TestCategory("ParttimeEmployee SetSalary")]
        public void SetSalaryInvalidNegitive()
        {
            ParttimeEmployee employee = new ParttimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetHourlyRate(-18);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetHourlyRate(), 0);
        }
    }
}