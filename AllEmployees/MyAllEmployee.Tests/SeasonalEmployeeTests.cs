/*
* FILE   : SeasonalEmployeeTests.cs
* PROJECT  : INFO 2180 -Software Quality 1 - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-12-08
* DESCRIPTION : This is the header for the seaonal employee tests. Here we test the Seasonal Employee class.
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    /// \class SeasonalEmployeeTests
    ///
    /// \brief <b>Brief Description</b> 
    /// This class is used to test the SeasonalEmployee methods in the AllEmployee class. The methods tested 
    /// include the constructors, Details, SetDateOfBirth (all 3 overloaded methods), SetPiecePay, SetSeason and ToString.
    [TestClass]
    public class SeasonalEmployeeTests
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
        [TestCategory("SeasonalEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
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
        [TestCategory("SeasonalEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies");
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
        [TestCategory("SeasonalEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "LeRoy-Davies");
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
        [TestCategory("SeasonalEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc/Davies");
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
        [TestCategory("SeasonalEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc Davies");
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
        [TestCategory("SeasonalEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon2", "Davies");
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
        * "Brandon", "Davies", 123456789, DOB, DOH, "Summer", 10
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB ,"Summer", 10);
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
        * DateTime DOB = new DateTime(1991, 12, 23);
        * "Brandon", "Mc'Davies", 123456789, DOB, "Winter", 15
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1991, 12, 23);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies", 123456789, DOB, "Winter", 15);
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
        * DateTime DOB = new DateTime(1984, 04, 24);
        * "Brandon", "Davies", 123456789, DOB, "Fall", 1
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \<b>Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Fall", 1);
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
        * DateTime DOB = new DateTime(1993, 04, 24);
        * "Brandon", "Davies", 1234756789, DOB, "Fall", 10
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSIN()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 1123456789, DOB, "Fall", 10);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestInvalidPiecePay()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 04, 24);
        * "Brandon", "Davies", 1234756789, DOB,"Fall", -12
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidPiecePay()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "Fall", -12);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \<b>Name of Method/b>
        * ConstructorWithAllParamTestInvalidSeason()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 04, 24);
        * "Brandon", "Davies", 1234756789, DOB,"October", 13
        * 
        * \<b>Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \<b>Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidSeason()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies", 123456789, DOB, "October", 13);
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
        * DateTime DOB = new DateTime(1954, 04, 24);
        * "Brandon", "Davies", 123456789, DOB, "Winter", 15
        * 
        * \<b>Expected Result</b>
        * The expected result is that the string will be "Employee Type: Seasonal\nName: Brandon Mc'Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1993-04-24\nSeason: Winter\nPrice per Piece: 15"
        * 
        * \<b>Actual Result</b>
        * The string is equivalent to "Employee Type: Seasonal\nName: Brandon Mc'Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1993-04-24\nSeason: Winter\nPrice per Piece: 15"
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee Details")]
        public void DetailsTestValid()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies", 123456789, DOB, "Winter", 15);
            String details = employee.Details();
            Assert.IsTrue(details == "Employee Type: Seasonal\nName: Brandon Mc'Davies\nSocial Insurance Number: 123 456 789\nDate of Birth: 1993-04-24\nSeason: Winter\nPrice per Piece: 15");
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
        * DateTime DOB = new DateTime(1993, 04, 24);
        * "Brandon", "Davies", 123456789, DOB, "Winter", 15
        * 
        * \<b>Expected Result</b>
        * The expected result is that the string will be "|SN|Brandon|Mc'Davies|123456789|1993-04-24|Winter|15|"
        * 
        * \<b>Actual Result</b>
        * The string is equivalent to "|SN|Brandon|Mc'Davies|123456789|1993-04-24|Winter|15|"
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee ToString")]
        public void ToStringTestValid()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Mc'Davies", 123456789, DOB, "Winter", 15);
            String toString = employee.ToString();
            Assert.IsTrue(toString == "|SN|Brandon|Mc'Davies|123456789|1993-04-24|Winter|15|");
        }

        /**
        * \brief This unit test will set the piece pay to a valid amount
        * 
        * \<b>Name of Method/b>
        * SetPiecePayValid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * 10
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee SetSalary")]
        public void SetPiecePayValid()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            bool retVal = employee.SetPiecePay(10);
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetPiecePay(), 10);
        }

        /**
        * \brief This unit test will set the piece pay to an invalid amount
        * 
        * \<b>Name of Method/b>
        * SetPiecePayInvalidNegitive()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * -10
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee SetPiecePay")]
        public void SetPiecePayInvalidNegitive()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            bool retVal = employee.SetPiecePay(-10);
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetPiecePay(), 0);
        }

        /**
        * \brief This unit test will set the season to a valid season
        * 
        * \<b>Name of Method/b>
        * SetSeasonValid1()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee SetPiecePay")]
        public void SetSeasonValid1()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            bool retVal = employee.SetSeason("");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetSeason(), "");
        }

        /**
        * \brief This unit test will set the season to a valid season
        * 
        * \<b>Name of Method/b>
        * SetSeasonValid2()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * "Winter"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee SetSeason")]
        public void SetSeasonValid2()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            bool retVal = employee.SetSeason("Winter");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetSeason(), "Winter");
        }

        /**
        * \brief This unit test will set the season to a valid season
        * 
        * \<b>Name of Method/b>
        * SetSeasonValid3()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * "Summer"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \<b>Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee SetSeason")]
        public void SetSeasonValid3()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            bool retVal = employee.SetSeason("Summer");
            Assert.IsTrue(retVal);
            Assert.AreEqual(employee.GetSeason(), "Summer");
        }

        /**
        * \brief This unit test will set the season to an invalid season
        * 
        * \<b>Name of Method/b>
        * SetSeasonInvalid()
        * 
        * \<b>How test is Conducted/b>
        * This test is run automatically
        * 
        * \<b>Type of Test</b>
        * The type of test is an exception.
        * 
        * \<b>Sample Data Sets</b>
        * "Brandon", "Davies"
        * "Summer3"
        * 
        * \<b>Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \<b>Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("SeasonalEmployee SetSeason")]
        public void SetSeasonInvalid()
        {
            SeasonalEmployee employee = new SeasonalEmployee("Brandon", "Davies");
            string currentSeason = employee.GetSeason();
            bool retVal = employee.SetSeason("Summer3");
            Assert.IsFalse(retVal);
            Assert.AreEqual(employee.GetSeason(), currentSeason);
        }
    }
}