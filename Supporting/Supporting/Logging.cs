using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Supporting
{
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
        public static void LogEvent(String className, String methodName, String eventDetails)
        {
            //example in winProg-M08 slides
            //I am a little shy onthe details on how the event logger class works. The arguments may have to be tweaked
        }

        /**
        * \brief The OpenLog method will open each log. 
        * 
        * \details <b>Details</b>
        * 
        * \param args - n/a
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        *
        * \return - EventLog - returns the log object 
        */
        private static EventLog OpenLog()
        {
            return new EventLog();//temp to remove erros
        }

        /**
        * \brief The CloseLog method will close each log. 
        * 
        * \details <b>Details</b>
        * 
        * \param args - <b> EventLog Log </b> - contains the log file.
        * 
        * \throw <EndOfProgramException> - If the user wants the program to end
        *
        * \return - n/a
        */
        private static void CloseLog(EventLog Log)
        {

        }
    }
}
