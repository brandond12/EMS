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
    /// \brief <b>Brief Description</b> - This class will log each step the user takes that makes a change tothe database. 
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
            EventLog serviceEventLog = new EventLog();
            if (!EventLog.SourceExists(className))
            {
                EventLog.CreateEventSource(className,methodName);
            }
            serviceEventLog.Source = className;
            serviceEventLog.Log = methodName;
            serviceEventLog.WriteEntry(eventDetails);
        } 
    }
}
