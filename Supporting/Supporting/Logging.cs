/*
* FILE   : Logging.cs
* PROJECT  : INFO 2180 -Software Quality 1 - EMS
* PROGRAMMER : Jennifer Klimova
* FIRST VERSION : 2015-11-20
* DESCRIPTION : This is the header for the logging class that will collect information of the users inputs
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Supporting
{
    /// \class Logging
    ///
    /// \brief <b>Brief Description</b> - This class will log each step the user takes that makes a change to the database. It is related to the entire project as the UIMenu, AllEmployees, and Container class are all going to be using the logging service. Any errors the logging might face is that it does not receive full information, in which case it will simply leave a blank in the database. 
    ///
    /// \author <i>Jennifer Klimova</i>
    public static class Logging
    {

        /**
        * \brief The LogEvent method will log each step the user takes. 
        * 
        * \details <b>Details</b>
        * 
        * \param args - <b> string className </b> - contains the class name 
        * \param args - <b> string methodName </b> - contains the method name being used
        * \param args - <b> string eventDetails </b> - contains the events details
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        * 
        * \return - n/a 
        */
        public static void Log(string className, string methodName, string eventDetails)
        {
            //write line to a file name and specify the string
            //write a log to a file, in test, open it read compare to what you think should be in there

            StreamWriter log;
            String timeStamp = DateTime.Now.ToString();

            if (!File.Exists("ems." + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log"))
            {

                log = new StreamWriter("ems." + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log");

            }

            else
            {

                log = File.AppendText("ems." + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log");

            }

            string formattedS = timeStamp + " " +"[" + className + "." + methodName + "] " + eventDetails;

            log.WriteLine(formattedS);

            log.Close();
        } 
    }
}
