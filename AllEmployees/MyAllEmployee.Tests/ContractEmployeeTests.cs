using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    [TestClass]
    public class ContractEmployeeTests
    {
        [TestMethod]
        [TestCategory("ContractEmployee Base Constructor")]
        public void BaseConstructorTest()
        {
            ContractEmployee employee = new ContractEmployee();
        }

        /*
         * Constructor with names Tests
        */

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc'Davies");
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "LeRoy-Davies");
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc/Davies");
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc Davies");
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            ContractEmployee employee = new ContractEmployee("Brandon2", "Davies");
        }

        /*
         * Constructor with all parameters Tests
        */

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc'Davies", 543456789, DOB, DOH, DOT, 21);
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 34);
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidBN()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 54347589, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOHBeforeDOB()
        {
            DateTime DOB = new DateTime(2003, 12, 12);
            DateTime DOH = new DateTime(2001, 02, 27);
            DateTime DOT = new DateTime(2002, 05, 21);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 033456789, DOB, DOH, DOT, 18);
        }

        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOTBoforeDOH()
        {
            DateTime DOB = new DateTime(1993, 11, 14);
            DateTime DOH = new DateTime(2012, 10, 19);
            DateTime DOT = new DateTime(2010, 07, 29);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18);
        }

        /*
         * Details Tests
        */
        [TestMethod]
        [TestCategory("ContractEmployee Details")]
        public void DetailsTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            String details = employee.Details();
            Assert.IsTrue(details == "Employee Type: Contract\nName: Brandon Davies\nBuisness Number: 54345 6789\nBuisness Start Date: 1954-08-20\nContract Start Date: 1994-09-03\nContract Stop Date: 2014-12-23\nFixed Contract Amount: 18");
        }

        /*
         * ToString Tests
        */
        [TestMethod]
        [TestCategory("ContractEmployee ToString")]
        public void ToStringTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            String toString = employee.ToString();
            Assert.IsTrue(toString == "CT|Brandon|Davies|543456789|1954-8-20|2014-12-23|1994-09-03|18");
        }

        /*
         * SetContractStartDate Tests
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateDateTestValidDate()
        {
            DateTime date = new DateTime(2012, 04, 23);
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate(date);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateDateTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(2012, 04, 23);
            bool retVal = employee.SetContractStartDate(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1985, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 853456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(1980, 04, 23);
            bool retVal = employee.SetContractStartDate(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestValidString()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("1993-04-24");
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestInvalidFormat()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("19930424");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestInvalidDate()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("1993-13-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStartDate("2001-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateDateTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1985, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 853456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStartDate("1980-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestInvalidLetter()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("1993-s2-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestValid()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate(1993, 04, 24);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestInvalidDate()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate(1993, 04, 31);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestInvalidDOHafterDOT()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStartDate(2001, 12, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestInvalidDOHbeforeDOB()
        {
            DateTime DOB = new DateTime(1984, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 843456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStartDate(1980, 12, 24);
            Assert.IsFalse(retVal);
        }

        /*
         * SetContractStopDate Tests
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateDateTestValidDate()
        {
            DateTime DOB = new DateTime(1984, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 843456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(2012, 04, 23);
            bool retVal = employee.SetContractStopDate(date);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateDateTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            DateTime date = new DateTime(1992, 04, 23);
            bool retVal = employee.SetContractStopDate(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateDateTestInvalidDOTnoDOH()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
            DateTime date = new DateTime(1992, 04, 23);
            bool retVal = employee.SetContractStopDate(date);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestValidString()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStopDate("1995-04-24");
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestInvalidFormat()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStopDate("19930424");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestInvalidDate()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStopDate("1993-13-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestInvalidFuture()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStopDate("2017-11-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStopDate("1992-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestInvalidDOTnoDOH()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
            bool retVal = employee.SetContractStopDate("2001-12-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateIntsTestInvalidLetter()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStopDate("1993-s2-24");
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateIntsTestValid()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStopDate(1995, 04, 24);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateIntsTestInvalidDate()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStopDate(1997, 04, 31);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateIntsTestInvalidDOTbeforeDOH()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
            bool retVal = employee.SetContractStopDate(1991, 12, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateIntsTestInvalidDOTnoDOH()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
            bool retVal = employee.SetContractStopDate(2001, 12, 24);
            Assert.IsFalse(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetFixedContractAmount")]
        public void SetFixedContractAmountValid()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
            bool retVal = employee.SetFixedContractAmount(18);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("ContractEmployee SetFixedContractAmount")]
        public void SetFixedContractAmountInvalidNegitive()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
            bool retVal = employee.SetFixedContractAmount(-18);
            Assert.IsFalse(retVal);
        }
    }
}