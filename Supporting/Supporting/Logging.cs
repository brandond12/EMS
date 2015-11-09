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
        public static void LogEvent(String className, String methodName, String eventDetails)
        {
            //example in winProg-M08 slides
            //I am a little shy onthe details on how the event logger class works. The arguments may have to be tweaked
        }

        private static EventLog OpenLog()
        {
            return new EventLog();//temp to remove erros
        }

        private static void CloseLog(EventLog Log)
        {

        }
    }
}
