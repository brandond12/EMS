/*
* FILE   : FullTimeEmployeeTests.cs
* PROJECT  : INFO 2180 -Software Quality 1 - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-12-07
* DESCRIPTION : This is the header for the full time employee tests. Here we test the FullTime Employee class.
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    /// \class FullTimeEmployeeTests
    ///
    /// \brief <b>Brief Description</b> 
    /// This class is used to test the FulltimeEmployee methods in the AllEmployee class. The methods tested 
    /// include the constructors, Details, SetDateOfBirth (all 3 overloaded methods), SetDateofHire (all 3 overloaded methods), SetDateofTermination(all 3 overloaded methods), SetSalary and ToString.
    [TestClass]
    public class FullTimeEmployeeTests
    {

        /**
        * \brief This unit test will check if either name contains anything other than a letter, apostrophe, dash. It will throw an exception if wrong.
        * 
        * \<b>Name of Method/b>
        * ConstructorWithNamesTestValid1()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * There is no exception. 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
        }

        /**
        * \brief This unit test will check if either name contains anything other than a letter, apostrophe, dash. It will throw an exception if wrong.
        * 
        * \<b>Name of Method/b>
        * ConstructorWithNamesTestValid2()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Mc'Davies"
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * There is no exception. 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc'Davies");
        }

        /**
        * \brief This unit test will check if either name contains anything other than a letter, apostrophe, dash. It will throw an exception if wrong.
        * 
        * \<b>Name of Method/b>
        * ConstructorWithNamesTestValid3()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "LeRoy-Davies"
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * There is no exception. 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "LeRoy-Davies");
        }

        /**
        * \brief This unit test will check if the constructor will fail and if the string is invalid because it contains a slash
        * 
        * \<b>Name of Method/b>
        * ConstructorWithNamesTestInvalidSlash()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Mc/Davies"
        * 
        * \<b>Expected Result</b>
        * The expected result is that it will throw an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc/Davies");
        }

        /**
        * \brief This unit test will check if the constructor will fail and if the string is invalid because it contains a space
        * 
        * \<b>Name of Method/b>
        * ConstructorWithNamesTestInvalidSpace()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Mc Davies"
        * 
        * \<b>Expected Result</b>
        * The expected result is that it will throw an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc Davies");
        }

        /**
        * \brief This unit test will check if the constructor will fail and if the string is invalid because it contains a number
        * 
        * \<b>Name of Method/b>
        * ConstructorWithNamesTestInvalidNumber()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon2", "Davies"
        * 
        * \<b>Expected Result</b>
        * The expected result is that it will throw an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon2", "Davies");
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all valid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestValid1()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 04, 24);
        * DateTime DOH = new DateTime(2000, 12, 12);
        * DateTime DOT = new DateTime();
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 20000
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * An exception is not thrown 
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

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all valid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestValid2()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2014, 12, 23);
        * "Brandon", "Mc'Davies", 123456789, DOB, DOH, DOT, 200000
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Mc'Davies", 123456789, DOB, DOH, DOT, 200000);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all valid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestValid3()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1984, 12, 23);
        * DateTime DOH = new DateTime(1994, 11, 03);
        * DateTime DOT = new DateTime();
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1984, 12, 23);
            DateTime DOH = new DateTime(1994, 11, 03);
            DateTime DOT = new DateTime();
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestInvalidSIN()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime();
        * DateTime DOH = new DateTime();
        * DateTime DOT = new DateTime();
        * "Brandon", "Davies", 1234756789, DOB, DOH, DOT, 230000
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
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

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestInvalidDOHBeforeDOB()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(2003, 12, 12);
        * DateTime DOH = new DateTime(2001, 01, 29);
        * DateTime DOT = new DateTime(2006, 05, 21);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
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

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestInvalidDOTBoforeDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 11, 14);
        * DateTime DOH = new DateTime(2012, 10, 19);
        * DateTime DOT = new DateTime(2010, 07, 29);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
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

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestInvalidDOTnoDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 11, 14);
        * DateTime DOH = new DateTime();
        * DateTime DOT = new DateTime(2010, 07, 29);
        * "Brandon", "Davies", 933456789, DOB, DOH, DOT, 180000
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOTnoDOH()
        {
            DateTime DOB = new DateTime(1993, 11, 14);
            DateTime DOH = new DateTime();
            DateTime DOT = new DateTime(2010, 07, 29);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 180000);
        }

        /**
        * \brief This unit test will create an employee and runs it's details, and will ensure that the string is what it 
        * should be(it is hardcoded)
        * 
        * \<b>Name of Method/b>
        * DetailsTestValid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2014, 12, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 
        * \<b>Expected Result</b>
        * The expected result is that the string will be "Employee Type: FullTime\nName: Brandon Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1954-08-20\nDate of Hire: 1994-09-03\nDate of Termination: 2014-12-23\nSalary: 230000"
        * 
        * \<b>Actual Result</b>
        * The string is equivalent to "Employee Type: FullTime\nName: Brandon Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1954-08-20\nDate of Hire: 1994-09-03\nDate of Termination: 2014-12-23\nSalary: 230000"
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

        /**
        * \brief This unit test will create an employee and runs it's details, and will ensure that the string is what it 
        * should be(it is hardcoded)
        * 
        * \<b>Name of Method/b>
        * ToStringTestValid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2014, 12, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 
        * \<b>Expected Result</b>
        * The expected result is that the string will be "|FT|Brandon|Davies|123456789|1954-08-20|1994-09-03|2014-12-23|230000|"
        * 
        * \<b>Actual Result</b>
        * The string is equivalent to "|FT|Brandon|Davies|123456789|1954-08-20|1994-09-03|2014-12-23|230000|"
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
            Assert.IsTrue(toString == "|FT|Brandon|Davies|123456789|1954-08-20|1994-09-03|2014-12-23|230000|");
        }

        /**
        * \brief This unit test will set the birth date to a valid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthDateTestValidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1993, 05, 15)
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthDateTestValidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            DateTime date = new DateTime(1993, 05, 15);
            bool retVal = employee.SetDateOfBirth(date);
            Assert.IsTrue(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthDateTestInvalidDOBafterDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(1998, 05, 15);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), DOB);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth string to a valid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthDateTestValidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1993, 05, 15)
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestValidString()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("1993-04-24");
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthStringTestInvalidFormat()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "19930424"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestInvalidFormat()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("19930424");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthStringTestInvalidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "1993-13-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("1993-13-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthStringTestInvalidFuture()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "2017-11-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthStringTestInvalidFuture()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("2017-11-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthStringTestInvalidDOBafterDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime();
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "2001-12-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), DOB);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthIntsTestInvalidLetter()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "1993-s2-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestInvalidLetter()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth("1993-s2-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth date to a valid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthIntsTestValid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1993, 04, 24)
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestValid()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth(1993, 04, 24);
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthIntsTestInvalidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "1993, 04, 31"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth(1993, 04, 31);
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthIntsTestInvalidFutureDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "2017, 04, 24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfBirth")]
        public void SetDateOfBirthIntsTestInvalidFutureDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfBirth(2017, 04, 24);
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the birth date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfBirthIntsTestInvalidDOBafterDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime();
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 2001,12,24
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfBirth(), DOB);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to a valid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireDateTestValidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(2012, 04, 23)
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireDateTestValidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            DateTime date = new DateTime(2012, 04, 23);
            bool retVal = employee.SetDateOfHire(date);
            Assert.IsTrue(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireDateTestInvalidDOHafterDOT()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 2012, 04, 23
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireStringTestInvalidDOHbeforeDOB()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1985, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 1980, 04, 23
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire string to a valid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireStringTestValidString()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * "1993-04-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestValidString()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-04-24");
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireStringTestInvalidFormat()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "19930424"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidFormat()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("19930424");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireStringTestInvalidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "1993-13-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireStringTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-13-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireStringTestInvalidDOHafterDOT()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "2001-12-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireDateTestInvalidDOHbeforeDOB()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "1980-12-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireIntsTestInvalidLetter()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "1993-s2-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidLetter()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire("1993-s2-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to a valid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireIntsTestValid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * 1993, 04, 24
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestValid()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire(1993, 04, 24);
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireIntsTestInvalidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * 1993, 04, 31
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfHire")]
        public void SetDateOfHireIntsTestInvalidDate()
        {
            FulltimeEmployee employee = new FulltimeEmployee();
            bool retVal = employee.SetDateOfHire(1993, 04, 31);
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetDateOfHire(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireIntsTestInvalidDOHafterDOT()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 2001, 12, 24
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of hire date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfHireIntsTestInvalidDOHbeforeDOB()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 1980, 12, 24
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfHire(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination date to a valid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationDateTestValidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1984, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 2012, 04, 23
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
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

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationDateTestInvalidDOTbeforeDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 1992, 04, 23
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination string to a valid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationStringTestValidString()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "1997-04-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
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

            DateTime date = new DateTime(1997, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationStringTestInvalidFormat()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "19970424"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidFormat()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);

            bool retVal = employee.SetDateOfTermination("19970424");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationStringTestInvalidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "1997-13-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationStringTestInvalidDate()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);

            bool retVal = employee.SetDateOfTermination("1997-13-24");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationStringTestInvalidDOTbeforeDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "1993-12-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination string to an invalid string
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationIntsTestInvalidLetter()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * "1993-s2-24"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidLetter()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);

            bool retVal = employee.SetDateOfTermination("1993-s2-24");
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination date to a valid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationIntsTestValid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 1997, 04, 24
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
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

            DateTime date = new DateTime(1997, 04, 24);
            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationIntsTestInvalidDate()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 1997, 04, 31
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetDateOfTermination")]
        public void SetDateOfTerminationIntsTestInvalidDate()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2000, 03, 23);
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000);

            bool retVal = employee.SetDateOfTermination(1997, 04, 31);
            Assert.IsFalse(retVal);

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the date of termination date to an invalid date
        * 
        * \<b>Name of Method/b>
        * SetDateOfTerminationIntsTestInvalidDOTbeforeDOH()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime(1954, 08, 20);
        * DateTime(1994, 09, 03);
        * DateTime(2000, 03, 23);
        * "Brandon", "Davies", 123456789, DOB, DOH, DOT, 230000
        * 1992, 12, 24
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetDateOfTermination(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the salary to a valid amount
        * 
        * \<b>Name of Method/b>
        * SetSalaryValid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * 20000
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetSalary")]
        public void SetSalaryValid()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetSalary(20000);
            Assert.IsTrue(retVal);

            Assert.AreEqual(employee.GetSalary(), 20000);
        }

        /**
        * \brief This unit test will set the salary to an invalid amount
        * 
        * \<b>Name of Method/b>
        * SetSalaryInvalidNegitive()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * -20000
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("FulltimeEmployee SetSalary")]
        public void SetSalaryInvalidNegitive()
        {
            FulltimeEmployee employee = new FulltimeEmployee("Brandon", "Davies");
            bool retVal = employee.SetSalary(-20000);
            Assert.IsFalse(retVal);

            Assert.AreEqual(employee.GetSalary(), 0);
        }
    }
}
