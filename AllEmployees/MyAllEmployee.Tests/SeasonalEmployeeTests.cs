using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    [TestClass]
    public class SeasonalEmployeeTests
    {
        [TestMethod]
        [TestCategory("SeasonalEmployee Base Constructor")]
        public void BaseConstructorTest()
        {
            SeasonalEmployee employee = new SeasonalEmployee();
        }

        /*
         * Constructor with names Tests
        */

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies");
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "LeRoy-Davies");
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc/Davies");
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc Davies");
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon2", "Davies");
        }

        /*
         * Constructor with all parameters Tests
        */

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB ,"Summer", 10);
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime();
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies", 123456789, DOB, "Winter", 15);
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Fall", 0);
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSIN()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 1123456789, DOB, "Fall", 10);
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidPiecePay()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Fall", -12);
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSeason()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "October", 13);
        }

        /*
         * Details Tests
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Details")]
        public void DetailsTestValid()
        {
            DateTime DOB = new DateTime(1993-07-12);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies", 123456789, DOB, "Winter", 15);
            String details = employee.Details();
            Assert.IsTrue(details == "Employee Type: Contract\nName: Brandon Mc'Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1993-07-12\nSeason: Winter\nPrice per Piece: 15");
        }

        /*
         * ToString Tests
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee ToString")]
        public void ToStringTestValid()
        {
            DateTime DOB = new DateTime(1993-07-12);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies", 123456789, DOB, "Winter", 15);
            String toString = employee.ToString();
            Assert.IsTrue(toString == "SN|Brandon|Mc'Davies|123456789|1993-07-12|Winter|15");
        }

        /*
         * SetSalary Tests
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee SetSalary")]
        public void SetPiecePayValid()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            bool retVal = employee.SetPiecePay(10);
            Assert.IsTrue(retVal);
        }

        [TestMethod]
        [TestCategory("SeasonalEmployee SetSalary")]
        public void SetPiecePayInvalidNegitive()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            bool retVal = employee.SetPiecePay(-10);
            Assert.IsFalse(retVal);
        }
    }
}