/*
* FILE   : EmployeeTests.cs
* PROJECT  : INFO 2180 -Software Quality 1 - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-12-08
* DESCRIPTION : This is the header for the employee tests. Here we test the Employee class.
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        /**
        * \brief This unit test will check if either name contains anything other than a letter, apostrophe, dash. It will throw an exception if wrong.
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithNamesTestValid1()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Davies"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * There is no exception. 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            Employee employee = new Employee("Brandon", "Davies");
        }
        /**
        * \brief This unit test will check if either name contains anything other than a letter, apostrophe, dash. It will throw an exception if wrong.
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithNamesTestValid2()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Mc'Davies"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * There is no exception. 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            Employee employee = new Employee("Brandon", "Mc-Davies");
        }

        /**
        * \brief This unit test will check if either name contains anything other than a letter, apostrophe, dash. It will throw an exception if wrong.
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithNamesTestValid3()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "LeRoy-Davies"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * There is no exception. 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            Employee employee = new Employee("Brandon", "Mc'Davies");
        }

        /**
        * \brief This unit test will check if the constructor will fail and if the string is invalid because it contains a slash
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithNamesTestInvalidSlash()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Mc/Davies"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that it will throw an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            Employee employee = new Employee("Brandon", "Mc/Davies");
        }

        /**
        * \brief This unit test will check if the constructor will fail and if the string is invalid because it contains a space
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithNamesTestInvalidSpace()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Mc Davies"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that it will throw an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            Employee employee = new Employee("Brandon", "Mc Davies");
        }

        /**
        * \brief This unit test will check if the constructor will fail and if the string is invalid because it contains a number
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithNamesTestInvalidNumber()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon2", "Davies"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that it will throw an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            Employee employee = new Employee("Brandon2", "Davies");
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all valid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestValid1()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(2003, 02, 20);
        * "Brandon", "Davies", 123456789, DOB, "FT"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime(2003, 02, 20);
            Employee employee = new Employee("Brandon", "Davies", 123456789, DOB, "FT");
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all valid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestValid2()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 04, 24);
        * "Brandon", "Mc'Davies", 123456789, DOB, "PT"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            Employee employee = new Employee("Brandon", "Mc'Davies", 123456789, DOB, "PT");
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all valid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestValid3()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1943, 12, 1);
        * "Brandon", "Davies", 999999999, DOB, "SN"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1943, 12, 1);
            Employee employee = new Employee("'Brandon", "Mc-Davies", 999999999, DOB, "SN");
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestInvalidSIN()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1943, 12, 1);
        * "Brandon", "Davies",  99999999, DOB, "SN"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSIN()
        {
            DateTime DOB = new DateTime(1943, 12, 1);
            Employee employee = new Employee("Brandon", "McDavies", 99999999, DOB, "SN");
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestInvalidEmployeeType()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1943, 12, 1);
        * "Brandon", "McDavies",  99999999, DOB, "N"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidEmployeeType()
        {
            DateTime DOB = new DateTime(1943, 12, 1);
            Employee employee = new Employee("Brandon", "McDavies", 999999999, DOB, "N");
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestInvalidFirstName()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(2013, 12, 1);
        * "Brandon", "McDavies",  99999999, DOB, "CT"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("Employee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidFirstName()
        {
            DateTime DOB = new DateTime(2013, 12, 1);
            Employee employee = new Employee(" Brandon", "McDavies", 999999999, DOB, "CT");
        }

        /**
        * \brief This unit test will set the first name to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetFirstNameTestValid1()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
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

        /**
        * \brief This unit test will set the first name to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetFirstNameTestValid2()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc'Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestValid2()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc'Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetFirstName(), "Mc'Brandon");
        }

        /**
        * \brief This unit test will set the first name to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetFirstNameTestValid3()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc-Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestValid3()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc-Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetFirstName(), "Mc-Brandon");
        }

        /**
        * \brief This unit test will set the first name to an invalid value
        * 
        * \ <b> Name of Method</b>
        * SetFirstNameTestInvalidSpace()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestInvalidSpace()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetFirstName(), "");
        }

        /**
        * \brief This unit test will set the first name to an invalid value
        * 
        * \ <b> Name of Method</b>
        * SetFirstNameTestInvalidNumber()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Davies", "Brandon23"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestInvalidNumber()
        {
            Employee employee = new Employee("Brandon", "Davies");
            bool retVal = employee.SetFirstName("Brandon23");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetFirstName(), "Brandon");
        }

        /**
        * \brief This unit test will set the first name to an invalid value
        * 
        * \ <b> Name of Method</b>
        * SetFirstNameTestInvalidSlash()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc/Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetFirstName")]
        public void SetFirstNameTestInvalidSlash()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetFirstName("Mc/Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetFirstName(), "");
        }

        /**
        * \brief This unit test will set the last name to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetLastNameTestValid1()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
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

        /**
        * \brief This unit test will set the last name to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetLastNameTestValid2()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc'Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestValid2()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc'Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetLastName(), "Mc'Brandon");
        }

        /**
        * \brief This unit test will set the last name to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetLastNameTestValid3()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc-Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestValid3()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc-Brandon");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetLastName(), "Mc-Brandon");
        }

        /**
        * \brief This unit test will set the last name to an invalid value
        * 
        * \ <b> Name of Method</b>
        * SetLastNameTestInvalidSpace()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestInvalidSpace()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetLastName(), "");
        }

        /**
        * \brief This unit test will set the last name to an invalid value
        * 
        * \ <b> Name of Method</b>
        * SetLastNameTestInvalidNumber()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Davies", "Brandon23"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestInvalidNumber()
        {
            Employee employee = new Employee("Brandon", "Davies");
            bool retVal = employee.SetLastName("Brandon23");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetLastName(), "Davies");
        }

        /**
        * \brief This unit test will set the last name to an invalid value
        * 
        * \ <b> Name of Method</b>
        * SetLastNameTestInvalidSlash()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Mc/Brandon"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetLastName")]
        public void SetLastNameTestInvalidSlash()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetLastName("Mc/Brandon");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetLastName(), "");
        }

        /**
        * \brief This unit test will set the SIN number to a valid number
        * \ <b> Name of Method</b>
        * SetSocialInsuranceNumberTestValid()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * 123456789
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
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

        /**
        * \brief This unit test will set the SIN number to an invalid number
        * \ <b> Name of Method</b>
        * SetSocialInsuranceNumberTestInvalidToShort()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * 12345678
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetSocialInsuranceNumber")]
        public void SetSocialInsuranceNumberTestInvalidToShort()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetSocialInsuranceNumber(12345678);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetSocialInsuranceNumber(), 0);
        }

        /**
        * \brief This unit test will set the SIN number to an invalid number
        * \ <b> Name of Method</b>
        * SetSocialInsuranceNumberTestInvalidNegitive()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * -12345678
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetSocialInsuranceNumber")]
        public void SetSocialInsuranceNumberTestInvalidNegitive()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetSocialInsuranceNumber(-12345678);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetSocialInsuranceNumber(), 0);
        }

        /**
        * \brief This unit test will set the SIN number to an invalid number
        * \ <b> Name of Method</b>
        * SetSocialInsuranceNumberTestInvalidTooLarge()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * -12345678
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("Employee SetSocialInsuranceNumber")]
        public void SetSocialInsuranceNumberTestInvalidTooLarge()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetSocialInsuranceNumber(1112345678);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetSocialInsuranceNumber(), 0);
        }

        /**
        * \brief This unit test will set the employee type to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetEmployeeTypeTestValidContract()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "CT"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
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

        /**
        * \brief This unit test will set the employee type to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetEmployeeTypeTestValidFullTime()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "FT"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidFullTime()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("FT");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "FT");
        }

        /**
        * \brief This unit test will set the employee type to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetEmployeeTypeTestValidPartTime()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "PT"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidPartTime()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("PT");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "PT");
        }

        /**
        * \brief This unit test will set the employee type to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetEmployeeTypeTestValidSeasonal()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "SN"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidSeasonal()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("SN");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "SN");
        }

        /**
        * \brief This unit test will set the employee type to a valid value
        * 
        * \ <b> Name of Method</b>
        * SetEmployeeTypeTestValidNoType()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * ""
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("Employee SetEmployeeType")]
        public void SetEmployeeTypeTestValidNoType()
        {
            Employee employee = new Employee();
            bool retVal = employee.SetEmployeeType("");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetEmployeeType(), "");
        }

        /**
        * \brief This unit test will set the employee type to an invalid value
        * \ <b> Name of Method</b>
        * SetEmployeeTypeTestInvalid()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "AB"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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
