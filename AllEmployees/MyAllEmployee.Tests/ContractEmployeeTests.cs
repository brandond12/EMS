/*
* FILE   : ContractEmployeeTests.cs
* PROJECT  : INFO 2180 -Software Quality 1 - EMS
* PROGRAMMER : Brandon Davies
* FIRST VERSION : 2015-12-07
* DESCRIPTION : This is the header for the contract employee tests. Here we test the Contract Employee class.
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace MyAllEmployee.Tests
{
    /// \class ContractEmployeeTests
    ///
    /// \brief  <b> Brief Description</b> 
    /// This class is used to test the ContractEmployee methods in the AllEmployee class. The methods tested 
    /// include the constructors, Details, SetDateOfBirth (all 3 overloaded methods), SetContractDate (all 3 overloaded methods), SetContractStopDate(all 3 overloaded methods), SetFixedCntractAmount and ToString.

    [TestClass]
    public class ContractEmployeeTests
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
        [TestCategory("ContractEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid1()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
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
        [TestCategory("ContractEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid2()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc'Davies");
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
        [TestCategory("ContractEmployee Constructor with names")]
        public void ConstructorWithNamesTestValid3()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "LeRoy-Davies");
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
        [TestCategory("ContractEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSlash()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc/Davies");
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
        [TestCategory("ContractEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidSpace()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc Davies");
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
        [TestCategory("ContractEmployee Constructor with names")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithNamesTestInvalidNumber()
        {
            ContractEmployee employee = new ContractEmployee("Brandon2", "Davies");
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
        * DateTime DOB = new DateTime(1993, 04, 24);
        * DateTime DOH = new DateTime(2000, 12, 12);
        * DateTime DOT = new DateTime(2004, 03, 02);
        * "Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid1()
        {
            DateTime DOB = new DateTime(1993, 04, 24);
            DateTime DOH = new DateTime(2000, 12, 12);
            DateTime DOT = new DateTime(2004, 03, 02);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
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
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2014, 12, 23);
        * "Brandon", "Mc'Davies", 543456789, DOB, DOH, DOT, 21.54
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid2()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Mc'Davies", 543456789, DOB, DOH, DOT, 21.54);
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
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime();
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 34.98
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no exception
        * 
        * \ <b> Actual Result</b>
        * An exception is not thrown 
        */
        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        public void ConstructorWithAllParamTestValid3()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime();
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 34.98);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestInvalidBN()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2014, 12, 23);
        * "Brandon", "Davies", 54347589, DOB, DOH, DOT, 12.87
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidBN()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime(1994, 09, 03);
            DateTime DOT = new DateTime(2014, 12, 23);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 54347589, DOB, DOH, DOT, 12.87);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestInvalidDOHBeforeDOB()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(2003, 12, 12);
        * DateTime DOH = new DateTime(2001, 02, 27);
        * DateTime DOT = new DateTime(2007, 05, 21);
        * "Brandon", "Davies", 033456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOHBeforeDOB()
        {
            DateTime DOB = new DateTime(2003, 12, 12);
            DateTime DOH = new DateTime(2001, 02, 27);
            DateTime DOT = new DateTime(2007, 05, 21);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 033456789, DOB, DOH, DOT, 18);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestInvalidDOTBoforeDOH()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 11, 14);
        * DateTime DOH = new DateTime(2012, 10, 19);
        * DateTime DOT = new DateTime(1004, 07, 29);
        * "Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown 
        */
        [TestMethod]
        [TestCategory("ContractEmployee Constructor with all parameters")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void ConstructorWithAllParamTestInvalidDOTBoforeDOH()
        {
            DateTime DOB = new DateTime(1993, 11, 14);
            DateTime DOH = new DateTime(2012, 10, 19);
            DateTime DOT = new DateTime(1004, 07, 29);
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18.78);
        }

        /**
        * \brief This unit test will check the constructor that takes in all possible parameters, and give them all invalid data
        * 
        * \ <b> Name of Method</b>
        * ConstructorWithAllParamTestInvalidDOTnoDOH()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1993, 11, 14);
        * DateTime DOH = new DateTime();
        * DateTime DOT = new DateTime(2010, 07, 29);
        * "Brandon", "Davies", 933456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
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
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 933456789, DOB, DOH, DOT, 18);
        }

        /**
        * \brief This unit test will create an employee and runs it's details, and will ensure that the string is what it 
        * should be(it is hardcoded)
        * 
        * \ <b> Name of Method</b>
        * DetailsTestValid()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2014, 12, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is that the string will be "Employee Type: Contract\nName: Brandon Davies\nBuisness Number: 54345 6789\nBuisness Start Date: 1954-08-20\nContract Start Date: 1994-09-03\nContract Stop Date: 2014-12-23\nFixed Contract Amount: 18"
        * 
        * \ <b> Actual Result</b>
        * The string is equivalent to "Employee Type: Contract\nName: Brandon Davies\nBuisness Number: 54345 6789\nBuisness Start Date: 1954-08-20\nContract Start Date: 1994-09-03\nContract Stop Date: 2014-12-23\nFixed Contract Amount: 18" 
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

        /**
        * \brief This unit test will create an employee and runs it's details, and will ensure that the string is not what it 
        * should be(it is hardcoded)
        * 
        * \ <b> Name of Method</b>
        * DetailsTestInvalidNoDate()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an excepton.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime();
        * DateTime DOT = new DateTime();
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is an exception
        * 
        * \ <b> Actual Result</b>
        * An exception is thrown
        */
        [TestMethod]
        [TestCategory("ContractEmployee Details")]
        [ExpectedException(typeof(FailedConstructorException))]
        public void DetailsTestInvalidNoDate()
        {
            DateTime DOB = new DateTime(1954, 08, 20);
            DateTime DOH = new DateTime();
            DateTime DOT = new DateTime();
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies", 543456789, DOB, DOH, DOT, 18);
        }

        /**
        * \brief This unit test will create an employee and runs it's details, and will ensure that the string is what it 
        * should be(it is hardcoded)
        * 
        * \ <b> Name of Method</b>
        * ToStringTestValid()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2014, 12, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is that the string will be "|CT|Brandon|Davies|543456789|1954-08-20|1994-09-03|2014-12-23|18|"
        * 
        * \ <b> Actual Result</b>
        * The string is equivalent to "|CT|Brandon|Davies|543456789|1954-08-20|1994-09-03|2014-12-23|18|"
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
            Assert.IsTrue(toString == "|CT|Brandon|Davies|543456789|1954-08-20|1994-09-03|2014-12-23|18|");
        }
 
        /**
        * \brief This unit test will set the contract start date to a valid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateDateTestValidDate()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime(2012, 04, 23)
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateDateTestValidDate()
        {
            DateTime date = new DateTime(2012, 04, 23);
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate(date);
            Assert.IsTrue(retVal);

            int compReturn = DateTime.Compare(employee.GetContractStartDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateDateTestInvalidDOHafterDOT()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18 
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStartDate(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateStringTestInvalidDOHbeforeDOB()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1985, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 853456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStartDate(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start string to a valid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateStringTestValidString()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        *  bool retVal = employee.SetContractStartDate("1993-04-24")
        *  DateTime(1993, 04, 24)
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestValidString()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("1993-04-24");
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetContractStartDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start string to an invalid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateStringTestInvalidFormat()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * bool retVal = employee.SetContractStartDate("19930424")
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestInvalidFormat()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("19930424");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetContractStartDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start string to an invalid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateStringTestInvalidDate()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * bool retVal = employee.SetContractStartDate("1993-13-24")
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateStringTestInvalidDate()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("1993-13-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetContractStartDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start string to an invalid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateStringTestInvalidDOHafterDOT()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * "2001-12-24"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStartDate(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateDateTestInvalidDOHbeforeDOB()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1985, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 853456789, DOB, DOH, DOT, 18
        * "1980-12-24"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStartDate(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateIntsTestInvalidLetter()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "1993-s2-24"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestInvalidLetter()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate("1993-s2-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetContractStartDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to a valid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateStringTestValidString()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        *  bool retVal = employee.SetContractStartDate("1993-04-24")
        *  DateTime(1993, 04, 24)
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestValid()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate(1993, 04, 24);
            Assert.IsTrue(retVal);

            DateTime date = new DateTime(1993, 04, 24);
            int compReturn = DateTime.Compare(employee.GetContractStartDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateIntsTestInvalidDate()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "1993-04-31"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStartDate")]
        public void SetContractStartDateIntsTestInvalidDate()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStartDate(1993, 04, 31);
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetContractStartDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateIntsTestInvalidDOHafterDOT()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18 
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStartDate(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract start date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStartDateIntsTestInvalidDOHbeforeDOB()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1984, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 843456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStartDate(), DOH);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop date to a valid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateDateTestValidDate()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1984, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 843456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
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

            int compReturn = DateTime.Compare(employee.GetContractStopDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateDateTestInvalidDOTbeforeDOH()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStopDate(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop string to a valid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateStringTestValidString()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
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

            DateTime date = new DateTime(1995, 04, 24);
            int compReturn = DateTime.Compare(employee.GetContractStopDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract string date to an invalid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateStringTestInvalidFormat()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "19930424"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestInvalidFormat()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStopDate("19930424");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetContractStopDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop string to an invalid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateStringTestInvalidDate()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "1993-13-24"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateStringTestInvalidDate()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStopDate("1993-13-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetContractStopDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop string to an invalid string
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateStringTestInvalidDOTbeforeDOH()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * "1992-12-24"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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


            int compReturn = DateTime.Compare(employee.GetContractStopDate(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateIntsTestInvalidLetter()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "1993-s2-24"
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetContractStopDate")]
        public void SetContractStopDateIntsTestInvalidLetter()
        {
            ContractEmployee employee = new ContractEmployee();
            bool retVal = employee.SetContractStopDate("1993-s2-24");
            Assert.IsFalse(retVal);

            DateTime date = new DateTime();
            int compReturn = DateTime.Compare(employee.GetContractStopDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop date to a valid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateIntsTestValid()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
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

            DateTime date = new DateTime(1995, 04, 24);
            int compReturn = DateTime.Compare(employee.GetContractStopDate(), date);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateIntsTestInvalidDate()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 1997, 04, 31
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStopDate(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the contract stop date to an invalid date
        * 
        * \ <b> Name of Method</b>
        * SetContractStopDateIntsTestInvalidDOTbeforeDOH()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * DateTime DOB = new DateTime(1954, 08, 20);
        * DateTime DOH = new DateTime(1994, 09, 03);
        * DateTime DOT = new DateTime(2000, 03, 23);
        * "Brandon", "Davies", 543456789, DOB, DOH, DOT, 18
        * 1991, 12, 24
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
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

            int compReturn = DateTime.Compare(employee.GetContractStopDate(), DOT);
            Assert.AreEqual(0, compReturn);
        }

        /**
        * \brief This unit test will set the fixed contract amount to a valid amount
        * 
        * \ <b> Name of Method</b>
        * SetFixedContractAmountValid()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an normal/function.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Davies"
        * 18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be true and the data member should have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is true, and the data member should have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetFixedContractAmount")]
        public void SetFixedContractAmountValid()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
            bool retVal = employee.SetFixedContractAmount(18);
            Assert.IsTrue(retVal);

            Assert.AreEqual(employee.GetFixedContractAmount(), 18);
        }

        /**
        * \brief This unit test will set the fixed contract amount to an  invalid amount
        * 
        * \ <b> Name of Method</b>
        * SetFixedContractAmountInvalidNegitive()
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is an exception.
        * 
        * \ <b> Sample Data Sets</b>
        * "Brandon", "Davies"
        * -18
        * 
        * \ <b> Expected Result</b>
        * The expected result is the return value should be false and the data member should not have changed
        * 
        * \ <b> Actual Result</b>
        * Return value is false, and the data member should not have changed
        */
        [TestMethod]
        [TestCategory("ContractEmployee SetFixedContractAmount")]
        public void SetFixedContractAmountInvalidNegitive()
        {
            ContractEmployee employee = new ContractEmployee("Brandon", "Davies");
            bool retVal = employee.SetFixedContractAmount(-18);
            Assert.IsFalse(retVal);

            Assert.AreEqual(employee.GetFixedContractAmount(), 0);
        }
    }
}