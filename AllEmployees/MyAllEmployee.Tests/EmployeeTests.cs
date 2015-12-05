using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        [TestCategory("Employee Base Constructor")]
        public void BaseConstructorTest()
        {
            Employee employee = new Employee();
        }

        /*
         * Constructor with names Tests
        */

        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        
        public void ConstructorWithNamesTestValid1()
        {
            Employee employee = new Employee("Brandon", "Davies");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            Employee employee = new Employee("Brandon", "Mc-Davies");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            Employee employee = new Employee("Brandon", "Mc'Davies");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            Employee employee = new Employee("Brandon", "Mc/Davies");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            Employee employee = new Employee("Brandon", "Mc Davies");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            Employee employee = new Employee("Brandon2", "Davies");
        }

        /*
         * Constructor with all parameters Tests
        */

        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime();
            Employee employee = new Employee("Brandon", "Davies", 123456789, DOB, "FT");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            Employee employee = new Employee("Brandon", "Mc'Davies", 123456789, DOB, "PT");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1943, 12, 1);
            Employee employee = new Employee("'Brandon", "Mc-Davies", 999999999, DOB, "SN");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSIN()
        {
            DateTime DOB = new DateTime(1943, 12, 1);
            Employee employee = new Employee("Brandon", "McDavies", 99999999, DOB, "SN");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidEmployeeType()
        {
            DateTime DOB = new DateTime(1943, 12, 1);
            Employee employee = new Employee("Brandon", "McDavies", 999999999, DOB, "N");
        }

        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidFirstName()
        {
            DateTime DOB = new DateTime(2013, 12, 1);
            Employee employee = new Employee(" Brandon", "McDavies", 999999999, DOB, "CT");
        }

        /*
         * SetFirstName Tests
        */

        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestValid1()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetFirstName(), "Brandon");
        }

        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestValid2()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc'Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetFirstName(), "Mc'Brandon");
        }

        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestValid3()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc-Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetFirstName(), "Mc-Brandon");
        }

        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestInvalidSpace()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetFirstName(), "");
        }

        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestInvalidNumber()
        {
            Employee employee = new Employee("Brandon", "Davies");
            bool retVal = employee.SetFirstName("Brandon23");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetFirstName(), "Brandon");
        }

        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestInvalidSlash()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc/Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetFirstName(), "");
        }

        /*
         * SetLastName Tests
        */

        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestValid1()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetLastName(), "Brandon");
        }

        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestValid2()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc'Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetLastName(), "Mc'Brandon");
        }

        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestValid3()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc-Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetLastName(), "Mc-Brandon");
        }

        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestInvalidSpace()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetLastName(), "");
        }

        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestInvalidNumber()
        {
            Employee employee = new Employee("Brandon", "Davies");
            bool retVal = employee.SetLastName("Brandon23");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetLastName(), "Davies");
        }

        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestInvalidSlash()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc/Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetLastName(), "");
        }

        /*
         * SetSocialInsuranceNumber Tests
        */

        [TestMethod]
        [TestCategory("Employee SetSocialInsuranceNumber")]
        public void SetSocialInsuranceNumberTestValid()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetSocialInsuranceNumber(123456789);
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetSocialInsuranceNumber(), 123456789);
        }

        [TestMethod]
        [TestCategory("Employee SetSocialInsuranceNumber")]
        public void SetSocialInsuranceNumberTestInvalidToShort()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetSocialInsuranceNumber(12345678);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetSocialInsuranceNumber(), 0);
        }

        [TestMethod]
        [TestCategory("Employee SetSocialInsuranceNumber")]
        public void SetSocialInsuranceNumberTestInvalidNegitive()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetSocialInsuranceNumber(-12345678);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetSocialInsuranceNumber(), 0);
        }

        [TestMethod]
        [TestCategory("Employee SetSocialInsuranceNumber")]
        public void SetSocialInsuranceNumberTestInvalidTooLarge()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetSocialInsuranceNumber(1112345678);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetSocialInsuranceNumber(), 0);
        }

        /*
         * SetEmployeeType Tests
        */

        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidContract()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("CT");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "CT");
        }

        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidFullTime()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("FT");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "FT");
        }

        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidPartTime()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("PT");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "PT");
        }

        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidSeasonal()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("SN");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "SN");
        }

        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidNoType()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "");
        }

        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestInvalid()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("AB");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "");
        }
    }
}
