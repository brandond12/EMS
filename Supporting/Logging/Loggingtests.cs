/*
* FILE   : Loggingtests.cs
* PROJECT  : INFO 2180 -Software Quality 1 - EMS
* PROGRAMMER : Jennifer Klimova
* FIRST VERSION : 2015-12-07
* DESCRIPTION : This is the header for the logging test class that will test the logger
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supporting;
using System.IO;

namespace Loggingtests
{
    [TestClass]
    public class Loggingtests
    {
        /**
        * \brief This unit test will create it's own log event, and then send information to the logging function and compare the results to 
        * see if it properly logged the events.
        * 
        * \<b>Name of Method/b>
        * Logging_ValidInput_ReturnsValidLogFileEntry()
        * 
        * \<b>How test is Conducted/b>
        * This test is given set string variables, which will then allow it to be run automatically, and will compare 2 results (1 created in 
        * the test function, and the other created in the original Logging function).
        * 
        * \<b>Type of Test</b>
        * The type of test is normal/functional.
        * 
        * \<b>Sample Data Sets</b>
        * string methodName = "GetEmployeeInformation";
        * string className = "Employee";
        * string eventDetails = "Employee - Clarke,Sean (333 333 333) VALIDER";
        * 
        * \<b>Expected Result</b>
        * The expected result is that both logging events are the same in terms of what information they were given. 
        * 
        * \<b>Actual Result</b>
        * Both logs matched up as required.
        */
        [TestMethod]
        public void Logging_ValidInput_ReturnsValidLogFileEntry()
        {
           // Sample Data
            string methodName = "GetEmployeeInformation";
            string className = "Employee";
            string eventDetails = "Employee - Clarke,Sean (333 333 333) VALIDER";

            // This will ensure that the test log file is empty
            StreamWriter writer = new StreamWriter("..\\..\\..\\..\\ems." + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log");
            writer.WriteLine("");
            writer.Close();

            String timeStamp = DateTime.Now.ToString();
            // Log the details
            Logging.Log(className, methodName, eventDetails);
            string formattedS = "[" + className + "." + methodName + "] " + eventDetails + "\r\n";

            // Read in the details
            StreamReader reader = new StreamReader("..\\..\\..\\..\\ems." + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log");

            string logEvent = reader.ReadToEnd();
            reader.Close();

            // Check if both log details are the same
            Assert.IsTrue(logEvent.Contains(formattedS));
        }
    }
}
