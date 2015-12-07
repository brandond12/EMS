using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supporting;
using System.IO;

namespace Loggingtests
{
    [TestClass]
    public class Loggingtests
    {
        [TestMethod]
        public void Logging_ValidInput_ReturnsValidLogFileEntry()
        {
           // string path = ;
            string methodName = "GetEmployeeInformation";
            string className = "Employee";
            string eventDetails = "Employee - Clarke,Sean (333 333 333) VALID";

            StreamWriter writer = new StreamWriter("ems." + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log");
            writer.WriteLine("");
            writer.Close();

            String timeStamp = DateTime.Now.ToString();
            Logging.Log(className, methodName, eventDetails);
            string formattedS = "[" + className + "." + methodName + "] " + eventDetails + "\r\n";

            StreamReader reader = new StreamReader("ems." + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log");

            string logEvent = reader.ReadToEnd();
            

            reader.Close();
            Assert.IsTrue(logEvent.Contains(formattedS));
        }
    }
}
